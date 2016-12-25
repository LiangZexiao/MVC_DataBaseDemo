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

        public ActionResult Update_Page(int id)
        {
            Table_1 item = new Table_1();
            item = helper.SearchRecordByID(id);

            ViewData["id"] = item.id;
            ViewData["name"] = item.name;
            ViewData["sex"] = item.sex;
            return View();
        }

        public ActionResult Update(FormCollection form)
        {
            Table_1 table = new Table_1();
            table.name = form["name"];
            table.sex = form["sex"];
            table.id = Convert.ToInt16(form["id"]);

            int i = helper.UpdateRecord(table);
            if (i > 0)
            {
                Response.Write("修改成功！");
            }
            else
            {
                Response.Write("修改失败！");
            }

            ViewBag.table = helper.GetAllRecord();
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            if(helper.DeleteRecord(id)!=0)
            {
                Response.Write("删除成功！");
            }
            else
            {
                Response.Write("删除失败！");
            }

            ViewBag.table = helper.GetAllRecord();
            return View("Index");
        }


        public ActionResult Add_Page()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            Table_1 table = new Table_1();
            table.name = form["name"];
            table.sex = form["sex"];
            
            int i = helper.AddRecord(table);
            if(i>0)
            {
                Response.Write("添加成功！");
            }
            else
            {
                Response.Write("添加失败！");
            }
            ViewBag.table = helper.GetAllRecord();
            return View("Index");
        }
    }
}