using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal enum eSupportedVehcile
    {
        ElectricMotorcycle =1,
        RegularMotorcycle,
        ElectricCar,
        RegularCar,
        Truck
    }
    internal enum eSupportedVehicleWheels
    {
        Motorcycle = 2,
        Car = 5,
        Truck = 14
    }

    internal enum eSupportedVehicleWheelsPressure
    {
        Motorcycle = 28,
        Car = 32,
        Truck = 34
    }
    internal class ValidVehcile
    {
        public enum ePossibleValues
        {
            Doors,
            Color,
            ModelName,
            CurrentFuel,
            CurrentHours,
            DangerousChemicals,
            CargoCpacity,
            WheelManufacturer,
            CurentWheelAirPressure,
            LicenseType,
            EngineCapacity
        }
        private const bool k_ElectricOrNot = true;
        private static readonly string[] sr_SupportedVehicleArr = new string[] { "Regular Motorcycle", "Electric Motorcycle", "Regular Car", "Electric Car", "Truck" };
        internal static string[] SupportedVehicleArr
        {
            get { return sr_SupportedVehicleArr; }
        }
        internal static Vehicle createCar(string io_SerialNumber, bool i_IsElectric)
        {
            Car newCar = null;
            if (i_IsElectric)
            {
                Electric electricEngine = new Electric(1.2f);
                newCar = new Car(io_SerialNumber, (int)eSupportedVehicleWheels.Car, (int)eSupportedVehicleWheelsPressure.Car, electricEngine);
            }
            else
            {
                Fuel fuelEngine = new Fuel(Fuel.eFuelType.Octan95, 1.2f);
                newCar = new Car(io_SerialNumber, (int)eSupportedVehicleWheels.Car, (int)eSupportedVehicleWheelsPressure.Car, fuelEngine);
            }
            return newCar;
        }
        internal static Vehicle createMotorcycle(string io_SerialNumber, bool i_IsElectric)
        {
            Motorcycle newMotorcycle = null;
            if (i_IsElectric)
            {

                Electric electricEngine = new Electric(1.2f);
                newMotorcycle = new Motorcycle(io_SerialNumber, (int)eSupportedVehicleWheels.Motorcycle, (int)eSupportedVehicleWheelsPressure.Motorcycle, electricEngine);
            }
            else
            {
                Fuel fuelEngeine = new Fuel(Fuel.eFuelType.Octan98, 1.2f);
                newMotorcycle = new Motorcycle(io_SerialNumber, (int)eSupportedVehicleWheels.Motorcycle, (int)eSupportedVehicleWheelsPressure.Motorcycle, fuelEngeine);
            }
            return newMotorcycle;
        }
        internal static Vehicle createTruck(string io_SerialNumber)
        {
            Fuel fuelEngeine = new Fuel(Fuel.eFuelType.Soler, 1.2f);
            Truck truckToCreate = new Truck(io_SerialNumber, (int)eSupportedVehicleWheels.Truck, (int)eSupportedVehicleWheelsPressure.Truck, fuelEngeine);
            return truckToCreate;
        }
        internal static void getVehicleInfo(out Dictionary<ePossibleValues, object> io_DataDictionary, int i_VehicleChoice)
        {
            io_DataDictionary = new Dictionary<ePossibleValues, object>();
            if (i_VehicleChoice > 0 && i_VehicleChoice < sr_SupportedVehicleArr.Length)
            {
                eSupportedVehcile currentSupportedVehcile = (eSupportedVehcile)i_VehicleChoice;
                io_DataDictionary.Add(ePossibleValues.WheelManufacturer, string.Empty);
                io_DataDictionary.Add(ePossibleValues.ModelName, string.Empty);
                io_DataDictionary.Add(ePossibleValues.CurentWheelAirPressure, string.Empty);

                if (currentSupportedVehcile.Equals(eSupportedVehcile.ElectricMotorcycle) || currentSupportedVehcile.Equals(eSupportedVehcile.ElectricCar))
                {
                    io_DataDictionary.Add(ePossibleValues.CurrentHours, string.Empty);
                }
                else
                {
                    io_DataDictionary.Add(ePossibleValues.CurrentFuel, string.Empty);
                }

                if (currentSupportedVehcile.Equals(eSupportedVehcile.ElectricMotorcycle) || currentSupportedVehcile.Equals(eSupportedVehcile.RegularMotorcycle))
                {

                }

            }
        }
    }
}
