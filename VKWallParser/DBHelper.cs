using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VKWallParser
{
    class DBHelper
    {
        //Класс для работы с Microsoft SQL Server
        public static void CreateDB()//Создание БД
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = N'VKParsed')"+
                "BEGIN "+
                "CREATE DATABASE VKParsed; "+
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

        public static void CreateTable()//Создание таблицы
        {
            String str;
            SqlConnection myConn2 = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; " +  "IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='ParsedWallsByDict' AND xtype='U') " +
                "BEGIN " + 
                "CREATE TABLE ParsedWallsByDict (" +
                "Name varchar(50) NULL," +
                "Surname varchar(50) NULL," +
                "Birthday varchar(50) NOT NULL," +
                "Rating int NULL, " +
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

        public static void DeleteDB()//Удаление таблицы из БД
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed; DELETE FROM ParsedWallsByDict ";

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

        public static void InsertData(string Name, string Surname, string Birthday, int Rating, string Link)//Вставка обработанных данных в таблицу
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "USE VKParsed;" +
                "INSERT INTO ParsedWallsByDict VALUES ( '" + Name + "', '" + Surname + "', '" + Birthday + "', " +
                Rating.ToString() + ", '" + Link + "'" + ");";

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
