using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinneapolisMachines.App.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        // GET: Purchase/ {id}
        public ActionResult Purchase(int id)
        {
            return View(id);
        }
    }
}