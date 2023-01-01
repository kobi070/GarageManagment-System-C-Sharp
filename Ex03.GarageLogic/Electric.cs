using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric
    {
        private const int k_MinTime = 0;

        private float m_TimeLeftInHours;
        private readonly float r_MaxTimeInHours;

        public Electric(float i_MaxTimeInHours)
        {
            this.r_MaxTimeInHours = i_MaxTimeInHours;
        }
        public float TimeLeftInHouers
        {
            get { return this.m_TimeLeftInHours; }
            set
            {
                if (this.m_TimeLeftInHours >= k_MinTime && this.m_TimeLeftInHours >= value)
                {
                    this.m_TimeLeftInHours = value;
                }
                else
                {
                    Exception ex = new Exception("Invalid charge precentege");
                    throw new ValueOutOfRangeException(ex, MaxTimeInHouers, k_MinTime);
                }

            }
        }
        public float MaxTimeInHouers { get { return this.r_MaxTimeInHours; } }
        public bool toCharge(float io_HoursToCharge)
        {
            bool isValidToUpdate = false;
            if (this.TimeLeftInHouers + io_HoursToCharge <= this.MaxTimeInHouers)
            {
                this.m_TimeLeftInHours = this.m_TimeLeftInHours + io_HoursToCharge;
                isValidToUpdate = true;
            }
            else
            {
                Exception ex = new Exception("Value of hours to add is invalid");
                /// need to create a new Exeption named ValueOutOfRangeException which handles ranges of psi, fuel etc...
            }
            return isValidToUpdate;
        }
        public override string ToString()
        {
            string electric = string.Format(
                "The battay has {0} hours left out of {1} hours{2}",
                this.TimeLeftInHouers,
                this.MaxTimeInHouers,
                Environment.NewLine);

            return electric;
        }
    }
}
