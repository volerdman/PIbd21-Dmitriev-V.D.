using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    public class Bus
    {
        /// <summary>
        /// Левая координата отрисовки автобуса
        /// </summary>
        private float _startPosX;

        /// <summary>
        /// Правая координата отрисовки автобуса
        /// </summary>
        private float _startPosY;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;

        //Высота окна отрисовки
        private int _pictureHeight;

        /// <summary>
        /// Ширина отрисовки автобуса
        /// </summary>
        private const int busWidth = 85;

        /// <summary>
        /// Ширина отрисовки автобуса
        /// </summary>
        private const int busHeight = 50;

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }

        /// <summary>
        /// Вес автобуса
        /// </summary>
        public float Weight { private set; get; }

        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
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
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="SecondFloor">Признак наличия второго этажа</param>
        /// <param name="BlackWindow">Признак наличия тонировки</param>
        public Bus(int maxSpeed, float weight, Color mainColor, Color dopColor, bool secondFloor, bool blackWindow)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            SecondFloor = secondFloor;
            BlackWindow = blackWindow;
        }

        /// <summary>
        /// Установка позиции автобуса
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }


        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
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
                case Direction.Diagonal:
                    if ((_startPosY - step + 5 > 0) && (_startPosX + step < _pictureWidth - busWidth + 5))
                    {
                        _startPosY -= step;
                        _startPosX += step;
                    }
                    break;

                //вверх
                case Direction.Up:
                    if (_startPosY - step + 5 > 0)
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
        public void DrawBus(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            Brush dop = new SolidBrush(DopColor);
            Brush back = new SolidBrush(Color.Silver);
            Brush black = new SolidBrush(Color.Black);
            Brush blue = new SolidBrush(Color.Blue);

            // отрисуем сперва второй этаж (чтобы потом отрисовка первого на него "легла")
            if (SecondFloor)
            {
                g.FillEllipse(br, _startPosX, _startPosY, 20, 40);
                g.FillEllipse(br, _startPosX + 65, _startPosY, 20, 40);
                g.FillRectangle(br, _startPosX + 10, _startPosY, 65, 25);
                g.DrawRectangle(pen, _startPosX + 5, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 25, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 45, _startPosY + 10, 10, 10);
                g.DrawRectangle(pen, _startPosX + 65, _startPosY + 10, 10, 10);

            }

            //теперь отрисуем первый этаж автобуса
            g.FillRectangle(br, _startPosX + 1, _startPosY + 25, 84, 20);
            g.DrawRectangle(pen, _startPosX + 5, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 25, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 45, _startPosY + 27, 10, 10);
            g.DrawRectangle(pen, _startPosX + 68, _startPosY + 25, 12, 12);
            g.FillRectangle(dop, _startPosX + 1, _startPosY + 22, 84, 2);
            g.FillEllipse(black, _startPosX + 11, _startPosY + 38, 12, 12);
            g.FillEllipse(black, _startPosX + 71, _startPosY + 38, 12, 12);
            g.FillEllipse(back, _startPosX + 13, _startPosY + 40, 8, 8);
            g.FillEllipse(back, _startPosX + 73, _startPosY + 40, 8, 8);
            g.FillRectangle(back, _startPosX + 82, _startPosY + 25, 86, 10);

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
            else
            {
                g.FillRectangle(blue, _startPosX + 5, _startPosY + 10, 10, 10);
                g.FillRectangle(blue, _startPosX + 25, _startPosY + 10, 10, 10);
                g.FillRectangle(blue, _startPosX + 45, _startPosY + 10, 10, 10);
                g.FillRectangle(blue, _startPosX + 65, _startPosY + 10, 10, 10);
                g.FillRectangle(blue, _startPosX + 5, _startPosY + 27, 10, 10);
                g.FillRectangle(blue, _startPosX + 25, _startPosY + 27, 10, 10);
                g.FillRectangle(blue, _startPosX + 45, _startPosY + 27, 10, 10);
                g.FillRectangle(blue, _startPosX + 68, _startPosY + 25, 12, 12);
            }
        }
    }
}
