﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Fuel
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuel;
        private float m_CurrentFuelPrecentege;
        internal Fuel(eFuelType i_FuelType, float i_MaxFuel)
        {
            this.r_FuelType = i_FuelType;
            this.r_MaxFuel = i_MaxFuel;
            this.m_CurrentFuelPrecentege = 0f;
        }
        internal eFuelType FuelType
        {
            get { return this.r_FuelType; }
        }
        internal float MaxFuel
        {
            get
            {
                return this.m_CurrentFuelPrecentege;
            }
        }
        internal float CurrentFuelPrecentege
        {
            get
            {
                return this.m_CurrentFuelPrecentege;
            }
            set
            {
                if (this.m_CurrentFuelPrecentege >= 0 && value <= this.MaxFuel)
                {
                    this.m_CurrentFuelPrecentege = value;
                }
            }
        }
        internal bool toFuel(float i_AmountToFuel, eFuelType eFuelType)
        {
            bool isFinished = false;
            if (this.r_FuelType.Equals(eFuelType))
            {
                if (this.m_CurrentFuelPrecentege + i_AmountToFuel <= this.MaxFuel)
                {
                    this.m_CurrentFuelPrecentege += i_AmountToFuel;
                    isFinished = true;
                }
                else
                {
                    Exception ex = new Exception("Invalid amount of fuel to add");
                    /// need to create a new Exeption named ValueOutOfRangeException which handles ranges of psi, fuel etc...
                }
            }
            else
            {
                Exception ex = new Exception("Wrong kind of fuel");
                /// need to create a new Exeption named ValueOutOfRangeException which handles ranges of psi, fuel etc...
            }
            return isFinished;
        }
    }
}
