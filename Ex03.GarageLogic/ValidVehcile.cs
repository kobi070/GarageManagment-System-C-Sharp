using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// ValidVehcile class is responsible to the creation of new vehciles
    /// Also the managment of Vehciles and how to dynamicly create or change vehciles in our Garage
    /// using enums to determine key factors for each type of vehcile 
    /// </summary>
    internal enum eSupportedVehcile
    {
        ElectricMotorcycle =1,
        RegularMotorcycle,
        ElectricCar,
        RegularCar,
        Truck
    }
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
        
        private const float k_Precentege = 100f;
        private const bool k_Electric = true;
        private static readonly string[] sr_SupportedVehicleArr = new string[] { "Regular Motorcycle", "Electric Motorcycle", "Regular Car", "Electric Car", "Truck" };
        internal static string[] SupportedVehicleArr
        {
            get { return sr_SupportedVehicleArr; }
        }
        internal static Vehicle createVehicle(eSupportedVehcile i_VehiclesChoice, string io_LicenseNumber)
        {
            Vehicle newVehicle = null;

            switch (i_VehiclesChoice)
            {
                case eSupportedVehcile.ElectricMotorcycle:
                    {
                        newVehicle = CreateMotorcycle(io_LicenseNumber, k_Electric);
                        break;
                    }

                case eSupportedVehcile.ElectricCar:
                    {
                        newVehicle = CreateCar(io_LicenseNumber, k_Electric);
                        break;
                    }

                case eSupportedVehcile.Truck:
                    {
                        newVehicle = CreateTruck(io_LicenseNumber);
                        break;
                    }

                case eSupportedVehcile.RegularMotorcycle:
                    {
                        newVehicle = CreateMotorcycle(io_LicenseNumber, !k_Electric);
                        break;
                    }

                case eSupportedVehcile.RegularCar:
                    {
                        newVehicle = CreateCar(io_LicenseNumber, !k_Electric);
                        break;
                    }
            }

            return newVehicle;
        }
        internal static Vehicle CreateCar(string io_SerialNumber, bool i_IsElectric)
        {
            /// Create a new care based on supported vehciles and thier attributes
            /// return a new Car which contains Electric based or Fuel based engine
            Car newCar = null;
            if (i_IsElectric)
            {
                Electric electricEngine = new Electric(1.2f);
                newCar = new Car(io_SerialNumber, (int)eSupportedVehicleWheels.Car, (int)eSupportedVehicleWheelsPressure.Car, electricEngine);
            }
            else
            {
                Fuel fuelEngine = new Fuel(eFuelType.Octan95, 1.2f);
                newCar = new Car(io_SerialNumber, (int)eSupportedVehicleWheels.Car, (int)eSupportedVehicleWheelsPressure.Car, fuelEngine);
            }

            return newCar;
        }
  
        internal static Vehicle CreateMotorcycle(string io_SerialNumber, bool i_IsElectric)
        {

            /// Create a new motorcycle based on supported vehciles and thier attributes
            /// return a new Motorcycle which contains Electric based or Fuel based engine
            Motorcycle newMotorcycle = null;
            if (i_IsElectric)
            {

                Electric electricEngine = new Electric(1.2f);
                newMotorcycle = new Motorcycle(io_SerialNumber, (int)eSupportedVehicleWheels.Motorcycle, (int)eSupportedVehicleWheelsPressure.Motorcycle, electricEngine);
            }
            else
            {
                Fuel fuelEngeine = new Fuel(eFuelType.Octan98, 1.2f);
                newMotorcycle = new Motorcycle(io_SerialNumber, (int)eSupportedVehicleWheels.Motorcycle, (int)eSupportedVehicleWheelsPressure.Motorcycle, fuelEngeine);
            }
            return newMotorcycle;
        }
        internal static Vehicle CreateTruck(string io_SerialNumber)
        {
            /// Creation of a truck
            Fuel fuelEngeine = new Fuel(eFuelType.Soler, 1.2f);
            Truck truckToCreate = new Truck(io_SerialNumber, (int)eSupportedVehicleWheels.Truck, (int)eSupportedVehicleWheelsPressure.Truck, fuelEngeine);
            return truckToCreate;
        }
        internal static void GetVehicleInfo(out Dictionary<ePossibleValues, object> io_DataDictionary, int i_VehicleChoice)
        {
            /// Add to our data Dictionary by each vehcile attributes
            /// each vehicle has is kind of attributes which are unique to him
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
                    io_DataDictionary.Add(ePossibleValues.LicenseType, string.Empty);
                    io_DataDictionary.Add(ePossibleValues.EngineCapacity, string.Empty);
                }
                else if (currentSupportedVehcile.Equals(eSupportedVehcile.ElectricCar) || currentSupportedVehcile.Equals(eSupportedVehcile.RegularCar))
                {
                    io_DataDictionary.Add(ePossibleValues.Color, string.Empty);
                    io_DataDictionary.Add(ePossibleValues.Doors, string.Empty);
                }
                else
                {
                    io_DataDictionary.Add(ePossibleValues.DangerousChemicals, false);
                    io_DataDictionary.Add(ePossibleValues.CargoCpacity, string.Empty);
                }

            }

        }
        internal static void FillVehicleInfo(Vehicle io_Vehicle, Dictionary<ePossibleValues, object> i_DataDictionary)
        {
            if (i_DataDictionary.ContainsKey(ePossibleValues.ModelName))
            {
                io_Vehicle.ModelName = i_DataDictionary[ePossibleValues.ModelName].ToString();
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.CurrentFuel))
            {
                if (float.TryParse(i_DataDictionary[ePossibleValues.CurrentFuel].ToString(), out float currentFuel))
                {
                    Fuel fuelEngine = io_Vehicle.EngeingEnergey as Fuel;
                    fuelEngine.CurrentFuelPrecentege = currentFuel;
                    float fuelPrecentege = fuelEngine.CurrentFuelPrecentege / fuelEngine.MaxFuel;
                    io_Vehicle.EnergeyPrecentege = fuelPrecentege * k_Precentege;
                }
                else
                {
                    throw new FormatException("Invalid amount of fuel");
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.CurrentHours))
            {
                if (float.TryParse(i_DataDictionary[ePossibleValues.CurrentHours].ToString(), out float currentElectric))
                {
                    Electric electricEngine = io_Vehicle.EngeingEnergey as Electric;
                    electricEngine.TimeLeftInHouers = currentElectric/ 60f;
                    float electricPrecentege = electricEngine.TimeLeftInHouers / electricEngine.MaxTimeInHouers;
                    io_Vehicle.EnergeyPrecentege = electricPrecentege * k_Precentege;
                }
                else
                {
                    throw new FormatException("Invalid amount of hours in charger");
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.CurentWheelAirPressure))
            {
                if(float.TryParse(i_DataDictionary[ePossibleValues.CurentWheelAirPressure].ToString(), out float currentAirPsi))
                {
                    for (int i = 0; i < io_Vehicle.Wheels.Length; i++)
                    {
                        io_Vehicle.Wheels[i].CurrentPsi = currentAirPsi;
                    }
                }
                else
                {
                    throw new FormatException("Invalid PSI");
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.WheelManufacturer))
            {
                for (int i = 0; i < io_Vehicle.Wheels.Length; i++)
                {
                        io_Vehicle.Wheels[i].Maneufacture = i_DataDictionary[ePossibleValues.WheelManufacturer].ToString();
                }   
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.LicenseType))
            {
                if (int.TryParse(i_DataDictionary[ePossibleValues.LicenseType].ToString(), out int currentLicenseType))
                {
                    (io_Vehicle as Motorcycle).LicenseType = (eLicenseType) currentLicenseType;
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.Doors))
            {
                if(int.TryParse(i_DataDictionary[ePossibleValues.Doors].ToString(), out int currentDoors))
                {
                    (io_Vehicle as Car).CarNumOfDoors = (eCarNumOfDoors) currentDoors;
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.Color))
            {
                if (int.TryParse(i_DataDictionary[ePossibleValues.Color].ToString(), out int currentColor))
                {
                    (io_Vehicle as Car).CarColour = (eCarColour) currentColor;
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.CargoCpacity))
            {
                if(float.TryParse(i_DataDictionary[ePossibleValues.CargoCpacity].ToString(), out float cargoCapacity))
                {
                    (io_Vehicle as Truck).CargoCapacity =  cargoCapacity;
                }
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.DangerousChemicals))
            {
                (io_Vehicle as Truck).HasDangerousChemicals = (bool)i_DataDictionary[ePossibleValues.DangerousChemicals];
            }
            if (i_DataDictionary.ContainsKey(ePossibleValues.EngineCapacity))
            {
                if (int.TryParse(i_DataDictionary[ePossibleValues.EngineCapacity].ToString(), out int currentEngineCapacity))
                {
                    (io_Vehicle as Motorcycle).EngeineCapacity = currentEngineCapacity;
                }
            }
        }
        internal static string ShowCaseValidVehciles()
        {
            StringBuilder stringBuilderValidVehciles = new StringBuilder();
            int index = 1;

            foreach (string vehicle in sr_SupportedVehicleArr)
            {
                stringBuilderValidVehciles.Append(string.Format($"{index++}." +
                    $"{vehicle}{Environment.NewLine}"));
            }
            return stringBuilderValidVehciles.ToString();
        }
    }
}
