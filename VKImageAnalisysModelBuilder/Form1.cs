using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using System.IO;


namespace VKImageAnalysisModelBuilder
{

    public partial class Form1 : Form
    {
        private static readonly string _predictedLabelColumnName = "PredictedLabel";
        private static readonly string _keyColumnName = "LabelAsKey";
        public Form1()
        {
            InitializeComponent();
        }

        private void Dataset_BTN_Click(object sender, EventArgs e)
        {
            Dataset_FBD.ShowDialog();
            Dataset_TB.Text = Dataset_FBD.SelectedPath;
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
            Test_FBD.ShowDialog();
            Test_TB.Text = Test_FBD.SelectedPath;
        }

        private void Destination_BTN_Click(object sender, EventArgs e)
        {
            Destination_FBD.ShowDialog();
            Destination_TB.Text = Destination_FBD.SelectedPath;
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (Test_TB.Text == "Папка с тестовыми материалами не выбрана")
            {
                MessageBox.Show("Выберите папку с тестовыми материалами!");
                return;
            }
            if (Dataset_TB.Text == "Данные для обучения не выбраны")
            {
                MessageBox.Show("Выберите папку с данными для обучения!");
                return;
            }
            if (Destination_TB.Text == "Папка назначения не выбрана")
            {
                MessageBox.Show("Выберите папку для выгрузки модели!");
                return;
            }
            Log_RTB.Text = "";
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                var imagesFolder = Path.Combine(Dataset_TB.Text);

                var files = Directory.GetFiles(imagesFolder, "*", SearchOption.AllDirectories);

                var context = new MLContext(seed: 0);

                var input = LoadLabeledImagesFromPath(imagesFolder);
                var data = context.Data.LoadFromEnumerable(input);
                data = context.Data.ShuffleRows(data);

                // загружаются изображения и обрабатываются классы
                var images = context.Transforms.Conversion.MapValueToKey(inputColumnName: nameof(Input.Label), outputColumnName: _keyColumnName)
                    .Append(context.Transforms.LoadRawImageBytes(inputColumnName: nameof(Input.ImagePath), outputColumnName: nameof(Input.Image), imageFolder: imagesFolder))
                    .Fit(data).Transform(data);

                var imagesPipeline = context.Transforms.Conversion.MapValueToKey(inputColumnName: nameof(Input.Label), outputColumnName: _keyColumnName)
                    .Append(context.Transforms.LoadRawImageBytes(inputColumnName: nameof(Input.ImagePath), outputColumnName: nameof(Input.Image), imageFolder: imagesFolder));

                // датасет делится на тестовое и обучающее множества
                var trainTestData = context.Data.TrainTestSplit(images, testFraction: 0.2, seed: 1);
                var trainData = trainTestData.TrainSet;
                var testData = trainTestData.TestSet;


                var options = new ImageClassificationTrainer.Options()
                {
                    FeatureColumnName = nameof(Input.Image),
                    LabelColumnName = _keyColumnName,
                    ValidationSet = testData,
                    Arch = ImageClassificationTrainer.Architecture.ResnetV2101,
                    TestOnTrainSet = false
                };

                var pipeline = context.MulticlassClassification.Trainers.ImageClassification(options)
                    .Append(context.Transforms.Conversion.MapKeyToValue(_predictedLabelColumnName));

                Log_RTB.Text += ("Модель создана, начинается обучение...\n");


                var model = pipeline.Fit(trainData);

                Log_RTB.Text += ("Модель обучена, вычисляются характеристики...");

                var predictions = model.Transform(testData);
                var metrics = context.MulticlassClassification.Evaluate(predictions, labelColumnName: _keyColumnName, predictedLabelColumnName: _predictedLabelColumnName);

                Log_RTB.Text += ("\n");
                Log_RTB.Text += ($"Macro accuracy = {metrics.MacroAccuracy:P2}; ");
                Log_RTB.Text += ($"Micro accuracy = {metrics.MicroAccuracy:P2}");
                Log_RTB.Text += (metrics.ConfusionMatrix.GetFormattedConfusionTable());
                Log_RTB.Text += ("\n");


                Log_RTB.Text += ("\n");
                Log_RTB.Text += ("Модель сохраняется...\n");
                context.Model.Save(model, trainData.Schema, Destination_TB.Text + "\\img_model.zip");
                Log_RTB.Text += ("Модель сохранена, начинается тестирование");

                var predictionEngine = context.Model.CreatePredictionEngine<Input, Output>(model);

                var testImagesFolder = Path.Combine(Test_TB.Text);

                var testFiles = Directory.GetFiles(testImagesFolder, "*", SearchOption.AllDirectories);

                var testImages = testFiles.Select(file => new Input
                {
                    ImagePath = file
                });

                Log_RTB.Text += " \n";
                var testImagesData = context.Data.LoadFromEnumerable(testImages);

                var testImageDataView = imagesPipeline.Fit(testImagesData).Transform(testImagesData);

                var predictionst = model.Transform(testImageDataView);

                var testPredictions = context.Data.CreateEnumerable<Output>(predictionst, reuseRowObject: false);


                foreach (var prediction in testPredictions)
                {
                    var labelIndex = prediction.PredictedLabel;

                    Log_RTB.Text += $"Картинка: {Path.GetFileName(prediction.ImagePath)}, Предполагаемая категория: {prediction.PredictedLabel}. {prediction.Score.Max<float>()} \n";

                }
            }, TaskCreationOptions.AttachedToParent);


        }
        private static List<Input> LoadLabeledImagesFromPath(string path)
        {
            var images = new List<Input>();
            var directories = Directory.EnumerateDirectories(path);

            foreach (var directory in directories)
            {
                var files = Directory.EnumerateFiles(directory);

                images.AddRange(files.Select(x => new Input
                {
                    ImagePath = Path.GetFullPath(x),
                    Label = Path.GetFileName(directory)
                }));
            }

            return images;
        }
    }
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
}


