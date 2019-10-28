using System.Collections.Generic;
using System.Web.Mvc;
using MinneapolisMachines.App.Models.Admin;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Vehicles;

namespace MinneapolisMachines.App.Controllers
{
    public class InventoryController : Controller
    {
        // GET: New
        public ActionResult New()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();
            List<Vehicle> vehicles = vehiclesRepo.GetAll();

            return View(vehicles);
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