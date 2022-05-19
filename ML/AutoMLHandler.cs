using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Onnx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        public AutoMLHandler()
        {
            mlContext.Log += MlContext_Log;
        }

        MLContext mlContext = new MLContext();
        object ExperimentResult;
        List<ShallowExperimentResult> ShallowExperimentResultsList;
        public ShallowExperimentResult[] ShallowExperimentResults { get { return ShallowExperimentResultsList.ToArray(); } }
        public iDataLoader DataLoader { get; internal set; }
        public event EventHandler TrainingComplete;
        public event EventHandler<LoggingEventArgs> AutoMLLog;
        IDataView data;
        ModelType thisModelType = ModelType.None;
        private void MlContext_Log(object sender, LoggingEventArgs e)
        {
            AutoMLLog?.Invoke(sender, e);
        }
        public DataTable LoadDataSchemaFromFile(string[] filePath,char separator, bool hasHeader)
        {
            DataLoader = new FileDataLoader(filePath, separator, hasHeader);
            return DataLoader.LoadDataSchema();
        }
        public DataTable LoadDataSchemaFromDb(string connectionString, string commandText)
        {
            DataLoader = new DbDataLoader(connectionString, commandText);
            return DataLoader.LoadDataSchema();
        }

        public string[] SetExperimentType(ModelType modelType)
        {
            thisModelType = modelType;
            switch (modelType)
            {
                case ModelType.None:
                    break;
                case ModelType.Binary:
                    return System.Enum.GetNames(typeof(BinaryClassificationTrainer));
                case ModelType.Multiclass:
                    return System.Enum.GetNames(typeof(MulticlassClassificationTrainer));
                case ModelType.Regression:
                    return System.Enum.GetNames(typeof(RegressionTrainer));
                case ModelType.Recommendation:
                    return System.Enum.GetNames(typeof(RecommendationTrainer));
                case ModelType.Ranking:
                    return System.Enum.GetNames(typeof(RankingTrainer));
                default:
                    break;
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

            data = DataLoader.LoadData(mlContext);


            foreach (ColumnInfo item in DataLoader.ColumnInfos)
            {
                if (item.IsLabel)
                {
                    columnInfo.LabelColumnName = item.Name;
                }
            }

            if (thisModelType == ModelType.Binary)
            {
                BinaryExperimentSettings experimentSetting = new BinaryExperimentSettings();
                SetExperimentSettings(experimentSetting, timeout, saveFolder);
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
                CreateShallowResults<BinaryClassificationMetrics>(experimentResult);
            }
            if (thisModelType == ModelType.Multiclass)
            {
                MulticlassExperimentSettings experimentSetting = new MulticlassExperimentSettings();
                SetExperimentSettings(experimentSetting, timeout, saveFolder);
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
                CreateShallowResults<MulticlassClassificationMetrics>(experimentResult);
            }
            if (thisModelType == ModelType.Regression)
            {
                RegressionExperimentSettings experimentSetting = new RegressionExperimentSettings();
                SetExperimentSettings(experimentSetting, timeout, saveFolder);
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
                CreateShallowResults<RegressionMetrics>(experimentResult);
            }
            if (thisModelType == ModelType.Recommendation)
            {
                RecommendationExperimentSettings experimentSetting = new RecommendationExperimentSettings();
                SetExperimentSettings(experimentSetting, timeout, saveFolder);
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
                CreateShallowResults<RegressionMetrics>(experimentResult);
            }
            if (thisModelType == ModelType.Ranking)
            {
                RankingExperimentSettings experimentSetting = new RankingExperimentSettings();
                SetExperimentSettings(experimentSetting, timeout, saveFolder);
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
                CreateShallowResults<RankingMetrics>(experimentResult);
            }
            TrainingComplete?.Invoke(this, new EventArgs());
        }
        private void SetExperimentSettings(ExperimentSettings experimentSettings, uint timeout, string saveFolder)
        {
            experimentSettings.MaxExperimentTimeInSeconds = timeout;
            if (saveFolder != "")
            {
                experimentSettings.CacheDirectoryName = saveFolder;
            }
        }
        private void CreateShallowResults<T>(ExperimentResult<T> experimentResult) 
        {
            int j = 0;
            foreach (var item in experimentResult.RunDetails)
            {
                ShallowExperimentResult result = new ShallowExperimentResult();
                result.Index = j;
                result.Algorithm = item.TrainerName;
                if (item == experimentResult.BestRun)
                {
                    result.IsBest = true;
                }
                if (item.ValidationMetrics != null)
                {
                    foreach (PropertyInfo propertyInfo in item.ValidationMetrics.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(double) || propertyInfo.PropertyType == typeof(int))
                        {
                            result.AddScore(propertyInfo.Name, Convert.ToDouble(propertyInfo.GetValue(item.ValidationMetrics)));
                        }
                    }
                }
                result.Model = item.Model;
                ShallowExperimentResultsList.Add(result);
                j++;
            }
        }
        public void SaveModel(ShallowExperimentResult experimentResult, string path)
        {
            using FileStream stream = File.Create(path);
            mlContext.Model.Save(experimentResult.Model, data.Schema, stream);
        }
        public void LoadModel(string FilePath)
        {
            if (FilePath.ToLower().Contains(".zip"))
            {
                DataViewSchema modelSchema;
                mlContext.Model.Load(FilePath, out modelSchema);
            }
            else if (FilePath.ToLower().Contains(".onnx"))
            {
                OnnxScoringEstimator estimator = mlContext.Transforms.ApplyOnnxModel(FilePath);
            }
        }

        public void Predict(ITransformer Model)
        {        // Create runtime type from fields and types in a DataViewSchema
            //var runtimeType = ClassFactory.CreateType(dataViewSchema);

            //dynamic dynamicPredictionEngine;
            //var genericPredictionMethod = mlContext.Model.GetType().GetMethod("CreatePredictionEngine", new[] { typeof(ITransformer), typeof(DataViewSchema) });
            //var predictionMethod = genericPredictionMethod.MakeGenericMethod(runtimeType, typeof(PricePrediction));
            //dynamicPredictionEngine = predictionMethod.Invoke(mlContext.Model, new object[] { model, dataViewSchema });
        }
    }
}
