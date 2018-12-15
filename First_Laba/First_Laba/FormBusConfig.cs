using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Laba
{
    public partial class FormBusConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        ITransport bus = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event busDelegate eventAddBus;

        public FormBusConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelPink.MouseDown += panelColor_MouseDown;
            panelMaroon.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawBus()
        {
            if (bus != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxBus.Width, pictureBoxBus.Height);
                Graphics gr = Graphics.FromImage(bmp);
                bus.SetPosition(5, 5, pictureBoxBus.Width, pictureBoxBus.Height);
                bus.DrawBus(gr);
                pictureBoxBus.Image = bmp;
            }
        }


        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(busDelegate ev)
        {
            if (eventAddBus == null)
            {
                eventAddBus = new busDelegate(ev);
            }
            else
            {
                eventAddBus += ev;
            }
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBus_MouseDown(object sender, MouseEventArgs e)
        {
            labelBus.DoDragDrop(labelBus.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void labelDoubleBus_MouseDown(object sender, MouseEventArgs e)
        {
            labelDoubleBus.DoDragDrop(labelDoubleBus.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelBus_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelBus_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный автобус":
                    bus = new Bus(100, 500, Color.White);
                    break;
                case "Двухэтажный автобус":
                    bus = new DoubleBus(100, 500, Color.White, Color.Black, true, true);
                    break;
            }
            DrawBus();
        }

        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (bus != null)
            {
                bus.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawBus();
            }
        }

        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (bus != null)
            {
                if (bus is DoubleBus)
                {
                    (bus as DoubleBus).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawBus();
                }
            }
        }

        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddBus?.Invoke(bus);
            Close();
        }
    }
}

