using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinneapolisMachines.App.Controllers
{
    public class InventoryController : Controller
    {
        // GET: New
        public ActionResult New()
        {
            return View();
        }

        // GET: Used
        public ActionResult Used()
        {
            return View();
        }

        // GET: Details / {id}
        public ActionResult Details(int id)
        {
            return View(id);
        }
    }
}