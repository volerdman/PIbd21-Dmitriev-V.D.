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
        private T[] _places;

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
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автобус
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автобус</param>
        /// <returns></returns>
        public static int operator +(BusStation<T> b, T bus)
        {
            for (int i = 0; i < b._places.Length; i++)
            {
                if (b.CheckFreePlace(i))
                {
                    b._places[i] = bus;
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
            if (index < 0 || index > b._places.Length)
            {
                return null;
            }
            if (!b.CheckFreePlace(index))
            {
                T bus = b._places[index];
                b._places[index] = null;
                return bus;
            }
            return null;
        }

        /// <summary>
        /// Метод проверки заполнености парковочного места (ячейки массива)
        /// </summary>
        /// <param name="index">Номер парковочного места (порядковый номер в массиве)</param>
        /// <returns></returns>
        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }

        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                if (!CheckFreePlace(i))
                {//если место не пустое
                    _places[i].DrawBus(g);
                }
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
            g.DrawRectangle(pen, 0, 0, (_places.Length / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _places.Length / 5; i++)
            {//отрисовываем, по 5 мест на линии
                for (int j = 0; j < 6; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                    i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }
    }
}
