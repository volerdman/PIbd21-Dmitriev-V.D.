using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже есть автобус с такими же характеристиками"
    /// </summary>
    public class StationAlreadyHaveException : Exception
    {
        public StationAlreadyHaveException() : base("На парковке уже есть такая машина")
        { }
    }
}
