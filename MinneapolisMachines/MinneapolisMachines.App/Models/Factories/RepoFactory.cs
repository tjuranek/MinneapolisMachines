using System.Configuration;
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

        public static IVehiclesRepo CreateVehiclesRepo()
        {
            switch (_mode)
            {
                case ("prod"):
                    return new ADOVehiclesRepo(_connectionString);
                default:
                    return new ADOVehiclesRepo(_connectionString);
            }
        }

        public static IContactsRepo CreateContactsRepo()
        {
            switch (_mode)
            {
                case ("prod"):
                    return new ADOContactsRepo(_connectionString);
                default:
                    return new ADOContactsRepo(_connectionString);
            }
        }
    }
}