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
            result += "Project Name: " + Name + "\n";
            result += "Project Status: " + Status + "\n";
            result += "Project Start: " + Start + "\n";
            result += "Project End: " + End + "\n";
            result += "Project description: " + Description + "\n";
            return result;
        }
    }
}