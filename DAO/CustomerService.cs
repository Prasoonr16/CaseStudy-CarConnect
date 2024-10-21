using Entity;
using Microsoft.Data.SqlClient;
using Util;
using ExceptionLibrary;
using System.Net;

namespace DAO
{
    public class CustomerService : ICustomerService
    {

        public Customer GetCustomerById(int customerId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerId = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Username = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        RegistrationDate = (DateTime)reader["RegistrationDate"]
                    };
                }
                throw new Exception("Customer not found");

            }
        }

        public Customer GetCustomerByUsername(string username)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Customers WHERE UserName = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerId = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Username = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        RegistrationDate = (DateTime)reader["RegistrationDate"]
                    };
                }
                throw new Exception("Customer not found");

            }
        }


        public bool RegisterCustomer(Customer customer)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, UserName, Password, RegistrationDate) " +
                           "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @UserName, @Password, @RegistrationDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@UserName", customer.Username);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                cmd.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);


                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;  // Return true if any row was inserted

            }
        }

        public bool UpdateCustomer(int customerId, Customer customer)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                           "PhoneNumber = @PhoneNumber, Address = @Address WHERE CustomerID = @CustomerId";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);


                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;  // Return true if any row was updated
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;  // Return true if any row was deleted
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> AllCustomers = new List<Customer>();

            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Customers";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllCustomers.Add(new Customer()
                    {
                        CustomerId = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Username = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        RegistrationDate = (DateTime)reader["RegistrationDate"]
                    });
                }
            }
            return AllCustomers;
        }
    }
}
               