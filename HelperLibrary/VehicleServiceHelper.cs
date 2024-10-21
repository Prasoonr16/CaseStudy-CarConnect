using DAO;
using Entity;

namespace HelperLibrary
{
    public class VehicleServiceHelper
    {
        VehicleService vehicleService = null;
        public VehicleServiceHelper()
        {
            vehicleService = new VehicleService();
        }

        public Vehicle getVehicleById(int vehicleId)
        {
            return vehicleService.GetVehicleById(vehicleId);
        }

        public List<Vehicle> getAvailableVehicles()
        {
            return vehicleService.GetAvailableVehicles();
        }

        public bool addVehicle(Vehicle vehicle)
        {
            return vehicleService.AddVehicle(vehicle);
        }

        public bool updateVehicle(int vehicleId, Vehicle vehicle)
        {
            return vehicleService.UpdateVehicle(vehicleId, vehicle);
        }

        public bool removeVehicle(int vehicleId)
        {
            return vehicleService.RemoveVehicle(vehicleId);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return vehicleService.GetAllVehicles();
        }

    }
}
