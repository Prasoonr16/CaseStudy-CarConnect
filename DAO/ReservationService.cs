using Entity;
using Microsoft.Data.SqlClient;
using ExceptionLibrary;
using Util;

namespace DAO
{
    public class ReservationService : IReservationService
    {
        public Reservation GetReservationById(int reservationId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        TotalCost = (decimal)reader["TotalCost"],
                        Status = reader["Status"].ToString()
                    };
                }
                throw new ReservationException("Reservation not found");
            }

        }

        public List<Reservation> GetReservationByCustomerId(int customerId)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT * FROM Reservations WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        TotalCost = (decimal)reader["TotalCost"],
                        Status = reader["Status"].ToString()
                    });
                }
                
                return reservations;
            }
        }

        public bool CreateReservation(Reservation reservation)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "INSERT INTO Reservations (CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status) " +
                               "VALUES (@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
               
                conn.Open();
                cmd.Parameters.AddWithValue("@CustomerID", reservation.CustomerID);
                cmd.Parameters.AddWithValue("@VehicleID", reservation.VehicleID);
                cmd.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                cmd.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                cmd.Parameters.AddWithValue("@Status", reservation.Status);

                int rowsAffected = cmd.ExecuteNonQuery();
             
                return rowsAffected > 0;
            }
        }

        public bool UpdateReservation(int reservationId, Reservation reservation)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "UPDATE Reservations SET StartDate = @StartDate, EndDate = @EndDate, TotalCost = @TotalCost, " +
                               "Status = @Status WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                cmd.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                cmd.Parameters.AddWithValue("@Status", reservation.Status);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }


        public bool CancelReservation(int reservationId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "UPDATE Reservations SET Status = 'Cancelled' WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                int rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);
            }
        }
    }
}
