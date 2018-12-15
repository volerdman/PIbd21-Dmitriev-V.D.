using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    class MultiLevelBusStation
    {
        /// <summary>
        /// Список с уровнями парковки
        /// </summary>
        List<BusStation<ITransport>> stationStages;

        /// <summary>
        /// Сколько мест на каждом уровне
        /// </summary>
        private const int countPlaces = 20;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelBusStation(int countStages, int pictureWidth, int pictureHeight)
        {
            stationStages = new List<BusStation<ITransport>>();
            for (int i = 0; i < countStages; ++i)
            {
                stationStages.Add(new BusStation<ITransport>(countPlaces, pictureWidth,
               pictureHeight));
            }
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public BusStation<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < stationStages.Count)
                {
                    return stationStages[ind];
                }
                return null;
            }
        }
    }
}
