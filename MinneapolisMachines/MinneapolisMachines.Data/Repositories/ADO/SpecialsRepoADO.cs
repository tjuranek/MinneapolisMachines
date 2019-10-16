using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Specials;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    /// <summary>
    /// ADO.NET Repository for creating and retriving Specials
    /// </summary>
    public class SpecialsRepoADO : ADORepository, ISpecialsRepo
    {
        private string _connectionString;

        public SpecialsRepoADO(string connectionString)
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

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();
            SqlDataReader data = RunStoredProcedure(_connectionString, "GetSpecials");

            while (data.Read())
            {
                specials.Add(new Special()
                {
                    SpecialId = int.Parse(data["SpecialId"].ToString()),
                    Title = data["Title"].ToString(),
                    Description = data["Description"].ToString()
                });
            }

            return specials;
        }
    }
}
