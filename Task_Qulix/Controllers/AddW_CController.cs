using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Task_Qulix.Models;
using Task_Qulix.logic;

namespace Task_Qulix.Controllers
{
    //контроллер для добавление работников и компаний
    public class AddW_CController : Controller
    {
        string connectionString = @"Data Source=SQL6002.site4now.net;Initial Catalog=DB_A43234_mydb;User Id=DB_A43234_mydb_admin;Password=3258131s;";
        //отображение формы добавления работника
        public ActionResult FormAddWorker()
        {
            Selects sel = new Selects();
            ViewBag.positions = sel.SelectPositions() ;
            ViewBag.companies = sel.SelectCompanies() ;
            return View();
        }
        //отображение формы добавления компании
        public ActionResult FormAddCompany()
        {
            Selects sel = new Selects();
            ViewBag.positions = sel.SelectForms();
            return View();
        }

        //принятие запроса на добавление работника и добавление его в базу данных
        [HttpPost]
        public ActionResult AddWorker(string first_name, string last_name, string patronymic,DateTime date_of_registration, int PosSelector, int ComSelector)
        {
            string sqlExpression = $"INSERT Worker (first_name, last_name,patronymic,date_of_registration,position_id,company_id) VALUES (N'{first_name}',N'{last_name}',N'{patronymic}','{date_of_registration.Date.ToString()}',{PosSelector},{ComSelector})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }

            return RedirectToAction("FormAddWorker", "AddW_C");
        }

        //принятие запроса на добавление компании и добавление её в базу данных
        [HttpPost]
        public ActionResult AddCompany(string name_of, string company_size,int LegSelector)
        {
            string sqlExpression = $"INSERT Company (name_of,company_size,legal_form_id) VALUES (N'{name_of}','{company_size}','{LegSelector}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }

            return RedirectToAction("FormAddCompany", "AddW_C");
        }


    }
}