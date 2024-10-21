using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Vehicle
    {
        public Vehicle(int vehicleId, string model, string make, int year, string color, string registrationNumber, bool availability, decimal dailyRate)
        {
            VehicleId = vehicleId;
            Model = model;
            Make = make;
            Year = year;
            Color = color;
            RegistrationNumber = registrationNumber;
            Availability = availability;
            DailyRate = dailyRate;
        }

        public Vehicle() { }

        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public bool Availability { get; set; }
        public decimal DailyRate { get; set; }
    }
}
