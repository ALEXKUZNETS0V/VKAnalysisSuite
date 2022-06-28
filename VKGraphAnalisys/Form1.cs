using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VKGraphAnalisys
{
    public partial class Form1 : Form
    {
        static public VKAPI _ApiRequest;
        private string[] _Token;  //Токены, использующийся при запросах
        static public int currentAccount;//Текущий используемый фейк
        public int accountQuantity;//Количество фейков
        public static string outFileTXT = "results.txt";
        static public bool[,] matrix;
        static public bool txt;
        static public List<Item> members = new List<Item>() { new Item() };

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {

                try
                {
                    txt = RatingTXT_CB.Checked;
                    StreamReader ControlInf = new StreamReader(Environment.CurrentDirectory + "\\UserInf.txt");
                    accountQuantity = int.Parse(ControlInf.ReadLine());
                    _Token = new string[accountQuantity];
                    //_Token = new string[accountQuantity];
                    //_Token[0] = ControlInf.ReadLine();
                    //_ApiRequest = new VKAPI(_Token[0]);
                    //_ApiRequest.GetInformationFromGroup(LinkTB.Text);
                    //GraphBuilder.Draw();
                    Progress_LB.Text = "Собираются данные о пользователях";
                    //Здесь переключаются аккаунты и обрабатываются данные с помощью каждого из них. Сделано это для обхода ограничения API VK в 5000 запросов в сутки
                    for (int currentAccount = 0; currentAccount < accountQuantity; currentAccount++)
                    {
                        _Token[currentAccount] = ControlInf.ReadLine();
                        _ApiRequest = new VKAPI(_Token[currentAccount]);
                        _ApiRequest.GetInformationFromGroup(LinkTB.Text, 1000 * currentAccount);
                    }
                    Progress_LB.Text = "Строится граф";
                    GraphBuilder.Draw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }, TaskCreationOptions.AttachedToParent);

        }
    }
}
