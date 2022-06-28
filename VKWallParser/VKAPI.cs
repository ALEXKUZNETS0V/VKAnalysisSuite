using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using xNet;
using System;


namespace VKWallParser
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

        public bool GetInformation(string UserId, string[] Fields, bool sql)  //Получение заданной информации о пользователе с заданным ID 
        {

            //Получение базовой информации -- имени и фамилии
            HttpRequest GetBasicInfo = new HttpRequest();
            GetBasicInfo.AddUrlParam("user_ids", UserId);
            GetBasicInfo.AddUrlParam("access_token", _Token);
            GetBasicInfo.AddUrlParam("v", "5.131");
            string Params = "";
            foreach (string i in Fields)
            {
                Params += i + ",";
            }
            Params = Params.Remove(Params.Length - 1);
            GetBasicInfo.AddUrlParam("fields", Params);
            string BasicResult = GetBasicInfo.Get(__VKAPIURL + "users.get").ToString();
            BasicResult = BasicResult.Substring(13, BasicResult.Length - 15);
            Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(BasicResult);


            //Получение стены
            HttpRequest GetAdvancedInfo = new HttpRequest();
            GetAdvancedInfo.AddUrlParam("owner_id", UserId);
            GetAdvancedInfo.AddUrlParam("access_token", _Token);
            GetAdvancedInfo.AddUrlParam("count", 100);
            GetAdvancedInfo.AddUrlParam("filter", "all");
            GetAdvancedInfo.AddUrlParam("v", "5.131");
            string AdvancedResult = GetAdvancedInfo.Get(__VKAPIURL + "wall.get").ToString();
            int Rating = WallJsonProcess.ProcessJson(AdvancedResult);

            //Вывод информации сразу в текстовый файл либо в БД
            if (sql)
            {

                if (Dict.ContainsKey("bdate"))
                    DBHelper.InsertData(Dict["first_name"], Dict["last_name"], Dict["bdate"], Rating, "https://vk.com/id" + Dict["id"]);
                else
                    DBHelper.InsertData(Dict["first_name"], Dict["last_name"], "Дата рождения скрыта", Rating, "https://vk.com/id" + Dict["id"]);
            }
            else
            {
                if (Dict.ContainsKey("bdate"))
                    File.AppendAllText(Form1.outFileTXT, Dict["first_name"] + " " + Dict["last_name"] + " " + Dict["bdate"] + " " + Rating.ToString() + " " + "https://vk.com/id" + Dict["id"] + "\n");
                else
                    File.AppendAllText(Form1.outFileTXT, Dict["first_name"] + " " + Dict["last_name"] + " " + "Дата рождения скрыта" + " " + Rating.ToString() + " " + "https://vk.com/id" + Dict["id"] + "\n");
            }
            return (Dict != null);
        }
    }
}