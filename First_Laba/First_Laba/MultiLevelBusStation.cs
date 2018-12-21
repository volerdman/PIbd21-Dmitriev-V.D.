using System;
using System.Collections.Generic;
using System.IO;
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
        /// Ширина окна отрисовки
        /// </summary>
        private int pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;

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

        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                //Записываем количество уровней
                WriteToFile("CountLeveles:" + stationStages.Count + Environment.NewLine,
               fs);
                foreach (var level in stationStages)
                {
                    //Начинаем уровень
                    WriteToFile("Level" + Environment.NewLine, fs);
                    for (int i = 0; i < countPlaces; i++)
                    {
                        try
                        {
                            var bus = level[i];
                            if (bus != null)
                            {
                                //Записываем тип мшаины
                                if (bus.GetType().Name == "Bus")
                                {
                                    WriteToFile(i + ":Bus:", fs);
                                }
                                if (bus.GetType().Name == "DoubleBus")
                                {
                                    WriteToFile(i + ":DoubleBus:", fs);
                                }
                                //Записываемые параметры
                                WriteToFile(bus + Environment.NewLine, fs);
                            }   
                        }
                        catch (Exception ex)
                        {

                        }
                        finally { }
                    }
                }
            }
        }

        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }

        /// Загрузка нформации по автобусам на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    byte[] b = new byte[fs.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (bs.Read(b, 0, b.Length) > 0)
                    {
                        bufferTextFromFile += temp.GetString(b);
                    }
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("CountLeveles"))
            {
                //считываем количество уровней
                int count = Convert.ToInt32(strs[0].Split(':')[1]);
                if (stationStages != null)
                {
                    stationStages.Clear();
                }
                stationStages = new List<BusStation<ITransport>>(count);
            }
            else
            {
                //если нет такой записи, то это не те данные
                throw new Exception("Неверный формат файла");
            }
            int counter = -1;
            ITransport bus = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                //идем по считанным записям
                if (strs[i] == "Level")
                {
                    //начинаем новый уровень
                    counter++;
                    stationStages.Add(new BusStation<ITransport>(countPlaces, pictureWidth,
                    pictureHeight));
                    continue;
                }
                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].Split(':')[1] == "Bus")
                {
                    bus = new Bus(strs[i].Split(':')[2]);
                }
                else if (strs[i].Split(':')[1] == "DoubleBus")
                {
                    bus = new DoubleBus(strs[i].Split(':')[2]);
                }
                stationStages[counter][Convert.ToInt32(strs[i].Split(':')[0])] = bus;
            }
        }
    }
}
