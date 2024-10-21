using Entity;
using ExceptionLibrary;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAO
{
    public class AdminService : IAdminService
    {
        public Admin GetAdminById(int adminId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Admin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Admin
                    {
                        AdminID = (int)reader["AdminID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        JoinDate = (DateTime)reader["JoinDate"]
                    };
                }

                throw new AdminNotFoundException("Admin not found");
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Admin WHERE UserName = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Admin
                    {
                        AdminID = (int)reader["AdminID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        JoinDate = (DateTime)reader["JoinDate"]
                    };
                }

                throw new AdminNotFoundException("Admin not found");
            }
        }

        public bool RegisterAdmin(Admin admin)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "INSERT INTO Admin (FirstName, LastName, Email, PhoneNumber, UserName, Password, Role, JoinDate) " +
                               "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password, @Role, @JoinDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
               
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Username", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@Role", admin.Role);
                cmd.Parameters.AddWithValue("@JoinDate", admin.JoinDate);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public bool UpdateAdmin(int adminId, Admin admin)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "UPDATE Admin SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                               "PhoneNumber = @PhoneNumber, UserName = @Username, Password = @Password, Role = @Role " +
                               "JoinDate = @JoinDate WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@UserName", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@Role", admin.Role);
                cmd.Parameters.AddWithValue("@JoinDate", admin.JoinDate);
                cmd.Parameters.AddWithValue("@AdminID", adminId);

                int rowsAffected = cmd.ExecuteNonQuery();
                
                return (rowsAffected > 0);
            }
        }

        public bool DeleteAdmin(int adminId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "DELETE FROM Admin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@AdminID", adminId);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
    }
}
