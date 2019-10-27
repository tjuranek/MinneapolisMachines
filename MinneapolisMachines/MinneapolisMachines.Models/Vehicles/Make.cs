using System;
using System.Collections.Generic;
using System.Data;

namespace MinneapolisMachines.Models.Vehicles
{
    public class Make : VehicleProperty
    {
        public int UserId { get; set;  }
        public DateTime DateCreated { get; set; }

        public new static List<Make> ParseList(DataTable data)
        {
            List<Make> makes = new List<Make>();

            foreach (DataRow row in data.Rows)
            {
                makes.Add(new Make()
                {
                    Id = (int)row[0],
                    Name = (string)row["Name"],
                    UserId = (int)row["UserId"],
                    DateCreated = (DateTime)row["DateCreated"]
                });
            }

            return makes;
        }
    }
}
