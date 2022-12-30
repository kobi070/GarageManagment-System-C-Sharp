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
                return r_Name; 
            }
        }
        internal string PhoneNumber 
        {
            get 
            { 
                return r_PhoneNumber; 
            }
        }
        internal Vehicle Vehicle 
        {
            get { return r_Vechile; }
        }
    }
}
