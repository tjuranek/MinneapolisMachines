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
        void Create(int modelId, int bodyTypeId, int exteriorColorId, int interiorColorId, int transmissionTypeId, int type, int releaseYear, string VIN, int mileage, decimal MSRP, decimal SalesPrice, string Description, string ImageUrl);

        List<Vehicle> GetAll();

    }
}
