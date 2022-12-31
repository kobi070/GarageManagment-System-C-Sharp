using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Customer> r_Customers = new Dictionary<string, Customer>();

        public bool addNewVehicle(string io_CustomerName, string io_PhoneNumber, string io_VehicleSerialNumber, int io_serveiceStatus )
        {
            bool toAdd = false;

            if (isExist(io_VehicleSerialNumber))
            {
                try
                {
                    this.r_Customers[io_VehicleSerialNumber].VehicleStatus = eServeiceStatus.InRepair;
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format($"{io_VehicleSerialNumber} is not in the system"), ex);
                }
            }
            else
            {
                if (Enum.IsDefined(typeof(eSupportedVehcile), io_serveiceStatus))
                {
                    Vehicle newVehicle = ValidVehcile.createVehicle((eSupportedVehcile)io_serveiceStatus, io_VehicleSerialNumber);
                    Customer newCustomer = new Customer(io_CustomerName, io_PhoneNumber, newVehicle, (eServeiceStatus) io_serveiceStatus);
                    r_Customers.Add(io_VehicleSerialNumber, newCustomer);
                    toAdd = true;
                }
                else
                {
                    Exception ex = new Exception("Invalid vehcile choice");
                    throw new ValueOutOfRangeException(ex, (float)numOfSupportedVehciles(), 0f);
                }
            }
            return toAdd;
        }
        public bool InflateWheels(string i_SerialNumber)
        {
            bool isInflated = false;
            float toAdd = 0f;

            if (isExist(i_SerialNumber))
            {
                if (isInRapir(i_SerialNumber))
                {
                    try
                    {
                        Wheel[] currentWheels = r_Customers[i_SerialNumber].Vehicle.Wheels;
                        for (int i = 0; i < currentWheels.Length; i++)
                        {
                            toAdd = currentWheels[i].MaxPsi - currentWheels[i].CurrentPsi;
                            currentWheels[i].CurrentPsi += toAdd;
                            isInflated = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format($"License numbe {i_SerialNumber} is not in the system"), ex);
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format($"{i_SerialNumber}" +
                        $" is not in {eServeiceStatus.InRepair.ToString()}" +
                        $", You can not work on this car"));
                }
            }
            return isInflated;
        }
        public bool fuelGas(string i_SerialNumber, int io_FuelType, int io_FuelToAdd)
        {
            bool isFull = false;

            if (isExist(i_SerialNumber))
            {
                if (isInRapir(i_SerialNumber))
                {
                    if(Enum.IsDefined(typeof(eFuelType), io_FuelType))
                    {
                        if (r_Customers[i_SerialNumber].Vehicle.EngeingEnergey is Fuel)
                        {
                            Fuel fuelEngine = r_Customers[i_SerialNumber].Vehicle.EngeingEnergey as Fuel;
                            isFull = fuelEngine.toFuel(io_FuelToAdd, (eFuelType)io_FuelType);

                            if (isFull)
                            {
                                float fuelPrecentege = fuelEngine.CurrentFuelPrecentege / fuelEngine.MaxFuel;
                                r_Customers[i_SerialNumber].Vehicle.EnergeyPrecentege = fuelPrecentege * 100f;
                            }
                        }
                        else
                        {
                            Exception ex = new Exception("Choice of fuel type is invalid");
                            throw new ValueOutOfRangeException(ex, (float)NumOfFuelTypes(), 1f);
                        }
                    }
                    else
                    {
                        throw new ArgumentException(string.Format($"{(eFuelType)io_FuelType} is does not exist."));
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format($"{i_SerialNumber}" +
                        $"is not in {eServeiceStatus.InRepair}"));
                }
            }
            return isFull;
        }
        public bool chargeEnergey(string i_SerialNumber, int io_MinToAdd)
        {
            bool isFull = false;

            if (isExist(i_SerialNumber))
            {
                if (isInRapir(i_SerialNumber))
                {
                    if (r_Customers[i_SerialNumber].Vehicle.EngeingEnergey is Electric)
                    {
                        Electric electricEngine = r_Customers[i_SerialNumber].Vehicle.EngeingEnergey as Electric;
                        isFull = electricEngine.toCharge(io_MinToAdd / 60f);

                        if (isFull)
                        {
                            float electricPrecentege = electricEngine.MaxTimeInHouers - electricEngine.TimeLeftInHouers;
                            r_Customers[i_SerialNumber].Vehicle.EnergeyPrecentege = electricPrecentege * 100f;
                        }
                    }
                    else
                    {
                        throw new FormatException(string.Format($"{i_SerialNumber} is not an electric type"));
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format($"{i_SerialNumber} is not {eServeiceStatus.InRepair}"));
                }
            }
            return isFull;
        }
        public int NumOfFuelTypes()
        {
            return Enum.GetValues(typeof(eFuelType)).Length;
        }
        public bool isInRapir(string i_LicenseNumber)
        {
            return r_Customers[i_LicenseNumber].VehicleStatus.Equals(eServeiceStatus.InRepair);
        }
        public bool isExist(string io_LicenseNumber)
        {
            return this.r_Customers.ContainsKey(io_LicenseNumber);
        }
        public int numOfSupportedVehciles()
        {
            return ValidVehcile.SupportedVehicleArr.Length;
        }
        public string ShowServiceStatus()
        {
            return Customer.showCaseServiceStatus();
        }
        public string ShowCarsColor()
        {
            return Car.showCaseColor();
        }
        public string ShowCarsDoors()
        {
            return Car.showCaseDoors();
        }
        public string ShowFuelTypes()
        {
            return Fuel.ShowFuelTypes();
        }
        public string ShowMotorcycleLicense()
        {
            return Motorcycle.showCaseLicenseType();
        }
        public bool ChangeServiceStatus(string i_SerialNumber, int i_StatusType)
        {
            bool isChanged = false;

            if (isExist(i_SerialNumber))
            {
                if (Enum.IsDefined(typeof(eServeiceStatus), i_StatusType))
                {
                    try
                    {
                        r_Customers[i_SerialNumber].VehicleStatus = (eServeiceStatus)i_StatusType;
                        isChanged = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format($"{i_SerialNumber} is not in the system", ex));
                    }
                }
                else
                {
                    Exception ex = new Exception("Choice of vehcile status is invalid");
                }
            }
            return isChanged;
        }
        
        public string GarageVehcileFilter(bool i_InRapir, bool i_Fixed, bool i_Paid)
        {
            int indexForString = 1;
            StringBuilder filterStringBuilder = new StringBuilder();
            
            foreach (KeyValuePair<string, Customer> customer in r_Customers)
            {
                if (i_InRapir && customer.Value.VehicleStatus.Equals(eServeiceStatus.InRepair))
                {
                    filterStringBuilder.Append(string.Format($"{indexForString++}. {customer.Key}{Environment.NewLine}"));
                }
                if (i_Fixed && customer.Value.VehicleStatus.Equals(eServeiceStatus.Fixed))
                {
                    filterStringBuilder.Append(string.Format($"{indexForString++}. {customer.Key}{Environment.NewLine}"));
                }
                if (i_Paid && customer.Value.VehicleStatus.Equals(eServeiceStatus.Paid))
                {
                    filterStringBuilder.Append(string.Format($"{indexForString++}. {customer.Key}{Environment.NewLine}"));
                }
            }
            if (filterStringBuilder.ToString().Equals(string.Empty))
            {
                filterStringBuilder.Append(string.Format($"Garage is empty"));
            }
            return filterStringBuilder.ToString();
        }
    }
}
