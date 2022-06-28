using Newtonsoft.Json;
using System.Collections.Generic;


namespace VKWallParser
{
    class WallJsonProcess
    {
        //Этот класс предназначен для получения на основе JSON файла стены пользователя конкретного рейтинга
        static public int ProcessJson(string JsonArg)
        {
            int rating = 0;
            WallRoot Wall = JsonConvert.DeserializeObject<WallRoot>(JsonArg);
            if(Wall.Response != null)
                rating = ProcessWall(Wall.Response.Items);
            return rating;
        }

        static private int ProcessWall(List<Item> Wall)//Вычисление рейтинга
        {
            int Res = 0;
            foreach (Item e in Wall)
            {
                int Li = e.Likes.Count;
                int Ei = e.Reposts.Count;
                int Qi = EvaluateQ(e); 
                Res += Qi*(Li + Ei);
            }

            return Res;
        }
        static private int EvaluateQ(Item post)//Коэффициент Q, зависящий от текстов записей, вычисляется отдельным методом
        {
            bool genXApproved = false;
            bool genZApproved = false;
            for(int i = 0; i< Form1.GenXVocabulary.Count; i++)
                if(post.Text.Contains(Form1.GenXVocabulary[i]))
                {
                    genXApproved = true;
                    break;
                }
            for (int i = 0; i < Form1.GenZVocabulary.Count; i++)
                if (post.Text.Contains(Form1.GenZVocabulary[i]))
                {
                    genZApproved = true;
                    break;
                }
            if ((genXApproved && genZApproved) || (!genZApproved && !genXApproved)) return 0;
            if (genXApproved) return -1;
            if (genZApproved) return 1;
            else return 0;
        }
    }
}
