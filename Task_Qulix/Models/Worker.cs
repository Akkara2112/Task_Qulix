using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Task_Qulix.Models
{
    public class Worker
    {
        public Worker(int id, string first_name, string last_name, string patronymic, string date_of_registration, string position_id, string company_id)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.patronymic = patronymic;
            this.date_of_registration = date_of_registration;
            this.position_id = position_id;
            this.company_id = company_id;
        }

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string date_of_registration { get; set; }
        public string position_id { get;set; }
        public string company_id { get; set; }


    }
}