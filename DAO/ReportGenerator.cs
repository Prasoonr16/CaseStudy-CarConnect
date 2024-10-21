using Microsoft.Data.SqlClient;
using System.Data;
using Util;

namespace DAO
{
    public class ReportGenerator
    {

        // Generate report of all reservations made by customers
        public DataTable GenerateReservationHistoryReport()
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT r.ReservationId, r.StartDate, r.EndDate, r.TotalCost, r.Status, " +
                               "c.FirstName + ' ' + c.LastName AS CustomerName, v.Make + ' ' + v.Model AS VehicleDetails " +
                               "FROM Reservations r " +
                               "INNER JOIN Customers c ON r.CustomerId = c.CustomerId " +
                               "INNER JOIN Vehicles v ON r.VehicleId = v.VehicleId";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable reservationHistory = new DataTable();
                adapter.Fill(reservationHistory);
                return reservationHistory;
            }
        }

        // Generate vehicle utilization report
        public DataTable GenerateVehicleUtilizationReport()
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT v.VehicleId, v.Make, v.Model, COUNT(r.ReservationId) AS TimesRented " +
                               "FROM Vehicles v " +
                               "LEFT JOIN Reservations r ON v.VehicleId = r.VehicleId " +
                               "GROUP BY v.VehicleId, v.Make, v.Model " +
                               "ORDER BY TimesRented DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable vehicleUtilization = new DataTable();
                adapter.Fill(vehicleUtilization);
                return vehicleUtilization;
            }
        }

        // Generate revenue report based on completed reservations
        public DataTable GenerateRevenueReport()
        {
            using (SqlConnection conn = DBConnUtil.GetConnectionString())
            {
                string query = "SELECT SUM(TotalCost) AS TotalRevenue FROM Reservations WHERE Status = 'completed'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open ();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable revenueReport = new DataTable();
                adapter.Fill(revenueReport);
                return revenueReport;
            }
        }
    }

}

