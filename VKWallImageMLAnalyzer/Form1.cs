using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace VKWallImageMLAnalyzer
{
    public partial class Form1 : Form
    {
        static string model = "model.zip";
        static string target;
        VKAPI _ApiRequest;
        private string[] _Token;  //Токены, использующийся при запросах


        public Form1()
        {
            InitializeComponent();
        }

        private void SelectModel_BTN_Click(object sender, EventArgs e)
        {
            Model_FD.InitialDirectory = Environment.CurrentDirectory + "\\VKWallMLAnalyzer";
            if (Model_FD.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            model = Model_FD.FileName;
            Model_TB.Text = model;
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (Model_TB.Text == "")
            {
                MessageBox.Show("Выберите модель!");
                return;
            }
            if (Target_TB.Text == "Введите идентификатор цели")
            {
                MessageBox.Show("Выберите цель!");
                return;
            }
            if (Target_CB.Text == "Не выбрано")
            {
                MessageBox.Show("Выберите тип цели!");
                return;
            }
            if (OutputFormat_CHL.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите тип вывода!");
                return;
            }
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                target = Target_CB.Text == "Пользователь" ? Target_TB.Text : "-" + Target_TB.Text;



                Dictionary<string, string> basicInfo = new Dictionary<string, string>();
                List<Item> wall = new List<Item>();
                StreamReader ControlInf = new StreamReader(Environment.CurrentDirectory + "\\UserInf.txt");
                int accountQuantity = int.Parse(ControlInf.ReadLine());
                _Token = new string[accountQuantity];

                Progress_LB.Text = "Скачиваются данные стены";
                for (int currentAccount = 0; currentAccount < accountQuantity; currentAccount++)
                {
                    _Token[currentAccount] = ControlInf.ReadLine();
                    _ApiRequest = new VKAPI(_Token[currentAccount]);
                    basicInfo = _ApiRequest.GetInformation(target);
                    wall.AddRange(_ApiRequest.GetWall(target, 100 * currentAccount));
                    ControlInf.ReadLine();
                }
                Progress_LB.Text = "Анализ данных с помощью модели МО";
                MLPredictionEngine.PredictWall(wall, model);


                if (OutputFormat_CHL.CheckedItems.Contains("CSV"))
                {
                    Progress_LB.Text = "Выгрузка результатов в CSV";
                    Program.PrintResultCSV(basicInfo, wall, target);
                }
                if (OutputFormat_CHL.CheckedItems.Contains("SQL"))
                {
                    Progress_LB.Text = "Выгрузка результатов в базу данных";
                    Program.PrintResultSQL(basicInfo, wall, target);
                }
                Progress_LB.Text = ("Готово!");
            }, TaskCreationOptions.AttachedToParent);
        }


    }
}
