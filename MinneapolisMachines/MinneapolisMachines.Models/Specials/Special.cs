using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Takes in a DataTable and returns a list of specials.
        /// </summary>
        /// <param name="data">The DataTable returned from repository.</param>
        /// <returns>A list of specials.</returns>
        public static List<Special> ParseList(DataTable data)
        {
            List<Special> specials = new List<Special>();
            
            foreach (DataRow row in data.Rows)
            {
                specials.Add(new Special()
                {
                    SpecialId = int.Parse(row["SpecialId"].ToString()),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString()
                });
            }

            return specials;
        }
    }
}
