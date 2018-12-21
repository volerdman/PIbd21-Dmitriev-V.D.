using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    public class Bus:PublicTransport, IComparable<Bus>, IEquatable<Bus>
    {
        /// <summary>
        /// Ширина отрисовки автобуса
        /// </summary>
        protected const int busWidth = 85;

        /// <summary>
        /// Ширина отрисовки автобуса
        /// </summary>
        protected const int busHeight = 50;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Bus(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public Bus(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - busWidth + 5)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step + 5 > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step + 25 > 0)
                    {
                        _startPosY -= step;
                    }
                    break;

                //вниз
                case Direction.Down:
                    if (_startPosY + step - 7 < _pictureHeight - busHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка автобуса
        /// </summary>
        /// <param name="g"></param>
        public override void DrawBus(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            Brush back = new SolidBrush(Color.Gray);
            Brush black = new SolidBrush(Color.Black);
            Brush blue = new SolidBrush(Color.Blue);

            //теперь отрисуем первый этаж автобуса
            g.FillRectangle(br, _startPosX + 1, _startPosY + 25, 84, 20);
            g.DrawRectangle(pen, _startPosX + 5, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 25, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 45, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 68, _startPosY + 25, 12, 12);
            g.FillRectangle(black, _startPosX + 1, _startPosY + 22, 84, 2);
            g.FillEllipse(black, _startPosX + 11, _startPosY + 38, 12, 12);
            g.FillEllipse(black, _startPosX + 71, _startPosY + 38, 12, 12);
            g.FillEllipse(back, _startPosX + 13, _startPosY + 40, 8, 8);
            g.FillEllipse(back, _startPosX + 73, _startPosY + 40, 8, 8);
            g.FillRectangle(back, _startPosX + 82, _startPosY + 25, 86, 10);

            //окна
            g.FillRectangle(black, _startPosX + 5, _startPosY + 27, 10, 10);
            g.FillRectangle(black, _startPosX + 25, _startPosY + 27, 10, 10);   
            g.FillRectangle(black, _startPosX + 45, _startPosY + 27, 10, 10);
            g.FillRectangle(black, _startPosX + 68, _startPosY + 25, 12, 12);
        }

        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }

        /// <summary>
        /// Метод интерфейса IComparable для класса Bus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Bus other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Bus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Bus other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Bus busObj = obj as Bus;
            if (busObj == null)
            {
                return false;
            }
            else
            {
                return Equals(busObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
