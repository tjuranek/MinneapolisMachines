using System.Web.Mvc;
using MinneapolisMachines.App.Models.Admin;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Vehicles;

namespace MinneapolisMachines.App.Controllers
{
    public class AdminController : Controller
    {
        // GET: Vehicles
        public ActionResult Vehicles()
        {
            return View();
        }

        // GET: AddVehicle
        public ActionResult AddVehicle()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            VehicleViewModel viewModel = new VehicleViewModel
            {
                Makes = vehiclesRepo.GetMakes(),
                Models = vehiclesRepo.GetModels(),
                InteriorColors = vehiclesRepo.GetInteriorColors(),
                ExteriorColors = vehiclesRepo.GetExteriorColors(),
                BodyTypes = vehiclesRepo.GetBodyTypes(),
                BodyStyles = vehiclesRepo.GetBodyStyles(),
                TransmissionTypes = vehiclesRepo.GetTransmissionTypes()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel viewModel)
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();
            Vehicle vehicle = viewModel.Vehicle;

            vehiclesRepo.Create(vehicle.ModelId, vehicle.BodyTypeId, vehicle.BodyStyleId, vehicle.ExteriorColorId, vehicle.InteriorColorId, vehicle.TransmissionTypeId, vehicle.ReleaseYear, vehicle.VIN, vehicle.Mileage, vehicle.MSRP, vehicle.SalesPrice, vehicle.Description, vehicle.ImageUrl);

            return RedirectToAction("Index", "Home");
        }

        // GET: EditVehicle
        public ActionResult EditVehicle()
        {
            return View();
        }

        // GET: Users
        public ActionResult Users()
        {
            return View();
        }

        // GET: Add User
        public ActionResult AddUser()
        {
            return View();
        }

        // GET: Edit User
        public ActionResult EditUser()
        {
            return View();
        }

        // GET: Makes
        public ActionResult Makes()
        {
            return View();
        }

        // GET: Models
        public ActionResult Models()
        {
            return View();
        }

        // GET: Specials
        public ActionResult Specials()
        {
            return View();
        }
    }
}