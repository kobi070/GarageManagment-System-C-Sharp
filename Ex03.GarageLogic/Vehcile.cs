using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private readonly string r_LicenseNumber;
        private readonly object r_EngeingEnergey;
        private readonly Wheel[] r_Wheels;
        private string m_ModelName;
        private float m_PrecentegeOfEnergey;

        // Constructors
        internal Vehicle(string i_LicenseNumber, int i_NumOfWheels, float io_MaxAirPressure, object i_EnergyType)
        {
            this.r_LicenseNumber = i_LicenseNumber;
            this.r_EngeingEnergey = i_EnergyType;
            this.r_Wheels = new Wheel[i_NumOfWheels];
            for (int j = 0; j < i_NumOfWheels; j++)
            {
                this.r_Wheels[j] = new Wheel(io_MaxAirPressure);
            }
        }
        // Properties
        internal string ModelName
        {
            get { return this.m_ModelName; }
            set
            {
                if (value != string.Empty)
                {
                    this.m_ModelName = value;
                }
                else
                {
                    Exception ex = new Exception("");
                    /// ...
                }
            }
        }
        internal string LicenseNumber 
        { 
            get { return this.r_LicenseNumber; }
        }
        internal float EnergeyPrecentege
        {
            get
            {
                return this.m_PrecentegeOfEnergey;
            }
            set
            {
                if (value >= 0 && value < 100)
                {
                    this.m_PrecentegeOfEnergey = value;
                }
                else
                {
                    Exception ex = new Exception("Invalid recentege of enrgey");
                    /// ...
                }
            }
        }
        internal object EngeingEnergey
        {
            get { return this.r_EngeingEnergey; }
        }
        internal Wheel[] Wheels 
        {
            get { return r_Wheels; }
        }
        public override string ToString()
        {
            StringBuilder vehicle = new StringBuilder();
            int index = 1;

            vehicle.Append(string.Format(
                "License Number is: {0}{1}Model Name is: {2}{1}Wheels info: {1}",
                LicenseNumber,
                Environment.NewLine,
                ModelName));

            foreach (Wheel currentWheel in Wheels)
            {
                vehicle.Append(string.Format("Wheel #{0}. {1}", index++, currentWheel.ToString()));
            }

            vehicle.Append(string.Format("Enregy is ({0})% full. {1}", this.m_PrecentegeOfEnergey, this.r_EngeingEnergey.ToString()));

            return vehicle.ToString();
        }
    }
}
