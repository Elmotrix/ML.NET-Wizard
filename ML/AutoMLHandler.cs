using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ML
{
    class AutoMLHandler
    {

        ExperimentSettings experimentSettings;
        MLContext mlContext = new MLContext();
        List<ColumnInfo> columnInfos = new List<ColumnInfo>();
        object ExperimentResult;
        List<ShallowExperimentResult> ShallowExperimentResultsList;
        public List<ColumnInfo> ColumnInfos { get { return columnInfos; } }
        public ShallowExperimentResult[] ShallowExperimentResults { get { return ShallowExperimentResultsList.ToArray(); } }
        string[] algorithms;
        string FilePath;
        char Separator;
        bool HasHeader;
        public delegate void TrainingCompleteEventHandler(object sender, EventArgs e);
        public event TrainingCompleteEventHandler TrainingComplete;
        IDataView data;
        public DataTable LoadData(string filePath,char separator, bool hasHeader)
        {
            FilePath = filePath;
            Separator = separator;
            HasHeader = hasHeader;
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = null;
                if (hasHeader)
                {
                    headers = sr.ReadLine().Split(separator);
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                }
                int j = 0;
                while (!sr.EndOfStream && j < 20)
                {
                    j++;
                    string[] rows = sr.ReadLine().Split(separator);
                    if (headers == null)
                    {
                        headers = new string[rows.Length];
                        for (int i = 0; i < rows.Length; i++)
                        {
                            headers[i] = "#" + i;
                            dt.Columns.Add(headers[i]);
                        }
                    }
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }


            columnInfos = new List<ColumnInfo>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataKind dataKind = DataKind.String;
                bool tryBoolValue = false;
                float tryFloatValue = 0;
                if (bool.TryParse(dt.Rows[0].ItemArray[i].ToString(), out tryBoolValue))
                {
                    dataKind = DataKind.Boolean;
                }
                else if (Single.TryParse(dt.Rows[0].ItemArray[i].ToString(), out tryFloatValue))
                {
                    dataKind = DataKind.Single;
                }
                else if (Single.TryParse(dt.Rows[0].ItemArray[i].ToString().Replace('.', ','), out tryFloatValue))
                {
                    dataKind = DataKind.Single;
                }
                columnInfos.Add(new ColumnInfo()
                {
                    Index = i,
                    Name = dt.Columns[i].ColumnName,
                    ThisDataKind = dataKind
                });
            }
            return dt;
        }

        public string[] SetExperiment<T>() where T: ExperimentSettings, new()
        {
            experimentSettings = new T();
            return GetAvailableAlgorithms<T>();
        }

        private string[] GetAvailableAlgorithms<T>()
        {
            if (typeof(T) == typeof(BinaryExperimentSettings))
            {
                return System.Enum.GetNames(typeof(BinaryClassificationTrainer));
            }
            else
            if (typeof(T) == typeof(MulticlassExperimentSettings))
            {
                return System.Enum.GetNames(typeof(MulticlassClassificationTrainer));
            }
            else
            if (typeof(T) == typeof(RegressionExperimentSettings))
            {
                return System.Enum.GetNames(typeof(RegressionTrainer));
            }
            else
            if (typeof(T) == typeof(RecommendationExperimentSettings))
            {
                return System.Enum.GetNames(typeof(RecommendationTrainer));
            }
            else
            if (typeof(T) == typeof(RankingExperimentSettings))
            {
                return System.Enum.GetNames(typeof(RankingTrainer));
            }
            return new string[0];
        }
        public void TrainModel(string[] excludedAlgorithms = null, uint timeout = 3600, string saveFolder = "")
        {
            new Thread(delegate () {
                ExecuteTraining(excludedAlgorithms, timeout, saveFolder);
            }).Start();
        }


        public void ExecuteTraining(string[] excludedAlgorithms = null, uint timeout = 3600, string saveFolder = "")
        {
            ShallowExperimentResultsList = new List<ShallowExperimentResult>();
            var columnInfo = new ColumnInformation();


            TextLoader.Column[] columns = new TextLoader.Column[columnInfos.Count];
            for (int i = 0; i < columnInfos.Count; i++)
            {
                columns[i] = columnInfos[i].GetColumn();
            }

            TextLoader textLoader = mlContext.Data.CreateTextLoader(columns, hasHeader: HasHeader, separatorChar: Separator);
            data = textLoader.Load(FilePath);

            foreach (ColumnInfo item in columnInfos)
            {
                if (item.IsLabel)
                {
                    columnInfo.LabelColumnName = item.Name;
                }
            }
            Type trainerType = experimentSettings.GetType();
            experimentSettings.MaxExperimentTimeInSeconds = timeout;
            if (saveFolder != "")
            {
                experimentSettings.CacheDirectoryName = saveFolder;
            }
            if (trainerType == typeof(BinaryExperimentSettings))
            {
                BinaryExperimentSettings experimentSetting = (BinaryExperimentSettings)experimentSettings;
                if (excludedAlgorithms != null)
                {
                    for (int i = 0; i < excludedAlgorithms.Length; i++)
                    {
                        experimentSetting.Trainers.Remove((BinaryClassificationTrainer)Enum.Parse(typeof(BinaryClassificationTrainer), excludedAlgorithms[i]));
                    }
                }
                BinaryClassificationExperiment experiment = mlContext.Auto().CreateBinaryClassificationExperiment(experimentSetting);
                ExperimentResult<BinaryClassificationMetrics> experimentResult = experiment.Execute(data, columnInfo);
                ExperimentResult = experimentResult;
                int j = 0;
                foreach (var item in experimentResult.RunDetails)
                {
                    ShallowExperimentResult result = new ShallowExperimentResult();
                    result.Index = j;
                    result.Algorithm = item.TrainerName;
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            result.AddScore(propertyInfo.Name, (double)propertyInfo.GetValue(item.ValidationMetrics));
                        }
                    }
                    result.Model = item.Model;
                    ShallowExperimentResultsList.Add(result);
                    j++;
                }
            }
            if (trainerType == typeof(MulticlassExperimentSettings))
            {
                MulticlassExperimentSettings experimentSetting = (MulticlassExperimentSettings)experimentSettings;
                if (excludedAlgorithms != null)
                {
                    for (int i = 0; i < excludedAlgorithms.Length; i++)
                    {
                        experimentSetting.Trainers.Remove((MulticlassClassificationTrainer)Enum.Parse(typeof(MulticlassClassificationTrainer), excludedAlgorithms[i]));
                    }
                }
                MulticlassClassificationExperiment experiment = mlContext.Auto().CreateMulticlassClassificationExperiment(experimentSetting);
                ExperimentResult<MulticlassClassificationMetrics> experimentResult = experiment.Execute(data, columnInfo);
                ExperimentResult = experimentResult;
                int j = 0;
                foreach (var item in experimentResult.RunDetails)
                {
                    ShallowExperimentResult result = new ShallowExperimentResult();
                    result.Index = j;
                    result.Algorithm = item.TrainerName;
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            result.AddScore(propertyInfo.Name, (double)propertyInfo.GetValue(item.ValidationMetrics));
                        }
                    }
                    result.Model = item.Model;
                    ShallowExperimentResultsList.Add(result);
                    j++;
                }
            }
            if (trainerType == typeof(RegressionExperimentSettings))
            {
                RegressionExperimentSettings experimentSetting = (RegressionExperimentSettings)experimentSettings;
                if (excludedAlgorithms != null)
                {
                    for (int i = 0; i < excludedAlgorithms.Length; i++)
                    {
                         experimentSetting.Trainers.Remove((RegressionTrainer)Enum.Parse(typeof(RegressionTrainer), excludedAlgorithms[i]));
                    }
                }
                RegressionExperiment experiment = mlContext.Auto().CreateRegressionExperiment(experimentSetting);
                ExperimentResult<RegressionMetrics> experimentResult = experiment.Execute(data, columnInfo);
                ExperimentResult = experimentResult;
                int j = 0;
                foreach (var item in experimentResult.RunDetails)
                {
                    ShallowExperimentResult result = new ShallowExperimentResult();
                    result.Index = j;
                    result.Algorithm = item.TrainerName;
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            result.AddScore(propertyInfo.Name, (double)propertyInfo.GetValue(item.ValidationMetrics));
                        }
                    }
                    result.Model = item.Model;
                    ShallowExperimentResultsList.Add(result);
                    j++;
                }
            }
            if (trainerType == typeof(RecommendationExperimentSettings))
            {
                RecommendationExperimentSettings experimentSetting = (RecommendationExperimentSettings)experimentSettings;
                if (excludedAlgorithms != null)
                {
                    for (int i = 0; i < excludedAlgorithms.Length; i++)
                    {
                        experimentSetting.Trainers.Remove((RecommendationTrainer)Enum.Parse(typeof(RecommendationTrainer), excludedAlgorithms[i]));
                    }
                }
                RecommendationExperiment experiment = mlContext.Auto().CreateRecommendationExperiment(experimentSetting);
                ExperimentResult<RegressionMetrics> experimentResult = experiment.Execute(data, columnInfo);
                ExperimentResult = experimentResult;
                int j = 0;
                foreach (var item in experimentResult.RunDetails)
                {
                    ShallowExperimentResult result = new ShallowExperimentResult();
                    result.Index = j;
                    result.Algorithm = item.TrainerName;
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            result.AddScore(propertyInfo.Name, (double)propertyInfo.GetValue(item.ValidationMetrics));
                        }
                    }
                    result.Model = item.Model;
                    ShallowExperimentResultsList.Add(result);
                    j++;
                }
            }
            if (trainerType == typeof(RankingExperimentSettings))
            {
                RankingExperimentSettings experimentSetting = (RankingExperimentSettings)experimentSettings;
                if (excludedAlgorithms != null)
                {
                    for (int i = 0; i < excludedAlgorithms.Length; i++)
                    {
                        experimentSetting.Trainers.Remove((RankingTrainer)Enum.Parse(typeof(RankingTrainer), excludedAlgorithms[i]));
                    }
                }
                RankingExperiment experiment = mlContext.Auto().CreateRankingExperiment(experimentSetting);
                ExperimentResult<RankingMetrics> experimentResult = experiment.Execute(data, columnInfo);
                ExperimentResult = experimentResult;
                int j = 0;
                foreach (var item in experimentResult.RunDetails)
                {
                    ShallowExperimentResult result = new ShallowExperimentResult();
                    result.Index = j;
                    result.Algorithm = item.TrainerName;
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double))
                        {
                            result.AddScore(propertyInfo.Name, (double)propertyInfo.GetValue(item.ValidationMetrics));
                        }
                    }
                    result.Model = item.Model;
                    ShallowExperimentResultsList.Add(result);
                    j++;
                }
            }
            TrainingComplete?.Invoke(this, new EventArgs());
        }
        public void SaveModel(ShallowExperimentResult experimentResult, string path)
        {
            using FileStream stream = File.Create(path);
            mlContext.Model.Save(experimentResult.Model, data.Schema, stream);
        }
    }
}
