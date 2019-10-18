using System.Web.Mvc;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Data.Interfaces;

namespace MinneapolisMachines.App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            return View(specialsRepo.GetAll());
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
    }
}