using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public enum eServeiceStatus
    {
        InRepair = 1,
        Fixed,
        Paid
    }
    internal class Customer
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;
        private readonly Vehicle r_Vechile;
        private eServeiceStatus m_VechileStatus;

        internal Customer(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle, eServeiceStatus i_VehicleStatus)
        {
            this.r_Name = i_Name;
            this.r_PhoneNumber = i_PhoneNumber;
            this.r_Vechile = i_Vehicle;
            this.m_VechileStatus = i_VehicleStatus;
        }
        internal string Name 
        {
            get 
            {
                return this.r_Name; 
            }
        }
        internal string PhoneNumber 
        {
            get 
            { 
                return this.r_PhoneNumber; 
            }
        }
        internal eServeiceStatus VehicleStatus 
        {
            get { return this.m_VechileStatus; }
            set
            {
                if(Enum.IsDefined(typeof(eServeiceStatus), value))
                {
                    this.m_VechileStatus = value;
                }
                else
                {
                    Exception ex = new Exception("Vehcile status is invalid");
                    throw new ValueOutOfRangeException(ex, (float)Enum.GetValues(typeof(eServeiceStatus)).Length, 1f);
                }
            }
        }
        internal Vehicle Vehicle 
        {
            get { return this.r_Vechile; }
        }
        internal static string showCaseServiceStatus()
        {
            StringBuilder stringServiceStatus = new StringBuilder();

            foreach (eServeiceStatus serveiceStatus in Enum.GetValues(typeof(eServeiceStatus)))
            {
                stringServiceStatus.Append(serveiceStatus.ToString() + " ");
            }
            return stringServiceStatus.ToString();
        }
        public override string ToString()
        {
            string strServiceStatus = string.Format(
                "The owner is {0} and his phone number is {1}{2}{3}Vehicle Status is: {4}",
                Name,
                PhoneNumber,
                Environment.NewLine,
                Vehicle.ToString(),
                VehicleStatus.ToString());
            return strServiceStatus;
        }
    }
}
