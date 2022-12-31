using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private  bool m_HasDangerousChemicals;
        private float m_CargoCapacity;

        internal Truck(string i_LicenseNumber, int i_NumOfWheels, float io_MaxAirPressure, object i_EnergyType) : base(i_LicenseNumber, i_NumOfWheels, io_MaxAirPressure, i_EnergyType)
        {
        }
        internal bool HasDangerousChemicals
        {
            get { return this.m_HasDangerousChemicals; }
            set { this.m_HasDangerousChemicals = value; }
        }
        internal float CargoCapacity
        {
            get { return this.m_CargoCapacity; }
            set
            {
                if (value >= 0)
                {
                    this.m_CargoCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Invalid cargo capacity");
                }
            }
        }
        public override string ToString()
        {
            string isDangerous = string.Empty;
            if (this.HasDangerousChemicals)
            {
                isDangerous = "does";
            }
            else
            {
                isDangerous = "does not";
            }
            string strTruck = string.Format($"{base.ToString()}. The truck  " +
                $" {isDangerous} contains dangerous chemicals" +
                $"and is cargo capacity is {this.CargoCapacity}" +
                $"{Environment.NewLine}");
            return strTruck;
        }
    }
}
