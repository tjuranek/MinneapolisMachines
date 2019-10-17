using System.Collections.Generic;
using System.Data.SqlClient;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Specials;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    /// <summary>
    /// ADO.NET Repository for creating and retriving Specials
    /// </summary>
    public class ADOSpecialsRepo : ADORepo, ISpecialsRepo
    {
        private string _connectionString;

        public ADOSpecialsRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(string title, string description)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description)
            };

            RunStoredProcedure(_connectionString, "CreateSpecial", parameters);
        }

        public void Delete(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            RunStoredProcedure(_connectionString, "DeleteSpecial", parameters);
        }

        public List<Special> GetAll()
        {
            return Special.ParseList(RunStoredProcedure(_connectionString, "GetSpecials"));
        }
    }
}
