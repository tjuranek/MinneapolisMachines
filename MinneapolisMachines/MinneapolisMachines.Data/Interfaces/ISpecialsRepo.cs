using System.Collections.Generic;
using MinneapolisMachines.Models.Specials;

namespace MinneapolisMachines.Data.Interfaces
{
    /// <summary>
    /// Interface for Specials Repositories
    /// </summary>
    public interface ISpecialsRepo
    {
        void Create(string title, string description);

        void Delete(int id);

        List<Special> GetAll();
    }
}