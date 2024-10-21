using Microsoft.Data.SqlClient;
using Util;
using ExceptionLibrary;
using System.Security.Cryptography;
using System.Text;

namespace DAO
{
    public class AuthenticationService
    {
        public bool AuthenticateCustomer(string username, string password)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT Password FROM Customers WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();
                    if (storedPassword.Equals(password))
                    {
                        return true;
                    }
                    else
                    {
                        throw new AuthenticationException("Incorrect password for customer.");
                    }
                }
                else
                {
                    throw new AuthenticationException("Customer not found.");
                }
            }
        }


        public bool AuthenticateAdmin(string username, string password)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT Password FROM Admin WHERE UserName = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();
                    if (storedPassword.Equals(password))
                    {
                        return true;
                    }
                    else
                    {
                        throw new AuthenticationException("Incorrect password for admin.");
                    }
                }
                else
                {
                    throw new AuthenticationException("Admin not found.");
                }

            }

        }
    }
}

