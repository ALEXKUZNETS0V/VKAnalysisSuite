using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VKWallMLAnalyzer
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

            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='UsersPosts' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE UsersPosts (" +
                "author_id int NOT NULL, " +
                "post_id int NOT NULL, " +
                "text varchar(max) NULL," +
                "date varchar(50) NOT NULL," +
                "likes int NULL," +
                "reposts int NULL," +
                "prediction varchar(50) NOT NULL," +
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
                "INSERT INTO UsersPosts VALUES ";
            for (int i = 0; i < wall.Count; i++)
            {
                str += "('" + wall[i].Owner_id + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + wall[i].Prediction + "', " + wall[i].Probability.ToString(CultureInfo.InvariantCulture) + "),";
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

            str = "USE VKParsed; " + "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='GroupsPosts' AND xtype='U') " +
                "BEGIN " +
                "CREATE TABLE GroupsPosts (" +
                "author_id int NOT NULL, " +
                "post_id int NOT NULL, " +
                "text varchar(max) NULL," +
                "date varchar(50) NOT NULL," +
                "likes int NULL," +
                "reposts int NULL," +
                "prediction varchar(50) NOT NULL," +
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
                "INSERT INTO GroupsPosts VALUES ";
            for (int i = 0; i < wall.Count; i++)
            {
                str += "('" + (-wall[i].Owner_id) + "', '" + wall[i].Id + "', '" + wall[i].Text + "', '" +
                wall[i].Date + "', '" + wall[i].Likes.Count + "', '" + wall[i].Reposts.Count + "', '" + wall[i].Prediction + "', " + wall[i].Probability.ToString(CultureInfo.InvariantCulture) + "),";
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


        public static List<string[]> GetInfoByKeywords(string ID, string keywords, string type)//Вставка обработанных данных в таблицу
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            myConn.Open();
            string idcondition;
            string[] keywordcondition;

            if (ID.Any(ch => char.IsLetter(ch)))
                idcondition = "Users.screen_name = '" + ID + "'";
            else
                idcondition = "Users.id = '" + ID + "'";

            keywordcondition = keywords.Split(',');
            keywordcondition[0] = " AND Posts.text LIKE '%" + keywordcondition[0] + "%'";
            if (keywordcondition.Count() > 1)
                for (int i = 1; i < keywordcondition.Count(); i++)
                    keywordcondition[i] = "or Posts.text LIKE '%" + keywordcondition[i] + "%' ";

            if (type == "Пользователь")
                str = "USE VKParsed;" +
                "SELECT Users.name + ' ' + Users.Surname as name, Users.link, Users.id, Posts.post_id, Posts.text, Posts.likes, Posts.reposts,  Posts.prediction, Posts.Probability" +
                " FROM Users JOIN UsersPosts Posts on Users.id = Posts.author_id" +
                " WHERE" +
                " (" + idcondition + ")" +
                " AND Posts.text LIKE '%" + keywords + "%'";
            else
                str = "USE VKParsed;" +
                "SELECT Groups.name, Groups.link, Groups.id, Posts.post_id, Posts.text, Posts.likes, Posts.reposts,  Posts.prediction, Posts.Probability" +
                " FROM Groups RIGHT JOIN GroupsPosts Posts on Groups.id = GroupsPosts.author_id" +
                " WHERE" +
                " (" + idcondition + ")" +
                " AND Posts.text LIKE '%" + keywords + "%'";

            foreach (string keyword in keywordcondition)
                str += keyword;


            SqlCommand command = new SqlCommand(str, myConn);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
            }

            reader.Close();

            myConn.Close();
            return data;

        }
    }
}
