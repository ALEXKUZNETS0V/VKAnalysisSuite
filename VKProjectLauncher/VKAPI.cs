using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKProjectLauncher
{
    class VKAPI
    {
        //Класс для работы с VK API
        public const string __APPID = "7867743";  //ID приложения
        private const string __VKAPIURL = "https://api.vk.com/method/";  //Ссылка для запросов
        private string _Token;  //Токен, использующийся при запросах

        public VKAPI(string AccessToken)
        {
            _Token = AccessToken;

        }
    }
}
