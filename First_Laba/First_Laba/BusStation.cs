using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    /// <summary>
    /// Параметризованны класс для хранения набора объектов от интерфейса ITransport
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusStation<T> where T : class, ITransport
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private Dictionary<int, T> _places;

        /// <summary>
        /// Максимальное количество мест на парковке
        /// </summary>
        private int _maxCount;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int PictureWidth { get; set; }

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int PictureHeight { get; set; }

        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private int _placeSizeWidth = 210;

        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private int _placeSizeHeight = 80;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sizes">Количество мест на парковке</param>
        /// <param name="pictureWidth">Рамзер парковки - ширина</param>
        /// <param name="pictureHeight">Рамзер парковки - высота</param>
        public BusStation(int sizes, int pictureWidth, int pictureHeight)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автобус
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="bus">Добавляемый автобус</param>
        /// <returns></returns>
        public static int operator +(BusStation<T> b, T bus)
        {
            if (b._places.Count == b._maxCount)
            {
                throw new StationOverflowException();
            }
            for (int i = 0; i < b._maxCount; i++)
            {
                if (b.CheckFreePlace(i))
                {
                    b._places.Add(i, bus);
                    b._places[i].SetPosition(5 + i / 5 * b._placeSizeWidth + 5,
                    i % 5 * b._placeSizeHeight + 15, b.PictureWidth,
                    b.PictureHeight);
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автобус
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(BusStation<T> b, int index)
        {
            if (!b.CheckFreePlace(index))
            {
                T bus = b._places[index];
                b._places.Remove(index);
                return bus;
            }
            throw new StationNotFoundException(index);
        }

        /// <summary>
        /// Метод проверки заполнености парковочного места (ячейки массива)
        /// </summary>
        /// <param name="index">Номер парковочного места (порядковый номер в массиве)</param>
        /// <returns></returns>
        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }

        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            var keys = _places.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                _places[keys[i]].DrawBus(g);
            }
        }

        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы праковки
            g.DrawRectangle(pen, 0, 0, (_maxCount / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _maxCount / 5; i++)
            {//отрисовываем, по 5 мест на линии
                for (int j = 0; j < 6; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                    i * _placeSizeWidth + 110, j * _placeSizeHeight);

                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public T this[int ind]
        {
            get
            {
                if (_places.ContainsKey(ind))
                {
                    return _places[ind];
                }
                throw new StationNotFoundException(ind);
            }
            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 5, ind % 5 *
                    _placeSizeHeight + 15, PictureWidth, PictureHeight);
                }
                else
                {
                    throw new StationOccupiedPlaceException(ind);
                }
            }
        }
    }
}
