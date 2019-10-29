using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Models.Vehicles;

namespace MinneapolisMachines.App.Controllers
{
    public class ApiController : System.Web.Http.ApiController
    {
        [Route("api/models/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelsByMakeId(int id)
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();
            var vehicles = vehiclesRepo.GetModels().Where(m => m.MakeId == id);

            return Ok(vehicles);
        }

        [Route("api/vehicles/new")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetNewInventory()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            int newTypeId = vehiclesRepo.GetBodyTypes().FirstOrDefault(t => t.Name == "New").Id;
            var vehicles = vehiclesRepo.GetAll().Where(v => v.BodyTypeId == newTypeId);

            return Ok(vehicles);
        }

        [Route("api/vehicles/used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsedInventory()
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();

            int usedTypeId = vehiclesRepo.GetBodyTypes().FirstOrDefault(t => t.Name == "Used").Id;
            var vehicles = vehiclesRepo.GetAll().Where(v => v.BodyTypeId == usedTypeId);

            return Ok(vehicles);
        }

        [Route("api/search/{keyword}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string keyword, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            IVehiclesRepo vehiclesRepo = RepoFactory.CreateVehiclesRepo();
            SearchType searchType = int.TryParse(keyword, out int year) ? SearchType.Year : SearchType.MakeModel;

            if (searchType == SearchType.Year)
                return Ok(vehiclesRepo.GetAll().Where(v => v.ReleaseYear == year).Where(v => v.SalesPrice >= minPrice && v.SalesPrice <= maxPrice));

            var vehicles = vehiclesRepo.GetAll();
            var makes = vehiclesRepo.GetMakes();
            var models = vehiclesRepo.GetModels();
            var modelSearch = new List<Vehicle>();
            var makeSearch = new List<Vehicle>();

            // this gets all of the vehicles where there is a model name containing the keyword, and is in the price range and release year range
            try
            {
                modelSearch = vehicles.Where(v => v.ModelId == models.FirstOrDefault(m => m.Name.ToLower().Contains(keyword.ToLower())).Id).Where(v => v.SalesPrice >= minPrice && v.SalesPrice <= maxPrice).Where(v => v.ReleaseYear >= minYear && v.ReleaseYear <= maxYear).ToList();
            }
            catch (Exception e)
            {
                modelSearch = new List<Vehicle>();
            }
            

            // this gets all of the vehicles where the make id matches a model id, searches the make name for the keyword, and filters by price and year range
            makeSearch = vehicles.Where(v => makes.FirstOrDefault(ma => ma.Id == models.FirstOrDefault(m => m.Id == ma.Id).Id).Name.ToLower().Contains(keyword.ToLower())).Where(v => v.SalesPrice >= minPrice && v.SalesPrice <= maxPrice).Where(v => v.ReleaseYear >= minYear && v.ReleaseYear <= maxYear).ToList();

            return Ok(modelSearch.Count >= makeSearch.Count ? modelSearch : makeSearch);
        }
    }

    public enum SearchType
    {
        Year,
        MakeModel
    }
}