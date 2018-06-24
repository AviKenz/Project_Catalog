using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_cathalogue.Models;

namespace Project_cathalogue.Models
{
    public class ProjectModel
    {

        public ProjectModel()
        {

        }

        public DateTime Startdatum { get; set; }
        public DateTime Enddatum { get; set; }
        public DateTime Date

        {
            get
            {
                DateTime now = DateTime.Now;
                if (Startdatum.Date <= Enddatum.Date)
                {
                    now = DateTime.Now;
                }
                return now;
            }
            set
            {
                Enddatum = value;
            }
        }

        public string Description { get; set; }
        public DateTime Deliverydate { get; set; }
        
        
        public string  Cathegory { get; set; }
       
        public string Course { get; set; }
        public List<string> Statut { get; set; }


        private string semester;
        public string Getsemester
        {
            get
            {

                if ((DateTime.Compare(Startdatum, new DateTime(2018, 04, 01)) < 0) && (DateTime.Compare(Enddatum, new DateTime(2018, 09, 30)) > 0))
                {
                    semester = "SS";
                    return semester;
                }
                else
                {

                    return "WS";
                }


            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}