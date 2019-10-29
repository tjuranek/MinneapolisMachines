using MinneapolisMachines.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinneapolisMachines.App.Models.Inventory
{
    public class InventoryViewModel { 
    
        public List<Vehicle> Vehicles { get; set; }

        public List<Make> Makes { get; set; }

        public List<Model> Models { get; set; }

        public List<VehicleProperty> BodyTypes { get; set; }

        public List<VehicleProperty> BodyStyles { get; set; }

        public List<VehicleProperty> TransmissionTypes { get; set; }

        public List<VehicleProperty> InteriorColors { get; set; }

        public List<VehicleProperty> ExteriorColors { get; set; }

    }
}