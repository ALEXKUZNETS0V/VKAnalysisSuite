using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace VKWallParser
{
    public partial class Form1 : Form
    {


        VKAPI _ApiRequest;
        private string[] _Token;  //Токены, использующийся при запросах
        private long _startID; //Первый сканируемый ID
        private long _finishID;
        static public int currentAccount;//Текущий используемый фейк
        public int accountQuantity;//Количество фейков
        public static string outFileTXT = Environment.CurrentDirectory + "\\Анализ по словарям.txt";
        private bool sql;//Переменная отвечает за то, в SQL мы выводим, или в TXT


        static private string FileNameGenXVocab = "";//Файл словаря поколения X
        static private string FileNameGenZVocab = "";//Файл словаря поколения Z
        static public List<string> GenXVocabulary = new List<string>();//Сам словарь X
        static public List<string> GenZVocabulary = new List<string>();//Сам словарь Z



        public Form1()
        {
            InitializeComponent();
        }


        private void Button_GetInformation_Click(object sender, EventArgs e)
        {
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                try
                {
                    if (ResultFormatCB.SelectedItem.ToString() == "SQL")// Проверка формата вывода
                    {
                        if (DeletePreviousResultChB.Checked)
                        {
                            DBHelper.DeleteDB();                            
                        }
                        DBHelper.CreateDB();
                        DBHelper.CreateTable();
                        sql = true;
                    }
                    if (ResultFormatCB.SelectedItem.ToString() == "TXT")
                    {

                        if (DeletePreviousResultChB.Checked)
                        {
                            File.WriteAllText(outFileTXT, "Результат\n");
                        }
                        sql = false;
                    }
                    _startID = int.Parse(Start_ID_TB.Text);
                    _finishID = Finish_ID_TB.Text != "" ? int.Parse(Finish_ID_TB.Text) : _startID;
                    LoadVocabulary(FileNameGenXVocab, GenXVocabulary);
                    LoadVocabulary(FileNameGenZVocab, GenZVocabulary);
                    StreamReader ControlInf = new StreamReader(Environment.CurrentDirectory + "\\UserInf.txt");
                    accountQuantity = int.Parse(ControlInf.ReadLine());
                    _Token = new string[accountQuantity];
                    //Здесь переключаются аккаунты и обрабатываются данные с помощью каждого из них. Сделано это для обхода ограничения API VK в 5000 запросов в сутки
                    for (int currentAccount = 0; currentAccount < accountQuantity; currentAccount++)
                    {
                        _Token[currentAccount] = ControlInf.ReadLine();
                        ControlInf.ReadLine();
                        _ApiRequest = new VKAPI(_Token[currentAccount]);
                        string[] Params = { "photo_max", "bdate" };
                        long _currentID = 0;
                        //Обработка одним аккаунтом. Цикл выполняется 5000 раз из за ограничения API на количество запросов в сутки
                        for (_currentID = _startID; _currentID < _startID + 5000; _currentID++)
                        {
                            Progress_Label.Text = "Обрабатывается ID " + _currentID.ToString();
                            bool _Response = _ApiRequest.GetInformation(_currentID.ToString(), Params, sql);
                            Thread.Sleep(1000);//Поток приостанавливается, чтобы не превысить ограничение API на количество запросов в секунду
                            if (_currentID == _finishID) break;
                        }


                        _startID = _currentID;

                        Progress_Label.Text = "Готово!";
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }, TaskCreationOptions.AttachedToParent);
        }

        //private void Button_GetToken_Click(object sender, EventArgs e)
        //{
        //    accountQuantity = int.Parse(AccountQuantityTB.Text);
        //    File.WriteAllText("UserInf.txt", accountQuantity.ToString() + "\n");
        //    //Форма вызывается ровно столько раз, сколько указано пользователем
        //    for (currentAccount = 0; currentAccount < accountQuantity; currentAccount++)
        //    {
        //        AuthorizationForm GetToken = new AuthorizationForm();
        //        GetToken.ShowDialog();
        //    }
        //    currentAccount = 0;

        //}

        private void GenXVocabBTN_Click(object sender, EventArgs e)//обработка кнопки загрузки словаря X
        {
            openFileDialogGenX.InitialDirectory = Environment.CurrentDirectory + "\\VKWallParser";
            if (openFileDialogGenX.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            FileNameGenXVocab = openFileDialogGenX.FileName;
            GenXVocabTB.Text = FileNameGenXVocab;
        }

        private void GenZVocabBTN_Click(object sender, EventArgs e)//обработка кнопки загрузки словаря Z
        {
            openFileDialogGenZ.InitialDirectory = Environment.CurrentDirectory + "\\VKWallParser";
            if (openFileDialogGenZ.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            FileNameGenZVocab = openFileDialogGenZ.FileName;
            GenZVocabTB.Text = FileNameGenZVocab;
        }

        private void LoadVocabulary(string path, List<string> vocab)//Функция загрузки словаря из файла
        {
            StreamReader sr = new StreamReader(path);
            string str = sr.ReadLine();
            while (str != null)
            {
                string[] words = str.Split();
                foreach (var v in words)
                    vocab.Add(v);
                str = sr.ReadLine();

            }

        }

        //private void Deauthorize_Button_Click(object sender, EventArgs e)
        //{
        //    //Поскольку куки браузера удаляются и так, для выхода требуется только удаление файла с токенами
        //    File.Delete("UserInf.txt");
        //}
    }
}
