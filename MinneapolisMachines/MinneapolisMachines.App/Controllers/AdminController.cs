using System.Linq;
using System.Web.Mvc;
using MinneapolisMachines.App.Models.Admin;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Vehicles;
using MinneapolisMachines.App.Models.Accounts;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System;
using System.Security.Claims;

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

            if (ModelState.IsValid)
            {
                vehiclesRepo.Create(vehicle.ModelId, vehicle.BodyTypeId, vehicle.BodyStyleId, vehicle.ExteriorColorId, vehicle.InteriorColorId, vehicle.TransmissionTypeId, vehicle.ReleaseYear, vehicle.VIN, vehicle.Mileage, vehicle.MSRP, vehicle.SalesPrice, vehicle.Description, vehicle.ImageUrl);
            }
            else
            {
                return View(new VehicleViewModel
                {
                    Makes = vehiclesRepo.GetMakes(),
                    Models = vehiclesRepo.GetModels(),
                    InteriorColors = vehiclesRepo.GetInteriorColors(),
                    ExteriorColors = vehiclesRepo.GetExteriorColors(),
                    BodyTypes = vehiclesRepo.GetBodyTypes(),
                    BodyStyles = vehiclesRepo.GetBodyStyles(),
                    TransmissionTypes = vehiclesRepo.GetTransmissionTypes()
                });
            }

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
            var viewModel = new UserRoleViewModel();

            using (var db = new AccountDbContext())
            {
                viewModel.Users = db.Users.ToList();
                viewModel.Roles = db.Roles.ToList();
            }

            return View(viewModel);
        }

        // GET: Add User
        public ActionResult AddUser()
        {
            var viewModel = new UserRoleViewModel();

            using (var db = new AccountDbContext())
            {
                viewModel.Users = db.Users.ToList();
                viewModel.Roles = db.Roles.ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddUser(UserRoleViewModel model)
        {
            using (var db = new AccountDbContext())
            {
                db.Users.Add(new User()
                {
                    UserId = model.SelectedUser.UserId,
                    RoleId = model.SelectedUser.RoleId,
                    FirstName = model.SelectedUser.FirstName,
                    LastName = model.SelectedUser.LastName,
                    Email = model.SelectedUser.Email,
                    Password = new PasswordHasher().HashPassword(model.SelectedUser.Password)
                });

                db.SaveChanges();

                model.Users = db.Users.ToList();
                model.Roles = db.Roles.ToList();
            };

            return View("Users", model);
        }

        // GET: Edit User
        public ActionResult EditUser(int userId)
        {
            var viewModel = new UserRoleViewModel();

            using (var db = new AccountDbContext())
            {
                viewModel.SelectedUser = db.Users.FirstOrDefault(u => u.UserId == userId);
                viewModel.Users = db.Users.ToList();
                viewModel.Roles = db.Roles.ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(UserRoleViewModel model)
        {
            using (var db = new AccountDbContext())
            {
                db.Entry(model.SelectedUser).State = EntityState.Modified;
                db.SaveChanges();

                model.Users = db.Users.ToList();
                model.Roles = db.Roles.ToList();
            };

            return View("Users", model);
        }

        // GET: Makes
        public ActionResult Makes()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            using (var db = new AccountDbContext())
            {
                MakeModelViewModel viewModel = new MakeModelViewModel()
                {
                    Makes = vehiclesRepo.GetMakes(),
                    Users = db.Users.ToList()
                };

                return View("Makes", viewModel);
            };
        }

        [HttpPost]
        public ActionResult Makes(MakeModelViewModel model)
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            MakeModelViewModel viewModel = new MakeModelViewModel();

            using (var db = new AccountDbContext())
            {
                string claimUserEmail = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value;
                User loggedInUser = db.Users.FirstOrDefault(x => x.Email == claimUserEmail);

                model.Make.DateCreated = DateTime.Now;
                model.Make.UserId = loggedInUser.UserId;

                vehiclesRepo.CreateMake(model.Make.Name, model.Make.DateCreated, model.Make.UserId);

                viewModel = new MakeModelViewModel()
                {
                    Makes = vehiclesRepo.GetMakes(),
                    Users = db.Users.ToList()
                };
            }

            return View("Makes", viewModel);
        }

        // GET: Models
        public ActionResult Models()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            using (var db = new AccountDbContext())
            {
                MakeModelViewModel viewModel = new MakeModelViewModel()
                {
                    Makes = vehiclesRepo.GetMakes(),
                    Models = vehiclesRepo.GetModels(),
                    Users = db.Users.ToList()
                };

                return View("Models", viewModel);
            };
        }

        // GET: Specials
        public ActionResult Specials()
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();

            SpecialViewModel viewModel = new SpecialViewModel()
            {
                Specials = specialsRepo.GetAll()
            };

            return View(viewModel);
        }

        // GET: Specials (for removing a special)
        public ActionResult DeleteSpecial(int specialId)
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            specialsRepo.Delete(specialsRepo.GetAll().FirstOrDefault(s => s.SpecialId == specialId).SpecialId);

            return RedirectToAction("Specials", "Home", specialsRepo.GetAll());
        }

        // POST: Specials
        [HttpPost]
        public ActionResult Specials(SpecialViewModel model)
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            specialsRepo.Create(model.Special.Title, model.Special.Description);

            return RedirectToAction("Specials", "Home", specialsRepo.GetAll());
        }
    }
}