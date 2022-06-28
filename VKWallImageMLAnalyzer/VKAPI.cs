using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using xNet;
using System;
using System.Linq;

namespace VKWallImageMLAnalyzer
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

        public Dictionary<string, string> GetInformation(string target)  //Получение заданной информации о пользователе с заданным ID 
        {
            if (target[0] != '-')
            {
                //Получение базовой информации -- имени и фамилии
                HttpRequest GetBasicInfo = new HttpRequest();
                GetBasicInfo.AddUrlParam("user_ids", target);
                GetBasicInfo.AddUrlParam("access_token", _Token);
                GetBasicInfo.AddUrlParam("fields", "bdate,screen_name");
                GetBasicInfo.AddUrlParam("v", "5.131");
                string BasicResult = GetBasicInfo.Get(__VKAPIURL + "users.get").ToString();
                BasicResult = BasicResult.Substring(13, BasicResult.Length - 15);
                Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(BasicResult);
                return Dict;
            }
            else
            {
                //Получение базовой информации -- названия группы
                HttpRequest GetBasicInfo = new HttpRequest();
      
                GetBasicInfo.AddUrlParam("group_ids", target.Substring(1, target.Length - 1));
                GetBasicInfo.AddUrlParam("access_token", _Token);
                GetBasicInfo.AddUrlParam("fields", "screen_name");
                GetBasicInfo.AddUrlParam("v", "5.131");
                string BasicResult = GetBasicInfo.Get(__VKAPIURL + "groups.getById").ToString();
                BasicResult = BasicResult.Substring(13, BasicResult.Length - 15);
                Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(BasicResult);
                return Dict;
            }
        }

        public List<Item> GetWall(string target, int offset)
        {
            HttpRequest GetAdvancedInfo = new HttpRequest();
            if (target.Any(ch => char.IsLetter(ch)))
                GetAdvancedInfo.AddUrlParam("domain", target[0] == '-' ? target.Substring(1, target.Length - 1) : target);
            else
                GetAdvancedInfo.AddUrlParam("owner_id", target);
            GetAdvancedInfo.AddUrlParam("access_token", _Token);
            GetAdvancedInfo.AddUrlParam("count", 100);
            GetAdvancedInfo.AddUrlParam("offset", offset);
            GetAdvancedInfo.AddUrlParam("filter", "all");
            GetAdvancedInfo.AddUrlParam("v", "5.131");
            string AdvancedResult = GetAdvancedInfo.Get(__VKAPIURL + "wall.get").ToString();
            WallRoot Wall = JsonConvert.DeserializeObject<WallRoot>(AdvancedResult);
            if (Wall.Response != null)
                return Wall.Response.Items;
            else return new List<Item>();
        }
    }
}
