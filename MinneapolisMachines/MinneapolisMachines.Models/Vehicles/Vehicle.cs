using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MinneapolisMachines.Models.Vehicles
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int BodyTypeId { get; set; }

        [Required]
        public int BodyStyleId { get; set; }

        [Required]
        public int ExteriorColorId { get; set; }

        [Required]
        public int InteriorColorId { get; set; }

        [Required]
        public int TransmissionTypeId { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public decimal MSRP { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
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
                    BodyStyleId = int.Parse(row["BodyStyleId"].ToString()),
                    ExteriorColorId = int.Parse(row["ExteriorColorId"].ToString()),
                    InteriorColorId = int.Parse(row["InteriorColorId"].ToString()),
                    TransmissionTypeId = int.Parse(row["TransmissionTypeId"].ToString()),
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
