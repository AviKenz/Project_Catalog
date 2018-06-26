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

        public string addProject(ProjectModel p)
        {
            string qryStr = $"INSERT INTO " + PROJECT_TABLE_NAME + " (name, status, start, end, description," +
                "cathegory_id, course_id)" + 
                generateValuesString(new string[]{ p.Name, p.Status, p.getStartDateString(),
                    p.getEndDateString(), p.Description}) + ";";
            // TODO NEXT link selectbox selection with model

            return qryStr;
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

        private string generateValuesString(string[] values)
        {
            string result = "VALUES(";
            bool first = true;
            int len = values.Count();
            for (int i=0; i<len; i++)
            {
                if( first )
                {
                    result += "'" + values.ElementAt(i) + "'";
                    first = false;
                } else
                {
                    result += ", '" + values.ElementAt(i) + "'";
                }
                
            }
            result += ")";
            return result;
        }

        public bool dataBaseTest()
        {
            String cmdString = $"INSERT INTO test(name, age) VALUES('maFleur', '21')";
            return runWriteCommand(cmdString);
        }

        public bool projectTableTest()
        {
            string cmdString = $"INSERT INTO " + PROJECT_TABLE_NAME + "(name, status, start, end, description, cathegory_id, course_id) VALUES ('projekt1', 'open', '2018-06-21', '2018-07-20', 'desc', '1', '1')";
            return runWriteCommand(cmdString);
        }
    }
}
