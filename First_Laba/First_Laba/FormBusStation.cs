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
    public partial class FormBusStation : Form
    {
        /// <summary>
        /// Объект от класса-автовокзала
        /// </summary>
        BusStation<ITransport> station;

        public FormBusStation()
        {
            InitializeComponent();
            station = new BusStation<ITransport>(20, pictureBoxStation.Width,
           pictureBoxStation.Height);
            Draw();
        }

        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxStation.Width, pictureBoxStation.Height);
            Graphics gr = Graphics.FromImage(bmp);
            station.Draw(gr);
            pictureBoxStation.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автобус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetBus_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var bus = new Bus(100, 1000, dialog.Color);
                int place = station + bus;
                Draw();
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать двухэтажный автобус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetDoubleBus_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var bus = new DoubleBus(100, 1000, dialog.Color, dialogDop.Color, true, true);
                    int place = station + bus;
                    Draw();
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeBus_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var bus = station - (Convert.ToInt32(maskedTextBox.Text) - 1);
                if (bus != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeBus.Width,
                   pictureBoxTakeBus.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    bus.SetPosition(30, 30, pictureBoxTakeBus.Width,
                   pictureBoxTakeBus.Height);
                    bus.DrawBus(gr);
                    pictureBoxTakeBus.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeBus.Width,
                   pictureBoxTakeBus.Height);
                    pictureBoxTakeBus.Image = bmp;
                }
                Draw();
            }
        }
    }
}
