using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    public class Bus:PublicTransport
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
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="SecondFloor">Признак наличия второго этажа</param>
        /// <param name="BlackWindow">Признак наличия тонировки</param>
        public Bus(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
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
    }
}
