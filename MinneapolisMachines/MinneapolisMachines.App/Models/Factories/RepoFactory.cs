using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Data.Repositories.ADO;

namespace MinneapolisMachines.App.Models.Factories
{
    public class RepoFactory
    {
        private static string _mode = ConfigurationManager.AppSettings["mode"];
        private static string _connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

        public static ISpecialsRepo CreateSpecialsRepo()
        {
            switch (_mode)
            {
                case ("prod"):
                    return new ADOSpecialsRepo(_connectionString);
                default:
                    return new ADOSpecialsRepo(_connectionString);     
            }
        }
    }
}