using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    class ShallowExperimentResult
    {
        public ShallowExperimentResult()
        {
            scoreList = new List<ShallowExperimentScore>();
        }
        public int Index { get; set; }
        public ITransformer Model { internal get; set; }
        public string Algorithm { get; set; }
        public bool IsBest { get; set; }
        private List<ShallowExperimentScore> scoreList;

        public ShallowExperimentScore[] Scores
        {
            get { return scoreList.ToArray(); }
        }
        public void AddScore(string name, double score)
        {
            scoreList.Add(new ShallowExperimentScore()
            {
                Name = name,
                Score = score
            });
        }
        public ITransformer GetModel()
        {
            return Model;
        }
    }
}
