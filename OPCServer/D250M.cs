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
        // струткура записи архива
        public struct ArchRecord
        {
            public byte Hour;
            public byte Minute;
            public byte Second;
            public byte Month;
            public byte Year;
            public float Data;
            public byte Rele;
        }

        public struct D250Error
        {
            /// <summary>
            ///  Признак ошибки прошлой операции
            /// </summary>
            public bool isError;

            /// <summary>
            /// Код ошибки
            /// </summary>
            public int ErrorCode;

            /// <summary>
            /// Текст ошибки
            /// </summary>
            public string Message;
        }

        #region Константы
        /// <summary>
        /// Величина задержки приема
        /// </summary>
        const int Rdelay             = 100;

        const int aSerialNumber      = 0x02;

        const int aYearofProduction  = 0x01;

        const int aMonthofProdaction = 0x01;

        const int aArchRecord        = 0x10;

        const int aDataNow           = 0x00;

        const int aErrorReg          = 0x02;

        #endregion

        #region Переменные класса
        /// <summary>
        /// Таймер сброса задержки чтения
        /// </summary>
        System.Timers.Timer Delayer;

        /// <summary>
        /// Ошибки
        /// </summary>
        public D250Error Error;

        /// <summary>
        /// Порт связи
        /// </summary>
        ModBusASCII Device;

        /// <summary>
        /// Для организации выхода из задержки
        /// </summary>
        bool stop = false;

        byte aadres;

        #endregion

        #region Свойства

        /// <summary>
        /// Адрес ведомого, 0-127
        /// </summary>
        public byte Adres
        {
            get
            {
                return aadres;
            }
            set
            {
                if ((value >= 0) & (value <= 127)) aadres = value;
                else aadres = 0;
            }
        }

        /// <summary>
        /// Тестовый адрес считывания
        /// </summary>
        public int SerialNumber
        {
            get
            {
                Error.isError = false;
                if (Device.SendCom(this.Adres, aSerialNumber, 1, ModBusASCII.RDSettReg) == 1)
                {
                    Error.isError = true;
                    Error.ErrorCode = 250;
                    Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                    return 0;
                }
                else
                {
                    // тут пауза получения информации
                    Delayer.Enabled = true;
                    while (!stop) ;
                    //
                    stop = false;
                    int kod = Device.ReadData();
                    if (kod != 0)
                    {
                        SetErrStr(kod);
                        return 0;
                    }
                    else
                    return Device.BintoInt(Device.EnteredData, 4);
                }
            }
        }

        /// <summary>
        /// Данные последнего измерения
        /// </summary>
        public float DataNow
        {
            get
            {
                Error.isError = false;
                if (Device.SendCom(this.Adres, aDataNow, 2, ModBusASCII.RDDatReg) == 1)
                {
                    Error.isError = true;
                    Error.ErrorCode = 250;
                    Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                    return 0;
                }
                else
                {
                    // тут пауза получения информации
                    Delayer.Enabled = true;
                    while (!stop) ;
                    //
                    stop = false;
                    int kod = Device.ReadData();
                    if (kod != 0)
                    {
                        SetErrStr(kod);
                        return 0;
                    }
                    else
                        return Device.BintoFloat(Device.EnteredData, 4);
                }
            }
        }
        /// <summary>
        /// Регистр состояния ошибок
        /// </summary>
        public string ErrorReg
        {
            get
            {
                Error.isError = false;
                if (Device.SendCom(this.Adres, aErrorReg, 1, ModBusASCII.RDDatReg) == 1)
                {
                    Error.isError = true;
                    Error.ErrorCode = 250;
                    Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                    return Error.Message;
                }
                else
                {
                    // тут пауза получения информации
                    Delayer.Enabled = true;
                    while (!stop) ;
                    //
                    stop = false;
                    int kod = Device.ReadData();
                    if (kod != 0)
                    {
                        SetErrStr(kod);
                        return Error.Message;
                    }
                    else
                    {
                        string errorcode = "";
                        byte error = Device.BintoByte(Device.EnteredData, 4);
                        if ((error & 1) == 1) errorcode += "Ошибка АЦП ";
                        if ((error & 2) == 2) errorcode += "Ошибка записи/чтения EPROM ";
                        if ((error & 4) == 4) errorcode += "Ошибка ЖКИ-индикатора";
                        return errorcode;
                    }
                }

            }
        }

        /// <summary>
        /// Год производства прибора
        /// </summary>
        public int YearofProduction
        {
            get
            {
                Error.isError = false;
                if (Device.SendCom(this.Adres, aYearofProduction, 1, ModBusASCII.RDSettReg) == 1)
                {
                    //iserror = true;
                    //errorcode = "Ошибка работы COM-порта " + Device.Portname + ", запрос не отправлен.";
                    Error.isError = true;
                    Error.ErrorCode = 250;
                    Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                    return 0;
                }
                else
                {
                    // тут пауза получения информации
                    Delayer.Enabled = true;
                    while (!stop) ;
                    //
                    stop = false;
                    int kod = Device.ReadData();
                    if (kod != 0)
                    {
                        //iserror = true;
                        SetErrStr(kod);
                        return 0;
                    }
                    else
                        return Device.BintoByte(Device.EnteredData, 5);
                }
            }
        }

        /// <summary>
        /// Месяц изготовления прибора
        /// </summary>
        public int MonthofProdaction
        {
            get
            {
                Error.isError = false;
                if (Device.SendCom(this.Adres, aMonthofProdaction, 1, ModBusASCII.RDSettReg) == 1)
                {
                    Error.isError = true;
                    Error.ErrorCode = 250;
                    Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                    return 0;
                }
                else
                {
                    // тут пауза получения информации
                    Delayer.Enabled = true;
                    while (!stop) ;
                    //
                    stop = false;
                    int kod = Device.ReadData();
                    if (kod != 0)
                    {
                        SetErrStr(kod);
                        return 0;
                    }
                    else
                        return Device.BintoByte(Device.EnteredData, 4);
                }
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
            Error.isError = false;
            Error.Message = "";
            Device = new ModBusASCII(COM);
            if (Device.porterror)
            {
                Error.isError = true;
                Error.ErrorCode = 251;
                Error.Message = Device.porterrstr;
            }
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

        /// <summary>
        /// Чтение последней записи архива, при успехе возвращает true
        /// </summary>
        /// <returns></returns>
        public bool GetLastArchRecord(ref ArchRecord ArchRec)
        {
            Error.isError = false;
            if (Device.SendCom(this.Adres, aArchRecord, 5, ModBusASCII.RDDatReg) == 1)
            {
                Error.isError = true;
                Error.ErrorCode = 250;
                Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не отправлен.";
                return false;
            }
            else
            {
                // тут пауза получения информации
                Delayer.Enabled = true;
                while (!stop) ;
                //
                stop = false;
                int kod = Device.ReadData();
                if (kod != 0)
                {
                    SetErrStr(kod);
                    return false;
                }
                else
                {
                    ArchRec.Hour = Device.BintoByte(Device.EnteredData, 4);
                    ArchRec.Minute = Device.BintoByte(Device.EnteredData, 5);
                    ArchRec.Second = Device.BintoByte(Device.EnteredData, 6);
                    ArchRec.Month = Device.BintoByte(Device.EnteredData, 8);
                    ArchRec.Year = Device.BintoByte(Device.EnteredData, 9);
                    ArchRec.Data = Device.BintoFloat(Device.EnteredData, 10);
                    ArchRec.Rele = Device.BintoByte(Device.EnteredData, 14);
                    return true;
                }
            }            
        }

        private void SetErrStr(int erkod)
        {
            Error.isError = true;
            Error.Message = "";
            Error.ErrorCode = erkod;
            if (erkod == 1) Error.Message = "Ошибка COM-порта " + Device.Portname + ", запрос не принят.";
            if (erkod == 2) Error.Message = "Часть сообщения потеряна или устройство не отвечает, по адресу" + this.Adres + ".";
            if (erkod == 3) Error.Message = "Ошибка CRC, устройства по адресу " + this.Adres + ".";
            if (erkod > 10)
            {
                erkod -= 10;
                if ((erkod & 1) == 1) Error.Message += "Ошибка АЦП, ";
                if ((erkod & 2) == 2) Error.Message += "Ошибка записи/чтения EPROM, ";
                if ((erkod & 4) == 4) Error.Message += "Ошибка ЖКИ-индикатора, ";
                if ((erkod & 8) == 8) Error.Message += "Обрыв датчика, ";
                //if ((erkod & 16) == 16) errorcode += "Резерв, ";
                if ((erkod & 32) == 32) Error.Message += "Обращение к неизвестному регистру, ";
                if ((erkod & 64) == 64) Error.Message += "Неизвестная команда, ";
                if ((erkod & 128) == 128) Error.Message += "Ошибка CRC, ";
                Error.Message += "утройства по адресу " + this.Adres + ".";
            }
        }

        /// <summary>
        /// Проверка связи с прибором
        /// </summary>
        /// <returns> Возвращает признак наличия связи</returns>
        public bool IsOnLine()
        {
            int temp = YearofProduction;
            if (Error.isError) return false;
            else return true;
        }

        #endregion
    }
}
