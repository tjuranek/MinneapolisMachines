using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        /// <summary>
        /// Takes in a SqlDataReader and returns a list of specials from the SQL data.
        /// </summary>
        /// <param name="data">The SqlDataReader returned from database stored procedure.</param>
        /// <returns>A list of specials.</returns>
        public static List<Special> ParseList(SqlDataReader data)
        {
            List<Special> specials = new List<Special>();

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
