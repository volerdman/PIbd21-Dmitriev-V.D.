using System;
using System.Collections;
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
    public class BusStation<T>: IEnumerator<T>, IEnumerable<T>, IComparable<BusStation<T>>
        where T : class, ITransport
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
        /// Текущий элемент для вывода через IEnumerator (будет обращаться по своему
        /// индексу к ключу словаря, по которму будет возвращаться запись)
        /// </summary>
        private int _currentIndex;

        /// <summary>
        /// Получить порядковое место на парковке
        /// </summary>
        public int GetKey
        {
            get
            {
                return _places.Keys.ToList()[_currentIndex];
            }
        }
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
            _currentIndex = -1;
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
            if (b._places.ContainsValue(bus))
            {
                throw new StationAlreadyHaveException();
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
            foreach (var bus in _places)
            {
                bus.Value.DrawBus(g);
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

        /// <summary>
        /// Метод интерфейса IEnumerator для получения текущего элемента
        /// </summary>
        public T Current
        {
            get
            {
                return _places[_places.Keys.ToList()[_currentIndex]];
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для получения текущего элемента
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        {
            _places.Clear();
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или началу
        ///коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_currentIndex + 1 >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Метод интерфейса IComparable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BusStation<T> other)
        {
            if (_places.Count > other._places.Count)
            {
                return -1;
            }
            else if (_places.Count < other._places.Count)
            {
                return 1;
            }
            else if (_places.Count > 0)
            {
                var thisKeys = _places.Keys.ToList();
                var otherKeys = other._places.Keys.ToList();
                for (int i = 0; i < _places.Count; ++i)
                {
                    if (_places[thisKeys[i]] is Bus && other._places[thisKeys[i]] is DoubleBus)
                    {
                        return 1;
                    }
                    if (_places[thisKeys[i]] is DoubleBus && other._places[thisKeys[i]] is Bus)
                    {
                        return -1;
                    }
                    if (_places[thisKeys[i]] is Bus && other._places[thisKeys[i]] is Bus)
                    {
                        return (_places[thisKeys[i]] is Bus).CompareTo(other._places[thisKeys[i]] is Bus);
                    }
                    if (_places[thisKeys[i]] is DoubleBus && other._places[thisKeys[i]] is DoubleBus)
                    {
                        return (_places[thisKeys[i]] is DoubleBus).CompareTo(other._places[thisKeys[i]] is DoubleBus);
                    }
                }
            }
            return 0;
        }   
    }
}
