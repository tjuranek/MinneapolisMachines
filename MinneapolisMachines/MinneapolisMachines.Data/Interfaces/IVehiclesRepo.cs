using System;
using System.Collections.Generic;
using MinneapolisMachines.Models.Vehicles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Data.Interfaces
{
    public interface IVehiclesRepo
    {
        void Create(int modelId, int bodyTypeId, int bodyStyleId, int exteriorColorId, int interiorColorId, int transmissionTypeId, int releaseYear, string VIN, int mileage, decimal MSRP, decimal salesPrice, string description, string imageUrl);

        void CreateMake(string name, DateTime dateCreated, int userId);

        List<Vehicle> GetAll();

        List<Make> GetMakes();

        List<Model> GetModels();

        List<VehicleProperty> GetInteriorColors();

        List<VehicleProperty> GetExteriorColors();

        List<VehicleProperty> GetBodyTypes();

        List<VehicleProperty> GetBodyStyles();

        List<VehicleProperty> GetTransmissionTypes();

        List<Vehicle> GetFeaturedVehicles();
    }
}
