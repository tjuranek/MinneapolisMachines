using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Specials;
using MinneapolisMachines.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    public class ADOVehiclesRepo : ADORepo, IVehiclesRepo
    {
        private string _connectionString;

        public ADOVehiclesRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(int modelId, int bodyTypeId, int exteriorColorId, int interiorColorId, int transmissionTypeId, int type, int releaseYear, string VIN, int mileage, decimal MSRP, decimal salesPrice, string description, string imageUrl)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ModelId", modelId),
                new SqlParameter("@BodyTypeId", bodyTypeId),
                new SqlParameter("@ExteriorColorId", exteriorColorId),
                new SqlParameter("@InteriorColorId", interiorColorId),
                new SqlParameter("@TransmissionTypeId", transmissionTypeId),
                new SqlParameter("@Type", type),
                new SqlParameter("@ReleaseYear", releaseYear),
                new SqlParameter("@VIN", VIN),
                new SqlParameter("@Mileage", mileage),
                new SqlParameter("@MSRP", MSRP),
                new SqlParameter("@SalesPrice", salesPrice),
                new SqlParameter("@Description", description),
                new SqlParameter("@ImageUrl", imageUrl)
            };

            RunStoredProcedure(_connectionString, "CreateVehicle", parameters);
        }

        public List<Vehicle> GetAll()
        {
            return Vehicle.ParseList(RunStoredProcedure(_connectionString, "GetVehicles"));
        }
    }
}
