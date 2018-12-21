using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    class StationOverflowException : Exception
    {
        public StationOverflowException() : base("На парковке нет свободных мест")
        { }
    }
}
