using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Task_Qulix.Models
{
    public class Company
    {
        public Company (int id, string name_of, string company_size, string legal_form_id)
        {
            this.id = id;
            this.name_of = name_of;
            this.company_size = company_size;
            this.legal_form_id = legal_form_id;
        }

        public int id { get; set; }
        public string name_of { get; set; }
        public string company_size { get; set; }
        public string legal_form_id { get; set; }

    
    }
}