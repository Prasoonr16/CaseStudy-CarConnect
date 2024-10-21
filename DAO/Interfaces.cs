using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int customerId);

        Customer GetCustomerByUsername(string username);

        bool RegisterCustomer(Customer customer);

        bool UpdateCustomer(int customerId, Customer customer);

        bool DeleteCustomer(int customerId);

        List<Customer> GetAllCustomers();
    }

    public interface IVehicleService
    {
        Vehicle GetVehicleById(int vehicleId);

        List<Vehicle> GetAvailableVehicles();

        bool AddVehicle(Vehicle vehicle);

        bool UpdateVehicle(int vehicleId, Vehicle vehicle);

        bool RemoveVehicle(int vehicleId);

        List<Vehicle> GetAllVehicles();

    }

    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);

        List<Reservation> GetReservationByCustomerId(int customerId);

        bool CreateReservation(Reservation reservation);

        bool UpdateReservation(int reservationId, Reservation reservation);

        bool CancelReservation(int reservationId);
    }

    public interface IAdminService
    {
        Admin GetAdminById(int adminId);

        Admin GetAdminByUsername(string username);

        bool RegisterAdmin(Admin admin);

        bool UpdateAdmin(int adminId, Admin admin);

        bool DeleteAdmin(int adminId);
    }
}
