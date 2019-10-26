using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Models.Vehicles
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int Type { get; set; }
        public int ReleaseYear { get; set; }
        public string VIN { get; set; }
        public int Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public static List<Vehicle> ParseList(DataTable data)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (DataRow row in data.Rows)
            {
                vehicles.Add(new Vehicle()
                {
                    VehicleId = int.Parse(row["VehicleId"].ToString()),
                    ModelId = int.Parse(row["ModelId"].ToString()),
                    BodyTypeId = int.Parse(row["BodyTypeId"].ToString()),
                    ExteriorColorId = int.Parse(row["ExteriorColorId"].ToString()),
                    InteriorColorId = int.Parse(row["InteriorColorId"].ToString()),
                    TransmissionTypeId = int.Parse(row["TransmissionTypeId"].ToString()),
                    Type = int.Parse(row["Type"].ToString()),
                    ReleaseYear = int.Parse(row["ReleaseYear"].ToString()),
                    VIN = row["VIN"].ToString(),
                    Mileage = int.Parse(row["Mileage"].ToString()),
                    MSRP = decimal.Parse(row["MSRP"].ToString()),
                    SalesPrice = decimal.Parse(row["SalesPrice"].ToString()),
                    Description = row["Description"].ToString(),
                    ImageUrl = row["ImageUrl"].ToString()
                });
            }

            return vehicles;
        }
    }
}
