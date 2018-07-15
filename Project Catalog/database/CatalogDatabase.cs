using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using Project_Catalog.Models;

namespace Project_cathalogue.Models
{
    public class CatalogDataBase
    {
        const string PROJECT_TABLE_NAME = "project";
        const string Category_TABLE_NAME = "category";
        const string COURSE_TABLE_NAME = "course";
        const string STATUS_TABLE_NAME = "status";

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

        public bool addProject(ProjectModel p)
        {
            //string qryStr = $"INSERT INTO " + PROJECT_TABLE_NAME + " (name, status, start, end, description," +
            //   "cathegory_id, course_id)" + 
            //   generateValuesString(new string[]{ p.Name, p.Status, p.getStartDateString(),
            //       p.getEndDateString(), p.Description}) + ";";

            string qryStr = $"INSERT INTO " + PROJECT_TABLE_NAME + " (name, status, start, end, description) " + 
               generateValuesString(new string[]{ p.Name, p.Status, p.getStartDateString(),
                   p.getEndDateString(), p.Description}) + ";";
            // TODO Next insert a complete Project incl. Cathegory and Course (Foreign Keys)


            return runWriteCommand(qryStr);
        }

        public List<SelectBoxModel> getCourses()
        {
            List<SelectBoxModel> result = new List<Project_Catalog.Models.SelectBoxModel>();
            string qryString = $"SELECT * FROM " + COURSE_TABLE_NAME;
            MySqlCommand cmd = new MySqlCommand(qryString, conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new SelectBoxModel()
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString()
                    });
                }
            }
            catch (MySqlException e)
            {

            }
            conn.Close();
            return result;
        }

        public List<SelectBoxModel> getCategories()
        {
            List<SelectBoxModel> result = new List<Project_Catalog.Models.SelectBoxModel>();
            string qryString = $"SELECT * FROM " + Category_TABLE_NAME;
            MySqlCommand cmd = new MySqlCommand(qryString, conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new SelectBoxModel() {
                        Id = (int) reader["id"],
                        Name = reader["name"].ToString()
                    });
                }
            }
            catch (MySqlException e)
            {

            }
            conn.Close();
            return result;
        }

        public List<Object> runReadCommand<T>(string cmdString)
        {
            List<Object> result = null;

            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            try
            {
                openConnection();
                var reader = cmd.ExecuteReader();
                while( reader.Read() )
                {
                    // TODO Pending...
                }
            } catch (MySqlException e)
            {

            }
            return result;
        }

        private bool runWriteCommand(string cmdString)
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

        private void openConnection()
        {
            if( conn.State != System.Data.ConnectionState.Open )
            {
                conn.Open();
            } else
            {
                throw new Exception("Could not open DB Connection !");
            }
            
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
