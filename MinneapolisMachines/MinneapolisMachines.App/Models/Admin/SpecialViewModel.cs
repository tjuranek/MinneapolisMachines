using MinneapolisMachines.Models.Specials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinneapolisMachines.App.Models.Admin
{
    public class SpecialViewModel
    {
        public Special Special { get; set; }
        public List<Special> Specials { get; set; }

    }
}