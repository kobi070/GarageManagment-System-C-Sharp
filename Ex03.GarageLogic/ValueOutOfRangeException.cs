using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        internal ValueOutOfRangeException(Exception i_InnerException, float i_maxValue, float i_minValue) :
            base(String.Format($"Value was not in range {i_minValue} - {i_maxValue} "), i_InnerException)
        {
            this.m_MaxValue = i_maxValue;
            this.m_MinValue = i_minValue;
        }
    }
}
