using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VKProjectLauncher
{
    public partial class LauncherForm : Form
    {
        static public int currentAccount;//Текущий используемый фейк
        public int accountQuantity;//Количество фейков
        public LauncherForm()
        {
            InitializeComponent();
        }

        private void GetTokenBTN_Click(object sender, EventArgs e)
        {
            accountQuantity = int.Parse(AccountQuantityTB.Text);
            File.WriteAllText("UserInf.txt", accountQuantity.ToString() + "\n");
            //Форма вызывается ровно столько раз, сколько указано пользователем
            for (currentAccount = 0; currentAccount < accountQuantity; currentAccount++)
            {
                AuthorizationForm GetToken = new AuthorizationForm();
                GetToken.ShowDialog();
            }
            currentAccount = 0;
        }

        private void VKWallParser_Click(object sender, EventArgs e)
        {
            Process WallParsing = new Process();
            WallParsing.StartInfo.FileName = Environment.CurrentDirectory + "\\VKWallParser\\VKWallParser.exe";
            WallParsing.Start();
            this.Opacity = 0;
            WallParsing.WaitForExit();
            this.Opacity = 100;
        }

        private void DeauthorizeBTN_Click(object sender, EventArgs e)
        {
            //Поскольку куки браузера удаляются и так, для выхода требуется только удаление файла с токенами
            File.Delete("UserInf.txt");
        }

        private void GraphingAnalisysBTN_Click(object sender, EventArgs e)
        {
            Process GraphingAnalisys = new Process();
            GraphingAnalisys.StartInfo.FileName = Environment.CurrentDirectory + "\\VKGraphAnalisys\\VKGraphAnalisys.exe";
            GraphingAnalisys.Start();
            this.Opacity = 0;
            GraphingAnalisys.WaitForExit();
            this.Opacity = 100;
        }

        private void MLTextAnalisysBTN_Click(object sender, EventArgs e)
        {
            Process MLAnalisys = new Process();
            MLAnalisys.StartInfo.FileName = Environment.CurrentDirectory + "\\VKWallMLAnalyzer\\VKWallMLAnalyzer.exe";
            MLAnalisys.Start();
            this.Opacity = 0;
            MLAnalisys.WaitForExit();
            this.Opacity = 100;
        }

        private void MLImageAnalisysBTN_Click(object sender, EventArgs e)
        {
            Process MLAnalisys = new Process();
            MLAnalisys.StartInfo.FileName = Environment.CurrentDirectory + "\\VKWallImageMLAnalyzer\\VKWallImageMLAnalyzer.exe";
            MLAnalisys.Start();
            this.Opacity = 0;
            MLAnalisys.WaitForExit();
            this.Opacity = 100;
        }
    }
}
