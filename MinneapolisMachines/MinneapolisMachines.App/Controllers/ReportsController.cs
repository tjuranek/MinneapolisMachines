using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinneapolisMachines.App.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }

        // GET: Inventory
        public ActionResult Inventory()
        {
            return View();
        }
    }
}