using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_Qulix.Models
{
    public class Position
    {
        public Position(int id, string name_of)
        {
            this.id = id;
            this.name_of = name_of;
        }

        public int id { get; set; }
        public string name_of { get; set; }

    }
}