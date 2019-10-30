using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MinneapolisMachines.App.Models.Admin;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.App.Models.Inventory;
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

            return View(new InventoryViewModel()
            {
                Vehicles = vehiclesRepo.GetAll().Where(v => v.BodyTypeId == 1).ToList(),
                Makes = vehiclesRepo.GetMakes(),
                Models = vehiclesRepo.GetModels(),
                InteriorColors = vehiclesRepo.GetInteriorColors(),
                ExteriorColors = vehiclesRepo.GetExteriorColors(),
                BodyTypes = vehiclesRepo.GetBodyTypes(),
                BodyStyles = vehiclesRepo.GetBodyStyles(),
                TransmissionTypes = vehiclesRepo.GetTransmissionTypes()
            });
        }

        // GET: Used
        public ActionResult Used()
        {
            return View();
        }

        // GET: Details / {id}
        public ActionResult Details(int id)
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            return View(new VehicleViewModel
            {
                Vehicle = vehiclesRepo.GetAll().FirstOrDefault(v => v.VehicleId == id),
                Makes = vehiclesRepo.GetMakes(),
                Models = vehiclesRepo.GetModels(),
                InteriorColors = vehiclesRepo.GetInteriorColors(),
                ExteriorColors = vehiclesRepo.GetExteriorColors(),
                BodyTypes = vehiclesRepo.GetBodyTypes(),
                BodyStyles = vehiclesRepo.GetBodyStyles(),
                TransmissionTypes = vehiclesRepo.GetTransmissionTypes()
            });
        }
    }
}