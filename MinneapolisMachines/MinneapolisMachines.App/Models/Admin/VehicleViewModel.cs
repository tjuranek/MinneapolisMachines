using System.Collections.Generic;
using System.Web.Mvc;
using MinneapolisMachines.Models.Vehicles;

namespace MinneapolisMachines.App.Models.Admin
{
    public class VehicleViewModel
    {
        public Vehicle Vehicle { get; set; }

        public List<Make> Makes { get; set; }

        public List<Model> Models { get; set; }

        public List<VehicleProperty> BodyTypes { get; set; }

        public List<VehicleProperty> BodyStyles { get; set; }

        public List<VehicleProperty> TransmissionTypes { get; set; }

        public List<VehicleProperty> InteriorColors { get; set; }

        public List<VehicleProperty> ExteriorColors { get; set; }

        public int VehicleMake { get; set; }
    }
}