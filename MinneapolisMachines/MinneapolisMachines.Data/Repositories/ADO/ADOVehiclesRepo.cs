using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    public class ADOVehiclesRepo : ADORepo, IVehiclesRepo
    {
        private string _connectionString;

        public ADOVehiclesRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(int modelId, int bodyTypeId, int bodyStyleId, int exteriorColorId, int interiorColorId, int transmissionTypeId,  int releaseYear, string VIN, int mileage, decimal MSRP, decimal salesPrice, string description, string imageUrl)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ModelId", modelId),
                new SqlParameter("@BodyTypeId", bodyTypeId),
                new SqlParameter("@BodyStyleId", bodyStyleId),
                new SqlParameter("@ExteriorColorId", exteriorColorId),
                new SqlParameter("@InteriorColorId", interiorColorId),
                new SqlParameter("@TransmissionTypeId", transmissionTypeId),
                new SqlParameter("@ReleaseYear", releaseYear),
                new SqlParameter("@VIN", VIN),
                new SqlParameter("@Mileage", mileage),
                new SqlParameter("@MSRP", MSRP),
                new SqlParameter("@SalesPrice", salesPrice),
                new SqlParameter("@Description", description),
                new SqlParameter("@IsFeatured", false),
                new SqlParameter("@ImageUrl", imageUrl)
            };

            RunStoredProcedure(_connectionString, "CreateVehicle", parameters);
        }

        public List<Vehicle> GetAll()
        {
            return Vehicle.ParseList(RunStoredProcedure(_connectionString, "GetVehicles"));
        }

        public List<Make> GetMakes()
        {
            return Make.ParseList(RunStoredProcedure(_connectionString, "GetMakes"));
        }

        public List<Model> GetModels()
        {
            return Model.ParseList(RunStoredProcedure(_connectionString, "GetModels"));
        }

        public List<VehicleProperty> GetInteriorColors()
        {
            return VehicleProperty.ParseList(RunStoredProcedure(_connectionString, "GetInteriorColors"));
        }

        public List<VehicleProperty> GetExteriorColors()
        {
            return VehicleProperty.ParseList(RunStoredProcedure(_connectionString, "GetExteriorColors"));
        }

        public List<VehicleProperty> GetBodyTypes()
        {
            return VehicleProperty.ParseList(RunStoredProcedure(_connectionString, "GetBodyTypes"));
        }

        public List<VehicleProperty> GetBodyStyles()
        {
            return VehicleProperty.ParseList(RunStoredProcedure(_connectionString, "GetBodyStyles"));
        }

        public List<VehicleProperty> GetTransmissionTypes()
        {
            return VehicleProperty.ParseList(RunStoredProcedure(_connectionString, "GetTransmissionTypes"));
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return Vehicle.ParseList(RunStoredProcedure(_connectionString, "GetFeaturedVehicles"));
        }

        public void CreateMake(string name, DateTime dateCreated, int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@DateCreated", dateCreated),
                new SqlParameter("@UserId", userId)
            };

            RunStoredProcedure(_connectionString, "CreateMake", parameters);
        }
    }
}
