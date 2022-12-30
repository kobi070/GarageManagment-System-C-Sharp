using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public enum eCarColour
        {
            red = 1,
            blue,
            white,
            grey
        }
        public enum eCarNumOfDoors
        {
            two = 1,
            three = 2,
            four = 3,
            five = 4
        }

        public eCarColour m_CarColour;
        public eCarNumOfDoors m_NumOfDoors;

        internal Car(string i_LicenseNumber, int i_NumOfWheels, float io_MaxAirPressure, object i_EnergyType) : base(i_LicenseNumber, i_NumOfWheels, io_MaxAirPressure, i_EnergyType)
        {

        }
        internal eCarColour CarColour
        {
            get { return m_CarColour; }
            set
            {
                if (Enum.IsDefined(typeof(eCarColour), value))
                {
                    m_CarColour = value;
                }
                else
                {
                    Exception ex = new Exception("");
                    /// ... ValueOutOfRange
                }
            }
        }
        internal eCarNumOfDoors CarNumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set
            {
                if (Enum.IsDefined(typeof(eCarNumOfDoors), value))
                {
                    this.m_NumOfDoors = value;
                }
                else
                {
                    Exception ex = new Exception("");
                    /// ... ValueOutOfRange ==> need to create
                }
            }
        }
        internal static string showCaseColor()
        {
            StringBuilder colorString = new StringBuilder();

            foreach (eCarColour color in Enum.GetValues(typeof(eCarColour)))
            {
                colorString.Append(string.Format($"{(int)color}" +
                    $". {color.ToString()}" +
                    $"{Environment.NewLine}"));
            }
            return colorString.ToString();
        }
        internal static string showCaseDoors()
        {
            StringBuilder doorsString = new StringBuilder();

            foreach (eCarNumOfDoors door in Enum.GetValues(typeof(eCarNumOfDoors)))
            {
                doorsString.Append(string.Format($"{(int)door}" +
                    $". {door.ToString()}" +
                    $"{Environment.NewLine}"));
            }
            return doorsString.ToString();
        }
        public override string ToString()
        {
            string strCar = string.Format($"{base.ToString()}" +
                $" car is {this.CarColour}" +
                $" and has {this.CarNumOfDoors}" +
                $" doors" +
                $"{Environment.NewLine}");
            return strCar;
        }
    }
}
