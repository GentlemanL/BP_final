using BP_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BP_final.Controllers
{
    public class DBConnectionController : Controller
    {
        // GET: DBConnection
        public DBConnection DB = new DBConnection();

        public ActionResult Index()
        {
            bool i = DB.Open();
            if (i == true)
            {
                return Content(i.ToString());
            }
            else
            {
                return Content(i.ToString());
            }

            return View();
        }
    }
}