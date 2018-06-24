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
            connString.UserID = "jackie";
            connString.Password = "pupuce1993";
            connString.Server = "127.0.0.1";
            connString.SslMode = MySqlSslMode.None;
            conn = new MySqlConnection(connString.ToString());
        }


        public bool addProject(ProjectModel project)

        {
            // TODO H complete the String to insert project into database
            string qryString = "INSERT INTO " + PROJECT_TABLE_NAME + " (projectid,name, attribute, startdate,enddate,deliverydate,cathegory,description,statut ,semester)" +
                         " VALUES(" + project.Id + project.Name + ", " + project.Startdatum + "," + project.Enddatum + "," + project.Deliverydate + "," + project.Cathegory + "," + project.Description + "," + project.Statut + "," + project.Getsemester + ")";

            return runWriteCommand(qryString);
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
            String cmdString = $"INSERT INTO Test(name, age) VALUES('maFleur', '21')";
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
                conn.Close();
            }
            catch (MySqlException e)
            {
                result = false;
            }
            return result;
        }

        internal bool Cathe(bool choice)
        {
            throw new NotImplementedException();
        }
    }
}
