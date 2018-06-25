using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_cathalogue.Models;

namespace Project_cathalogue.Models
{
    public class ProjectModel
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

        public ProjectModel()
        {

        }

        public string toString()
        {
            string result = "";
            result += "Project Name: " + Name + "<br>";
            result += "Project Status: " + Status + "<br>";
            result += "Project Start: " + toIsoStdDate(Start) + "<br>";
            result += "Project End: " + toIsoStdDate(End) + "<br>";
            result += "Project description: " + Description + "<br>";
            return result;
        }

        public string getStartDateString()
        {
            return toIsoStdDate(Start);
        }

        public string getEndDateString()
        {
            return toIsoStdDate(End);
        }

        private string toIsoStdDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        private List<string> generateTagFromString(string s)
        {
            List<string> result = new List<string>();
            foreach(string item in s.Split(' '))
            {
                result.Add(item);
            }
            return result;
        }
    }
}