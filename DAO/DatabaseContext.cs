using Microsoft.Data.SqlClient;
using Util;
using ExceptionLibrary;

namespace DAO
{
    public class DatabaseContext
    {
        String connectionString = DBPropertyUtil.ReturnCn("dbCn");

        // Method to execute SELECT queries and return a SqlDataReader
        public SqlDataReader ExecuteQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error executing query in the database", ex);
            }
        }

        // Method to execute INSERT, UPDATE, DELETE queries
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error executing non-query in the database", ex);
            }
        }

    }
}
