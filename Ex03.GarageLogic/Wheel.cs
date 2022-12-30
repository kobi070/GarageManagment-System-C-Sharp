﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly float r_MaxPsi;
        private string m_Manufactore;
        private float m_CurrentPsi;

        internal string Maneufacture
        {
            get
            {
                return this.m_Manufactore;
            }
            set
            {
                if (string.Empty != value)
                {
                    this.Maneufacture = value;
                }
                else
                {
                    throw new FormatException("Invalid manuefacture's name");
                }
            }

        }
        internal float CurrentPsi
        {
            get { return this.m_CurrentPsi; }
            set
            {
                if (value >= 0 && value <= r_MaxPsi)
                {
                    this.m_CurrentPsi = value;
                }
                else
                {
                    Exception ex = new Exception("Invalid wheel pressure");
                    /// ....
                }
            }
        }
        internal float MaxPsi
        {
            get { return this.r_MaxPsi; }
        }
        internal Wheel(float i_NumOfWheels)
        {
            r_MaxPsi = i_NumOfWheels;
        }
        public bool InflateWheel(float i_InflationRate)
        {
            bool isValidWheel = false;
            if (i_InflationRate + this.CurrentPsi <= r_MaxPsi)
            {
                this.m_CurrentPsi += i_InflationRate;
                isValidWheel = true;
            }
            else
            {
                Exception ex = new Exception("");
                /// ....
            }
            return isValidWheel;
        }
    }
}
