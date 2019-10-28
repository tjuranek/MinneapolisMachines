using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.App.Models.Factories;

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
    }
}