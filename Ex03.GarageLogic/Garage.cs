using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private readonly Dictionary<string, Customer> r_Customers = new Dictionary<string, Customer>();

        internal Garage(string io_CustomerName, string io_PhoneNumber, string io_VehicleSerialNumber, int io_serveiceStatus )
        {
            bool alredyExist = false;

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
                    ///...
                }

            }
        }
        internal bool isExist(string io_LicenseNumber)
        {
            return this.r_Customers.ContainsKey(io_LicenseNumber);
        }
    }
}
