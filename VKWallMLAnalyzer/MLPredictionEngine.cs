using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;


namespace VKWallMLAnalyzer
{
    public class Input
    {
        [LoadColumn(0)]
        public string SentimentText;

        [LoadColumn(1), ColumnName("Label")]
        public int Sentiment;
    }

    public class Output
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
    }
    class MLPredictionEngine
    {
        static public void PredictWall (List<Item> wall, string model)
        {
            var context = new MLContext(seed: 0);


            DataViewSchema modelSchema;
            ITransformer trainedModel = context.Model.Load(model, out modelSchema);
            var predictor = context.Model.CreatePredictionEngine<Input, Output>(trainedModel);

            for (int i = 0; i < wall.Count; i++)
            {
                
                string inputst = wall[i].Text;
                if (wall[i].Copy_history != null)
                {
                    for (int j = 0; j < wall[i].Copy_history.Count; j++) 
                    {
                        inputst += "<" + wall[i].Copy_history[j].Text + "> \n";
                        wall[i].Text += "<" + wall[i].Copy_history[j].Text + "> \n";
                    }
                }
                var input = new Input { SentimentText = inputst };
                var prediction = predictor.Predict(input);
                wall[i].Probability = prediction.Probability > 0.5 ? prediction.Probability : 1 - prediction.Probability;
                wall[i].Prediction = ((prediction.Prediction) ? "Positive" : "Negative");

            }


        }
    }
}
