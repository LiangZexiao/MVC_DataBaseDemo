using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo.Class;
using MVC_Demo.Models;

namespace MVC_Demo.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
            DataBaseHelper helper = new DataBaseHelper();
            List<Table_1> table = new List<Table_1>();
            table = helper.GetAllRecords();

            ViewBag.table = table;
            return View();
        }
    }
}