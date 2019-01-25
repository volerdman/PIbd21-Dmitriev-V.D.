using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    class StationNotFoundException : Exception
    {
        public StationNotFoundException(int i) : base("Не найден автобус по месту " +i)
        { }
    }
}
