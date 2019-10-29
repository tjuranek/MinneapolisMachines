using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Data.Interfaces
{
    public interface IContactsRepo
    {
        void Create(string name, string email, int phone, string message);
    }
}
