using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Catalog.Models
{
    public abstract class BaseModel
    {
        public abstract string Id { get; set; }
        public abstract string TableName { get; set; }
        public abstract List<string> TableColumns { get; set; }
    }
}