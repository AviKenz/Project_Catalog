using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Project_cathalogue.Models
{
    public class CatalogDataBase
    {
        const string PROJECT_TABLE_NAME = "project";

        private static CatalogDataBase instance;

        private MySqlConnection conn;

        private CatalogDataBase()
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Database = "project_catalog";
            connString.UserID = "root";
            connString.Server = "127.0.0.1";
            connString.SslMode = MySqlSslMode.None;
            conn = new MySqlConnection(connString.ToString());
        }

        public static CatalogDataBase getDatabase()
        {
            if (instance == null)
            {
                instance = new CatalogDataBase();
            }

            return instance;
        }

        public bool dataBaseTest()
        {
            String cmdString = $"INSERT INTO test(name, age) VALUES('maFleur', '21')";
            return runWriteCommand(cmdString);
        }

        private bool runWriteCommand(string   cmdString)
        {
            bool result = true;
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
            }
            catch (MySqlException e)
            {
                result = false;
                
            }
            conn.Close();
            return result;
        }

        internal bool Cathe(bool choice)
        {
            throw new NotImplementedException();
        }
    }
}
