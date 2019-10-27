using System;
using System.Collections.Generic;
using System.Data;

namespace MinneapolisMachines.Models.Vehicles
{
    public class Model : VehicleProperty
    {
        public int MakeId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public new static List<Model> ParseList(DataTable data)
        {
            List<Model> models = new List<Model>();

            foreach (DataRow row in data.Rows)
            {
                models.Add(new Model()
                {
                    Id = (int) row[0],
                    Name = (string) row["Name"],
                    MakeId = (int) row["MakeId"],
                    UserId = (int) row["UserId"],
                    DateCreated = (DateTime) row["DateCreated"]
                });
            }

            return models;
        }
    }
}
