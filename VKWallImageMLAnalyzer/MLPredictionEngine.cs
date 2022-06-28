using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Imaging;
using xNet;

namespace VKWallImageMLAnalyzer
{
    public class Input
    {
        public byte[] Image;
        public string ImagePath;
        public string Label;
    }

    public class Output
    {
        public string ImagePath;
        public float[] Score;
        public string PredictedLabel;
    }
    class MLPredictionEngine
    {
        private string[] _labels;
        private static string[] GetOrderedLabels(DataViewSchema schema)
        {
            var buffer = new VBuffer<ReadOnlyMemory<char>>();
            schema.GetColumnOrNull("Score").Value.GetSlotNames(ref buffer);
            return buffer.DenseValues().Select(x => x.ToString()).ToArray();
        }
        static public void PredictWall(List<Item> wall, string modelpath)
        {
            var context = new MLContext(seed: 0);
            var model = context.Model.Load(modelpath, out DataViewSchema schema);
            var _predictor = context.Model.CreatePredictionEngine<Input, Output>(model);
            var _labels = GetOrderedLabels(_predictor.OutputSchema);

            foreach(Item rec in wall)
            {
                if (rec.Attachments != null)
                {
                    foreach(Attachment att in rec.Attachments)
                    {
                        if(att.Photo != null)
                        {
                            
                            string name = Environment.CurrentDirectory + "\\Saved Images\\" + rec.Owner_id.ToString() + "." + rec.Id.ToString() +
                                "." + att.Photo.Id.ToString() + ".jpg";
                            int hiresindex = att.Photo.Sizes.Count - 1;
                            using (var request = new HttpRequest())
                            {
                                request.Get(att.Photo.Sizes[hiresindex].Url).ToFile(name);
                                request.Dispose();
                            }

                            
                            var input = new Input();
                            input.ImagePath = name;
                            System.Drawing.Image img = System.Drawing.Image.FromFile(name);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                input.Image = ms.ToArray();
                            }

                            // Use ML.NET to classify the image
                            var prediction = _predictor.Predict(input);
                            var label = prediction.PredictedLabel;

                            att.SavedImageName = name;
                            att.Label = label;
                            att.Probability = prediction.Score.Max<float>();
                            _predictor = context.Model.CreatePredictionEngine<Input, Output>(model);
                        }
                    }
                }
                if (rec.Copy_history != null)
                {
                    foreach(CopyHistory rep in rec.Copy_history)
                    {
                        if(rep.Attachments != null)
                        foreach (Attachment att in rep.Attachments)
                        {
                            if (att.Photo != null)
                            {
                                string name = Environment.CurrentDirectory + "\\Saved Images\\" + "REPOST FILE IN" + rec.Owner_id.ToString() + "." + rec.Id.ToString() +
                                    "." + att.Photo.Id.ToString() + ".jpg";
                                int hiresindex = att.Photo.Sizes.Count - 1;
                                using (var request = new HttpRequest())
                                {
                                    request.Get(att.Photo.Sizes[hiresindex].Url).ToFile(name);
                                    request.Dispose();
                                }

                                Input image = new Input();
                                image.ImagePath = name;
                                var prediction = _predictor.Predict(image);
                                var label = prediction.PredictedLabel;
                                att.SavedImageName = name;
                                att.Label = label;
                                att.Probability = prediction.Score.Max<float>();
                                _predictor = context.Model.CreatePredictionEngine<Input, Output>(model);
                            }
                        }
                    }
                }
            }
        }
    }
}
