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
    public class HomeController : Controller
    {
        //отображение списка компаний
        public ActionResult Index()
        {
            Selects sel = new Selects();
            ViewBag.New = sel.SelectCompanies();
            return View();
        }
        //отображение списка работников
        public ActionResult AllWorkers()
        {
            Selects sel = new Selects();
            ViewBag.Newsel = sel.SelectWorkers ();
            return View();
        }
        //принятие запроса на удаление и удаление компании из базы данных
        [HttpPost]
        public ActionResult DeleteCompany(int id, string table_name)
        {
            Deletes del = new Deletes();
            del.DelStr(id, table_name);
            return RedirectToAction("Index", "Home");
        }
        //принятие запроса на удаление и удаление работника из базы данных
        [HttpPost]
        public ActionResult DeleteWorker(int id, string table_name)
        {
            Deletes del = new Deletes();
            del.DelStr(id, table_name);
            return RedirectToAction("AllWorkers", "Home");
        }



    }
}