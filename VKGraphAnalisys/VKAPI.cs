using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using xNet;


namespace VKGraphAnalisys
{
    public class VKAPI
    {
        //Класс для работы с VK API
        public const string __APPID = "7867743";  //ID приложения
        private const string __VKAPIURL = "https://api.vk.com/method/";  //Ссылка для запросов
        private string _Token;  //Токен, использующийся при запросах

        public VKAPI(string AccessToken)
        {
            _Token = AccessToken;

        }

        public void GetInformationFromGroup(string groupID, int offset)  //Получение информации о членах группы и передача на дальнейшую обработку
        {
            HttpRequest GetBasicInfo = new HttpRequest();
            GetBasicInfo.AddUrlParam("group_id", groupID);
            GetBasicInfo.AddUrlParam("access_token", _Token);
            GetBasicInfo.AddUrlParam("offset", offset);
            GetBasicInfo.AddUrlParam("fields", "city");
            GetBasicInfo.AddUrlParam("v", "5.131");
            string BasicResult = GetBasicInfo.Get(__VKAPIURL + "groups.getMembers").ToString();
            GroupRoot group = JsonConvert.DeserializeObject<GroupRoot>(BasicResult);
            Thread.Sleep(300);
            Form1.members.AddRange(group.Response.Items);
        }

        public List<int> GetFriendList(int user)  //Получение информации о списке друзей
        {
            Thread.Sleep(250);
            HttpRequest GetBasicInfo = new HttpRequest();
            GetBasicInfo.AddUrlParam("user_id", user);
            GetBasicInfo.AddUrlParam("access_token", _Token);
            GetBasicInfo.AddUrlParam("v", "5.131");
            string BasicResult = GetBasicInfo.Get(__VKAPIURL + "friends.get").ToString();
            if (BasicResult.Contains("error_code"))
            {
                return new List<int>();
            }

            FriendListRoot friends = JsonConvert.DeserializeObject<FriendListRoot>(BasicResult);
            return friends.Response.Items;
        }
    }
}