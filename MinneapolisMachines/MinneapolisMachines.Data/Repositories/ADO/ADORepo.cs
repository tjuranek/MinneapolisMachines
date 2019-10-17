using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinneapolisMachines.Data.Repositories.ADO
{
    /// <summary>
    /// Abstract class for ADO repositories to inherit from.
    /// </summary>
    public abstract class ADORepo
    {
        /// <summary>
        /// Connects to and runs a stored procedure and returns the results as a DataTable.
        /// </summary>
        /// <param name="connectionString">The connections string to the database.</param>
        /// <param name="procedureName">The name of the stored procedure.</param>
        /// <param name="parameters">The list of SqlParameters to be added to the SqlCommand.</param>
        /// <returns>A SqlDataReader with any available results from the store procedure.</returns>
        public virtual DataTable RunStoredProcedure(string connectionString, string procedureName, List<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                conn.Open();

                DataTable results = new DataTable();
                results.Load(cmd.ExecuteReader());
                return results;
            }
        }
    }
}
