using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    internal enum eLicenseType
    {
        A = 1,
        A1,
        AA,
        B
    }
    internal class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngeineCapacity;

        internal Motorcycle(string i_LicenseNumber, int i_NumOfWheels, float io_MaxAirPressure, object i_EnergyType) :
            base(i_LicenseNumber, i_NumOfWheels, io_MaxAirPressure, i_EnergyType)
        {
        }

        internal eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    this.m_LicenseType = value;
                }
                else
                {
                    throw new FormatException("");
                }
            }
        }
        internal int EngeineCapacity
        {
            get { return m_EngeineCapacity; }
            set
            {
                if (value >= 0)
                {
                    m_EngeineCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Invalid argument for engeine capacity");
                }
            }
        }
        internal static string showCaseLicenseType()
        {
            StringBuilder stringLicenseTypes = new StringBuilder();

            foreach (eLicenseType licenseType in Enum.GetValues(typeof(eLicenseType)))
            {
                stringLicenseTypes.Append(string.Format($"{(int)licenseType}" +
                    $". {licenseType.ToString()}" +
                    $"{Environment.NewLine}"));
            }
            return stringLicenseTypes.ToString();
        }

        public override string ToString()
        {
            string strMotorcycle = string.Format($"{base.ToString()}" +
                $"The motorcycle license type is {this.LicenseType}" +
                $" and his engeine capacity is {this.EngeineCapacity}" +
                $"{Environment.NewLine} ");
            return strMotorcycle;
        }
    }
}
