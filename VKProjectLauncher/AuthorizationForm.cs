using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VKProjectLauncher
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            WinInetHelper.SupressCookiePersist();
            GetToken.DocumentCompleted += GetToken_DocumentCompleted;
            GetToken.Navigate("https://oauth.vk.com/authorize?client_id=" + VKAPI.__APPID + "&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=offline&response_type=token&v=5.131");
        }
        private void GetToken_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (GetToken.Url.ToString().IndexOf("access_token=") != -1) //Внесение полученного токена в файл
            {
                char[] Symbols = { '=', '&' };
                string[] URL = GetToken.Url.ToString().Split(Symbols);
                File.AppendAllText("UserInf.txt", URL[1] + "\n");
                File.AppendAllText("UserInf.txt", URL[5] + "\n");
                this.Visible = false;
                WinInetHelper.EndBrowserSession();//Завершение сессии браузера необходимо для возможности получениия токена несколькими аккаунтами


            }
        }
    }
}
