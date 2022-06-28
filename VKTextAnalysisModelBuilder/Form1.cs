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

namespace VKTextAnalysisModel
{

    public partial class Form1 : Form
    {
        string FileNameDS = "dataset.csv";
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (DSPath_TB.Text == "Данные для обучения не выбраны")
            {
                MessageBox.Show("Выберите папку с данными для обучения!");
                return;
            }
            if (OutputFolder_TB.Text == "Папка назначения не выбрана")
            {
                MessageBox.Show("Выберите папку для выгрузки модели!");
                return;
            }
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                var context = new MLContext(seed: 0);

                
                var data = context.Data.LoadFromTextFile<Input>(FileNameDS, hasHeader: false, separatorChar: '\t', allowQuoting: true);
                Log_RTB.Text = ("Данные загружены \n");

                
                var trainTestData = context.Data.TrainTestSplit(data, testFraction: 0.2, seed: 0);
                var trainData = trainTestData.TrainSet;
                var testData = trainTestData.TestSet;
                Log_RTB.Text += ("Данные разбиты на тестовое и тренировочное множества\n");

                
                var pipeline = context.Transforms.Expression("Label", "(x) => x == 1 ? true : false", "Label")
                    .Append(context.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: "SentimentText"))
                    .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression());
                Log_RTB.Text += ("Модель собрана, начинается обучение\n");
                var model = pipeline.Fit(data);
                Log_RTB.Text += ("Обучение закончено, вычисляются характеристики\n");

                
                var predictions = model.Transform(data);
                var metrics = context.BinaryClassification.Evaluate(predictions, "Label");

                Log_RTB.Text += ("\n");
                Log_RTB.Text += ($"Точность: {metrics.Accuracy:P2}\n");
                Log_RTB.Text += ($"AUC: {metrics.AreaUnderPrecisionRecallCurve:P2}\n");
                Log_RTB.Text += ($"F1: {metrics.F1Score:P2}\n");
                Log_RTB.Text += ("\n");

                
                Log_RTB.Text += ("Начало перекрестной проверки\n");
                var scores = context.BinaryClassification.CrossValidate(data, pipeline, numberOfFolds: 5);
                var mean = scores.Average(x => x.Metrics.F1Score);
                Log_RTB.Text += ($"Среднее F1 после перекрестной проверки: {mean:P2}\n");

                Log_RTB.Text += ("Сохранение модели\n");
                context.Model.Save(model, data.Schema, OutputFolder_TB.Text + "\\model.zip");
                Log_RTB.Text += ("Модель обучена и сохранена\n");
            }, TaskCreationOptions.AttachedToParent);

        }

        private void GetDS_BTN_Click(object sender, EventArgs e)
        {
            openFileDialogDS.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialogDS.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            FileNameDS = openFileDialogDS.FileName;
            DSPath_TB.Text = FileNameDS;
        }

        private void OutputDialog_BTN_Click(object sender, EventArgs e)
        {
            OutputFolderDialog.ShowDialog();
            OutputFolder_TB.Text = OutputFolderDialog.SelectedPath;
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
            var context = new MLContext(seed: 0);


            DataViewSchema modelSchema;
            ITransformer trainedModel = context.Model.Load(OutputFolder_TB.Text + "\\model.zip", out modelSchema);
            var predictor = context.Model.CreatePredictionEngine<Input, Output>(trainedModel);

            var input = new Input { SentimentText = Test_TB.Text };
            var prediction = predictor.Predict(input);
            MessageBox.Show($"Выражение: {Test_TB.Text}\n" +
                $"Вероятность: {(prediction.Probability > 0.5 ? prediction.Probability : 1 - prediction.Probability )}\n" +
                $"Вывод: {((prediction.Prediction) ? "Positive" : "Negative")}");

        }
    }
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
}
