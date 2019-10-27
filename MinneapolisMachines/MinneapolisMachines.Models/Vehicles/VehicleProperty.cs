using System.Collections.Generic;
using System.Data;

namespace MinneapolisMachines.Models.Vehicles
{
    public class VehicleProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<VehicleProperty> ParseList(DataTable data)
        {
            List<VehicleProperty> vehicleProperties = new List<VehicleProperty>();

            foreach (DataRow row in data.Rows)
            {
                vehicleProperties.Add(new VehicleProperty()
                {
                    Id = (int) row[0],
                    Name = (string) row[1]
                });
            }

            return vehicleProperties;
        }
    }
}
