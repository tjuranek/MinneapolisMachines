using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Models.Vehicles
{
    public class Make : DropdownListItem
    {
        public int UserId { get; set;  }
        public DateTime DateCreated { get; set; }
    }
}
