using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OPCServer
{
    /// <summary>
    /// Диск 250М, свойства и методы доступа к прибору
    /// </summary>
    class D250M
    {
        #region Константы
        /// <summary>
        /// Величина задержки приема
        /// </summary>
        const int Rdelay = 100;

        const int atestregister = 0x254;

        #endregion

        #region Переменные класса
        /// <summary>
        /// Таймер сброса задержки чтения
        /// </summary>
        System.Timers.Timer Delayer;

        /// <summary>
        /// Порт связи
        /// </summary>
        ModBusASCII Device;

        /// <summary>
        /// Для организации выхода из задержки
        /// </summary>
        bool stop = false;

        #endregion

        #region Свойства

        /// <summary>
        /// Адрес ведомого, 0-127
        /// </summary>
        public byte Adres
        {
            get
            {
                return Adres;
            }
            set
            {
                if ((Adres >= 0) & (Adres <= 127)) Adres = value;
                else Adres = 0;
            }
        }

        /// <summary>
        /// Тестовый адрес считывания
        /// </summary>
        public int testregister
        {
            get
            {
                Device.SendCom(this.Adres, atestregister, 2, ModBusASCII.RDSettReg);
                // тут пауза получения информации
                Delayer.Enabled = true;
                while (!stop) ;
                //
                Device.ReadData();
                return Device.BintoInt(Device.EnteredData, 5);
            }
        }

        #endregion



        #region Методы

        /// <summary>
        /// Конструктор с передачей порта связи и заданием адреса
        /// </summary>
        /// <param name="COM">"Порт для связи"</param>
        /// <param name="Adres">"Адрес Диск 250М"</param>
        public D250M(System.IO.Ports.SerialPort COM, byte Adres)
        {
            Device = new ModBusASCII(COM);
            this.Adres = Adres;
            Delayer = new System.Timers.Timer(Rdelay);
            Delayer.Enabled = false;
            Delayer.Elapsed += new System.Timers.ElapsedEventHandler(Delayer_Elapsed);
        }

        /// <summary>
        /// Сбрасывает цикл ожидания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Delayer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            stop = true;
            Delayer.Enabled = false;
        }

        #endregion
    }
}
