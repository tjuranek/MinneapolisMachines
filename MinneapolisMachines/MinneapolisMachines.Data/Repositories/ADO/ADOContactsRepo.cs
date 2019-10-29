using MinneapolisMachines.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    public class ADOContactsRepo : ADORepo, IContactsRepo
    {
        private string _connectionString;

        public ADOContactsRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(string name, string email, int phone, string message)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Message", message)
            };

            RunStoredProcedure(_connectionString, "CreateContact", parameters);
        }
    }
}
