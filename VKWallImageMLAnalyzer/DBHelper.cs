using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VKWallImageMLAnalyzer
{
    class DBHelper
    {

        //Класс для работы с Microsoft SQL Server
        public static void CreateDB()//Создание БД
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = N'VKParsed')" +
                "BEGIN " +
                "CREATE DATABASE VKParsed; " +
                "END;";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void CreateTableUser()//Создание таблицы
        {
            String str;
            SqlConnection myConn2 = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");


            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Users' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE Users (" +
                "Name varchar(50) NULL," +
                "Surname varchar(50) NULL," +
                "Birthday varchar(50) NOT NULL," +
                "id int NOT NULL, " +
                "screen_name varchar(50) NULL, " +
                "Link varchar(50) NOT NULL" +
                ");" +
                " END";


            SqlCommand myCommand = new SqlCommand(str, myConn2);
            try
            {
                myConn2.Open();
                myCommand.ExecuteNonQuery();
                myConn2.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void CreateTableWallUser()//Создание таблицы
        {
            String str;
            SqlConnection myConn2 = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='UsersPostsIMG' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE UsersPostsIMG (" +
                "author_id int NOT NULL, " +
                "post_id int NOT NULL, " +
                "text varchar(max) NULL," +
                "date varchar(50) NOT NULL," +
                "likes int NULL," +
                "reposts int NULL," +
                "image_ID int NULL," +
                "image_path varchar(256) NOT NULL," +
                "label varchar(50) NOT NULL," +
                "probability float NOT NULL" +
                ");" +
                " END";


            SqlCommand myCommand = new SqlCommand(str, myConn2);
            try
            {
                myConn2.Open();
                myCommand.ExecuteNonQuery();
                myConn2.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static void InsertDataUser(string Name, string Surname, string Birthday, int id, string Screen_name, string Link)//Вставка обработанных данных в таблицу пользователей
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; " +
                "INSERT INTO Users (Name, Surname, Birthday, id, screen_name, Link) " +
                "SELECT * FROM (VALUES ( '" + Name + "', '" + Surname + "', '" + Birthday + "', " +
                id + ", '" + Screen_name + "', '" + Link + "'" + ")) " +
                "AS c (Name, Surname, Birthday, id, screen_name, Link) " +
                "WHERE NOT EXISTS (" +
                "SELECT * FROM USERS u " +
                "WHERE " +
                "u.id = c.id);";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static void InsertDataUserWall(List<Item> wall)//Вставка обработанных данных в таблицу
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");


            str = "USE VKParsed;" +
                "INSERT INTO UsersPostsIMG VALUES ";
            for (int i = 0; i < wall.Count; i++)
            {
                if (wall[i].Attachments != null)
                    foreach (Attachment att in wall[i].Attachments)
                    {
                        if (att.Photo != null)
                        {
                            str += "('" + wall[i].Owner_id + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                            wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + att.Photo.Id + "', '" + att.SavedImageName + "', '" + att.Label + "', " + att.Probability.ToString(CultureInfo.InvariantCulture) + "),";
                        }
                    }
                if (wall[i].Copy_history != null)
                    foreach (CopyHistory rep in wall[i].Copy_history)
                    {
                        if (rep.Attachments != null)
                            foreach (Attachment att in rep.Attachments)
                            {
                                if (att.Photo != null)
                                {
                                    str += "('" + wall[i].Owner_id + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                                    wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + att.Photo.Id + "', '" + att.SavedImageName + "', '" + att.Label + "', " + att.Probability.ToString(CultureInfo.InvariantCulture) + "),";
                                }
                            }
                    }
            }
            str = str.Substring(0, str.Length - 1);
            str += ";";



            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        public static void CreateTableCommunity()//Создание таблицы
        {
            String str;
            SqlConnection myConn2 = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Groups' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE Groups (" +
                "Name varchar(50) NULL," +
                "id int NOT NULL, " +
                "screen_name varchar(50) NULL, " +
                "Link varchar(50) NOT NULL" +
                ");" +
                " END";


            SqlCommand myCommand = new SqlCommand(str, myConn2);
            try
            {
                myConn2.Open();
                myCommand.ExecuteNonQuery();
                myConn2.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void CreateTableWallCommunity()//Создание таблицы
        {
            String str;
            SqlConnection myConn2 = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='GroupsPostsIMG' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE GroupsPostsIMG (" +
                "author_id int NOT NULL, " +
                "post_id int NOT NULL, " +
                "text varchar(max) NULL," +
                "date varchar(50) NOT NULL," +
                "likes int NULL," +
                "reposts int NULL," +
                "image_ID int NULL," +
                "image_path varchar(256) NOT NULL," +
                "label varchar(50) NOT NULL," +
                "probability float NOT NULL" +
                ");" +
                " END";


            SqlCommand myCommand = new SqlCommand(str, myConn2);
            try
            {
                myConn2.Open();
                myCommand.ExecuteNonQuery();
                myConn2.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static void InsertDataCommunity(string Name, int id, string Screen_name, string Link)//Вставка обработанных данных в таблицу пользователей
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed;" +
                "INSERT INTO Groups (Name, id, screen_name, Link) " +
                "SELECT * FROM ( VALUES ( '" + Name + "', " +
                id + ", '" + Screen_name + "', '" + Link + "'" + ")) AS c (Name, id, screen_name, Link) " +
                "WHERE NOT EXISTS (" +
                "SELECT * FROM Groups g " +
                "WHERE " +
                "g.id = c.id );";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static void InsertDataCommunityWall(List<Item> wall)//Вставка обработанных данных в таблицу
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");


            str = "USE VKParsed;" +
                "INSERT INTO GroupsPostsIMG VALUES ";
            for (int i = 0; i < wall.Count; i++)
            {
                if (wall[i].Attachments != null)
                    foreach (Attachment att in wall[i].Attachments)
                    {
                        if (att.Photo != null)
                        {
                            str += "('" + wall[i].Owner_id + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                            wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + att.Photo.Id + "', '" + att.SavedImageName + "', '" + att.Label + "', " + att.Probability.ToString(CultureInfo.InvariantCulture) + "),";
                        }
                    }
                if (wall[i].Copy_history != null)
                    foreach (CopyHistory rep in wall[i].Copy_history)
                    {
                        if (rep.Attachments != null)
                            foreach (Attachment att in rep.Attachments)
                            {
                                if (att.Photo != null)
                                {
                                    str += "('" + wall[i].Owner_id + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                                    wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + att.Photo.Id + "', '" + att.SavedImageName + "', '" + att.Label + "', " + att.Probability.ToString(CultureInfo.InvariantCulture) + "),";
                                }
                            }
                    }
            }
            str = str.Substring(0, str.Length - 1);
            str += ";";



            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
