using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class DoubleBus : Bus, IComparable<DoubleBus>, IEquatable<DoubleBus>
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия второго этажа
        /// </summary>
        public bool SecondFloor { private set; get; }

        /// <summary>
        /// Признак наличия тонировки
        /// </summary>
        public bool BlackWindow { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="SecondFloor">Признак наличия второго этажа</param>
        /// <param name="BlackWindow">Признак наличия тонировки</param>
        public DoubleBus(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
            secondFloor, bool blackWindow) :
            base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            SecondFloor = secondFloor;
            BlackWindow = blackWindow;
        }

        public DoubleBus(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 6)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                SecondFloor = Convert.ToBoolean(strs[4]);
                BlackWindow = Convert.ToBoolean(strs[5]);
            }
        }

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
                case Direction.Down:
                    if (_startPosY + step - 7.5 < _pictureHeight - busHeight)
                    {
                        _startPosY += step;
                    }
                    break;
                //вниз
                case Direction.Up:
                    if (_startPosY - step + 5 > 0)
                    {
                        _startPosY -= step;
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
            Brush dop = new SolidBrush(DopColor);
            Brush black = new SolidBrush(Color.Black);
            Brush blue = new SolidBrush(Color.Blue);

            // отрисуем сперва второй этаж (чтобы потом отрисовка первого на него "легла")
            if (SecondFloor)
            {
                g.FillEllipse(dop, _startPosX, _startPosY, 20, 40);
                g.FillEllipse(dop, _startPosX + 65, _startPosY, 20, 40);
                g.FillRectangle(dop, _startPosX + 10, _startPosY, 65, 25);
                g.DrawRectangle(pen, _startPosX + 5, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 25, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 45, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 65, _startPosY + 10, 10, 10);
            }

            //отрисуем основной кузов
            base.DrawBus(g);

            //отрисуем окна
            g.FillRectangle(blue, _startPosX + 5, _startPosY + 10, 10, 10);
            g.FillRectangle(blue, _startPosX + 25, _startPosY + 10, 10, 10);
            g.FillRectangle(blue, _startPosX + 45, _startPosY + 10, 10, 10);
            g.FillRectangle(blue, _startPosX + 65, _startPosY + 10, 10, 10);

            //тонировка
            if (BlackWindow)
            {
                g.FillRectangle(black, _startPosX + 5, _startPosY + 10, 10, 10);
                g.FillRectangle(black, _startPosX + 25, _startPosY + 10, 10, 10);
                g.FillRectangle(black, _startPosX + 45, _startPosY + 10, 10, 10);
                g.FillRectangle(black, _startPosX + 65, _startPosY + 10, 10, 10);
                g.FillRectangle(black, _startPosX + 5, _startPosY + 27, 10, 10);
                g.FillRectangle(black, _startPosX + 25, _startPosY + 27, 10, 10);
                g.FillRectangle(black, _startPosX + 45, _startPosY + 27, 10, 10);
                g.FillRectangle(black, _startPosX + 68, _startPosY + 25, 12, 12);
            }
        }

        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + SecondFloor + ";" +
           BlackWindow;
        }
        /// <summary>
        /// Метод интерфейса IComparable для класса DoubleBus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(DoubleBus other)
        {
            var res = (this is Bus).CompareTo(other is Bus);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (SecondFloor != other.SecondFloor)
            {
                return SecondFloor.CompareTo(other.SecondFloor);
            }
            if (BlackWindow != other.BlackWindow)
            {
                return BlackWindow.CompareTo(other.BlackWindow);
            }
            return 0;
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса DoubleBus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DoubleBus other)
        {
            var res = (this as Bus).Equals(other as Bus);
            if (!res)
            {
                return res;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (SecondFloor != other.SecondFloor)
            {
                return false;
            }
            if (BlackWindow != other.BlackWindow)
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
            DoubleBus busObj = obj as DoubleBus;
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
