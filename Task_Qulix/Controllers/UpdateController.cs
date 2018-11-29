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
    public class UpdateController : Controller
    {
        string connectionString = @"Data Source=SQL6002.site4now.net;Initial Catalog=DB_A43234_mydb;User Id=DB_A43234_mydb_admin;Password=3258131s;";
        //принятие запроса на обновление данных работника, вывод текущих данных в представлении
        [HttpPost]
        public ActionResult FormUpWorker(int id, string first_name, string last_name, string patronymic, string date_of_registration, string position_id, string company_id)
        {
            Selects sel = new Selects();
            ViewBag.positions = sel.SelectPositions();
            ViewBag.companies = sel.SelectCompanies();

            ViewBag.id_w = id;
            ViewBag.first_w = first_name;
            ViewBag.last_w = last_name;
            ViewBag.pat_w = patronymic;
            ViewBag.date_w = DateTime.Parse(date_of_registration).Date;
            ViewBag.pos_w = position_id;
            ViewBag.com_id = company_id;

            return View();
        }
        //принятие запроса на обновление данных компании, вывод текущих данных в представлении
        [HttpPost]
        public ActionResult FormUpCompany(int id, string name_of, string company_size, string legal_form_id)
        {
            Selects sel = new Selects();
            ViewBag.positions = sel.SelectForms();

            ViewBag.id_c = id;
            ViewBag.name_of_c = name_of;
            ViewBag.size_c = company_size;
            ViewBag.form_c = legal_form_id;

            return View();
        }

        //принятие запроса на обновление данных работника и обновление в базе данных
        [HttpPost]
        public ActionResult UpWorker(int id, string first_name, string last_name, string patronymic, DateTime date_of_registration, int PosSelector, int ComSelector)
        {
            string sqlExpression = $"UPDATE Worker SET first_name = N'{first_name}', last_name = N'{last_name}', patronymic = N'{patronymic}', date_of_registration = '{date_of_registration.Date.ToString()}', position_id = {PosSelector}, company_id = {ComSelector} WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }

            return RedirectToAction("AllWorkers", "Home");
        }

        //принятие запроса на обновление данных компании и обновление в базе данных
        [HttpPost]
        public ActionResult UpCompany(int id, string name_of, string company_size, int LegSelector)
        {
            string sqlExpression = $"UPDATE Company SET name_of = N'{name_of}',company_size = '{company_size}',legal_form_id = {LegSelector}  WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}