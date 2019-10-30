using System.Web.Mvc;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.App.Models.Home;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Contacts;

namespace MinneapolisMachines.App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            HomeViewModel viewModel = new HomeViewModel
            {
                FeaturedVehicles = vehiclesRepo.GetFeaturedVehicles(),
                Specials = specialsRepo.GetAll(),
                Makes = vehiclesRepo.GetMakes(),
                Models = vehiclesRepo.GetModels()
            };

            return View(viewModel);
        }

        // GET: Specials
        public ActionResult Specials()
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            return View(specialsRepo.GetAll());
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (model.Phone == 0 && model.Email == null)
            {
                ModelState.AddModelError("phoneemail", "Please enter a phone number or email address.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                IContactsRepo contactsRepo = RepoFactory.CreateContactsRepo();
                contactsRepo.Create(model.Name, model.Email, model.Phone, model.Message);
            }

            return RedirectToAction("Index");
        }
    }
}