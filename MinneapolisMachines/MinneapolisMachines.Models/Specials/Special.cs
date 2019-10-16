using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Models.Specials
{
    /// <summary>
    /// Represents a Special from a Specials repository
    /// </summary>
    public class Special
    {
        public int SpecialId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
