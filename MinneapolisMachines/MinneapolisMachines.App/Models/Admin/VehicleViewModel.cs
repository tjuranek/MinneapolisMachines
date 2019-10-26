using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinneapolisMachines.Models;
using MinneapolisMachines.Models.Vehicles;

namespace MinneapolisMachines.App.Models.Admin
{
    public class VehicleViewModel
    {
        public Vehicle Vehicle { get; set; }

        public List<Make> Makes { get; set; }

        public List<Model> Models { get; set; }

        public List<DropdownListItem> BodyType { get; set; }

        public List<DropdownListItem> BodyStyle { get; set; }

        public List<DropdownListItem> TransmissionType { get; set; }

        public List<DropdownListItem> InteriorColors { get; set; }

        public List<DropdownListItem> ExteriorColors { get; set; }
    }
}