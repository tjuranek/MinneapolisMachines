using MinneapolisMachines.Models.Specials;
using MinneapolisMachines.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinneapolisMachines.App.Models.Home
{
    public class HomeViewModel
    {
        public List<Vehicle> FeaturedVehicles { get; set; }

        public List<Special> Specials { get; set; }
    }
}