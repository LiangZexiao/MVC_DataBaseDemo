using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo.Class;
using MVC_Demo.Models;
using System.Configuration;

namespace MVC_Demo.Controllers
{
    public class DataBaseController : Controller
    {
        //DataBaseHelper helper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString());
        private DataBaseHelper helper = new DataBaseHelper(@"Data Source=DESKTOP-130IQ5N;Initial Catalog=Test;Integrated Security=True");

        // GET: DataBase
        public ActionResult Index()
        {
            
            List<Table_1> table = new List<Table_1>();
            table = helper.GetAllRecord();

            ViewBag.table = table;
            return View();
        }

        public ActionResult Update()
        {

            return View();
        }

        public ActionResult Delete()
        {

            return View();
        }
    }
}