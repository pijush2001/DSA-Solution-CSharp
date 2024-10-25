using Parking_Lot_System.Interfaces;
using Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Services
{
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string type, int id, string licensePlate, string customerId, Terminal terminalEntrance)
        {
            switch (type)
            {
                case "Car":
                    return new Car
                    {
                        Id = id,
                        LicensePlate = licensePlate,
                        CustomerId = customerId,
                        TerminalEntrance = terminalEntrance
                    };
                case "Handicap":
                    return new HandicapVehicle
                    {
                        Id = id,
                        LicensePlate = licensePlate,
                        CustomerId = customerId,
                        TerminalEntrance = terminalEntrance
                    };
                case "Motorcycle":
                    return new Motorcycle
                    {
                        Id = id,
                        LicensePlate = licensePlate,
                        CustomerId = customerId,
                        TerminalEntrance = terminalEntrance
                    };
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
