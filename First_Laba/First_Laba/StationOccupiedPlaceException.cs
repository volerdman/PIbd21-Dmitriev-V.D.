using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    class StationOccupiedPlaceException : Exception
    {
        public StationOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит автобус")
        { }
    }
}
