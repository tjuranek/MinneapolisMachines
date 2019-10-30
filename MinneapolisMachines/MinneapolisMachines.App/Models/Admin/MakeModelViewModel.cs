using MinneapolisMachines.App.Models.Accounts;
using MinneapolisMachines.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinneapolisMachines.App.Models.Admin
{
    public class MakeModelViewModel
    {
        public Make Make { get; set; }

        public Model Model { get; set; }

        public List<Make> Makes { get; set; }

        public List<Model> Models { get; set; }

        public List<User> Users { get; set; }
    }
}