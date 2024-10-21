using Entity;
using Microsoft.Data.SqlClient;
using ExceptionLibrary;
using Util;

namespace DAO
{
    public class VehicleService : IVehicleService
    {
        public Vehicle GetVehicleById(int vehicleId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Vehicles WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Vehicle
                    {
                        VehicleId = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = (bool)reader["Availability"],
                        DailyRate = (decimal)reader["DailyRate"]
                    };
                }

                throw new VehicleNotFoundException("Vehicle not found");
            }
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            List<Vehicle> availableVehicles = new List<Vehicle>();

            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Vehicles WHERE Availability = 1";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    availableVehicles.Add(new Vehicle
                    {
                        VehicleId = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = (bool)reader["Availability"],
                        DailyRate = (decimal)reader["DailyRate"]
                    });
                }

            }


            return availableVehicles;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "INSERT INTO Vehicles (Model, Make, Year, Color, RegistrationNumber, Availability, DailyRate) " +
                               "VALUES (@Model, @Make, @Year, @Color, @RegistrationNumber, @Availability, @DailyRate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Availability", vehicle.Availability);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);


                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public bool UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "UPDATE Vehicles SET Model = @Model, Make = @Make, Year = @Year, Color = @Color, " +
                               "RegistrationNumber = @RegistrationNumber, Availability = @Availability, DailyRate = @DailyRate " +
                               "WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Availability", vehicle.Availability);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    // Throw VehicleNotFoundException if no rows were updated
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} not found.");
                }


                return rowsAffected > 0;
            }
        }


        public bool RemoveVehicle(int vehicleId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> AllVehicles = new List<Vehicle>();

            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Vehicles";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AllVehicles.Add(new Vehicle
                    {
                        VehicleId = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = (bool)reader["Availability"],
                        DailyRate = (decimal)reader["DailyRate"]
                    });
                }

            }


            return AllVehicles;
        }
    }
}