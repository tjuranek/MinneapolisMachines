using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinneapolisMachines.Models.Specials;

namespace MinneapolisMachines.Data.Interfaces
{
    /// <summary>
    /// Interface for Specials Repositories
    /// </summary>
    public interface ISpecialsRepo
    {
        void Create(string title, string description);

        List<Special> GetAll();
    }
}
