using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace VKWallImageMLAnalyzer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static public void PrintResultCSV(Dictionary<string, string> basicInfo, List<Item> wall, string target)
        {
            using (StreamWriter streamReader = new StreamWriter(Environment.CurrentDirectory + "\\Отчет по " + target + " от "
                    + DateTime.Today.ToString("yyyy-MM-dd") + ".csv"))
            {
                using (CsvWriter csvWriter = new CsvWriter(streamReader, CultureInfo.InvariantCulture))
                {
                    string inf = "";
                    if (target[0] != '-')
                        inf = basicInfo["first_name"] + " " + basicInfo["last_name"];
                    else
                        inf = basicInfo["name"];
                    // записываем данные в csv файл
                    csvWriter.WriteField("Отчет по " + inf + " от " + DateTime.Today.ToString("yyyy-MM-dd"));
                    csvWriter.NextRecord();
                    csvWriter.WriteField("ID автора");
                    csvWriter.WriteField("ID записи");
                    csvWriter.WriteField("Текст");
                    csvWriter.WriteField("Дата публикации");
                    csvWriter.WriteField("Количество лайков");
                    csvWriter.WriteField("Количество репостов");
                    csvWriter.WriteField("ID изображения");
                    csvWriter.WriteField("Путь к сохраненному файлу");
                    csvWriter.WriteField("Класс");
                    csvWriter.WriteField("Вероятность");
                    csvWriter.NextRecord();

                    //csvWriter.WriteRecords(wall);

                    foreach (var record in wall)
                    {
                        if(record.Attachments != null)
                        foreach (Attachment att in record.Attachments)
                        {
                            if (att.Photo != null)
                            {
                                csvWriter.WriteField(Math.Abs(record.Owner_id));
                                csvWriter.WriteField(record.Id);
                                csvWriter.WriteField(record.Text);
                                csvWriter.WriteField(record.Date);
                                csvWriter.WriteField(record.Likes.Count);
                                csvWriter.WriteField(record.Reposts.Count);
                                csvWriter.WriteField(att.Photo.Id);
                                csvWriter.WriteField(att.SavedImageName);
                                csvWriter.WriteField(att.Label);
                                csvWriter.WriteField(att.Probability);
                                csvWriter.NextRecord();
                            }
                        }
                    }
                }
            }
        }

        static public void PrintResultSQL(Dictionary<string, string> basicInfo, List<Item> wall, string target)
        {
            DBHelper.CreateDB();
            if (target[0] != '-')
            {

                DBHelper.CreateTableUser();
                DBHelper.CreateTableWallUser();
                DBHelper.InsertDataUser(basicInfo["first_name"], basicInfo["last_name"], basicInfo["bdate"],
                    int.Parse(basicInfo["id"]), basicInfo["screen_name"], "https://vk.com/id" + basicInfo["id"]);
                DBHelper.InsertDataUserWall(wall);
            }
            else
            {
                DBHelper.CreateTableCommunity();
                DBHelper.CreateTableWallCommunity();
                DBHelper.InsertDataCommunity(basicInfo["name"],
                    int.Parse(basicInfo["id"]), basicInfo["screen_name"], "https://vk.com/club" + basicInfo["id"]);
                DBHelper.InsertDataCommunityWall(wall);
            }
        }
    }
}
