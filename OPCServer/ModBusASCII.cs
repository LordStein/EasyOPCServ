using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCServer
{
    /// <summary>
    /// Класс для работы с ModBus ASCII протоколом
    /// </summary>
    class ModBusASCII
    {
        #region константы

        /// <summary>
        /// код команды чтения регистров настройки
        /// </summary>
        public static byte RDSettReg = 0x3;    // 
        /// <summary>
        /// код комнады чтения регистров данных
        /// </summary>
        public static byte RDDatReg = 0x4;     // 
        /// <summary>
        /// размер буфера передачи
        /// </summary>
        const byte IOBufSize = 17;

        #endregion

        #region Переменные класса

        /// <summary>
        /// Порт связи
        /// </summary>
        System.IO.Ports.SerialPort Port;

        /// <summary>
        /// Буффер принятых данных
        /// </summary>
        public byte[] EnteredData { private set; get; }
        /// <summary>
        /// Количество данных в буфере
        /// </summary>
        public int DataCount { private set; get; }

        #endregion

        #region Методы класса

        /// <summary>
        /// Конструктор с заданием порта, открывает порт
        /// </summary>
        /// <param name="Port">Ссылка на порт</param>
        public ModBusASCII(System.IO.Ports.SerialPort Port)
        {
            this.Port = Port;
            if (!this.Port.IsOpen) this.Port.Open();
            //this.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Port_DataReceived);
            EnteredData = new byte[256];
            DataCount = 0;
        }

        /*
        /// <summary>
        /// Обработчик приема данных, записывает их в приемный буфер
        /// по мере приема
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            int count = Port.BytesToRead;
            byte[] inbuf = new byte[count];
            byte[] bind = new byte[4];
            Port.Read(inbuf, 0, count);
            for (int i = 0; i < count; i++) EnteredData[i + startind] = inbuf[i];
            startind = startind + count;
        } */

        /// <summary>
        /// Прочитать данные из буфера в числовом формате, данные помещаются в буфер EnteredData, количество в DataCount
        /// </summary>
        /// <returns></returns>
        public void ReadData()
        {
            DataCount = Port.BytesToRead;
            Port.Read(EnteredData, 0, DataCount);
            if (DataCount > 3) EnteredData = ChrtoBin(EnteredData, DataCount);
        }

        /// <summary>
        /// Очистка буфера приема, и числа значащих байт
        /// </summary>
        void ClearBuffer()
        {
            for (int i = 0; i < EnteredData.Length; EnteredData[i++] = 0);
            DataCount = 0;
        }

        // проверено!
        /// <summary>
        /// Расчет контрольной суммы
        /// </summary>
        /// <param name="data">Данные для расчета</param>
        /// <returns></returns>
        private byte CRC(byte[] data)
        {
            byte temp = 0;
            for (int i = 1; i < data.Length - 3; temp += data[i++]) ;
            return (byte)(0xFF - temp + 1);
        }

        /// <summary>
        /// Запрос на чтение указанного кол-ва регистров настроек с заданного адреса
        /// </summary>
        /// <param name="SlaveAdres">Адрес ведомого</param>
        /// <param name="StartRegAdr">Начальный адрес считывания</param>
        /// <param name="NumRegtoRead">Кол-во считываемых регистров</param>
        /// <returns></returns>
        public int ReadSettingsRegisters(byte SlaveAdres, int StartRegAdr, int NumRegtoRead)
        {
            return SendCom(SlaveAdres, StartRegAdr, NumRegtoRead, RDSettReg);
        }

        /// <summary>
        /// Запрос на чтение указанного кол-ва регистров данных с заданного адреса
        /// </summary>
        /// <param name="SlaveAdres">Адрес ведомого</param>
        /// <param name="StartRegAdr">Начальный адрес считывания</param>
        /// <param name="NumRegtoRead">Кол-во считываемых регистров</param>
        /// <returns></returns>
        public int ReadDataRegisters(byte SlaveAdres, int StartRegAdr, int NumRegtoRead)
        {
            return SendCom(SlaveAdres, StartRegAdr, NumRegtoRead, RDDatReg);
        }

        /// <summary>
        /// Универсальная команда отправки запроса ведомому устройству
        /// </summary>
        /// <param name="SlaveAdres">Адрес ведомого</param>
        /// <param name="StartRegAdr">Начальный адрес считывания</param>
        /// <param name="NumRegtoRead">Кол-во считываемых регистров</param>
        /// <param name="comand">Код команды</param>
        /// <returns></returns>
        public int SendCom(byte SlaveAdres, int StartRegAdr, int NumRegtoRead, byte comand)
        {
            // проверка правильности адреса и его корректировка под протокол
            // в котором считывание начинается не с указанного адреса,
            // а со следующего
            if (StartRegAdr > 0) StartRegAdr--;
            else if (StartRegAdr < 0) StartRegAdr = -StartRegAdr;

            int exitcode = 0;
            byte[] iobuff = new byte[10];
            iobuff[0] = 0x3A;
            iobuff[1] = SlaveAdres;
            iobuff[2] = comand;
            iobuff[3] = (byte)((StartRegAdr & 0xFF00) >> 8);
            iobuff[4] = (byte)(StartRegAdr & 0xFF);
            iobuff[5] = (byte)((NumRegtoRead & 0xFF00) >> 8);
            iobuff[6] = (byte)(NumRegtoRead & 0xFF);
            iobuff[7] = CRC(iobuff);
            iobuff[8] = 0xD;
            iobuff[9] = 0xA;
            byte[] outbuff = BintoChr(iobuff);
            if (Port.IsOpen)
            {
                ClearBuffer();
                try
                {
                    Port.DiscardInBuffer();
                    Port.Write(outbuff, 0, outbuff.Length);
                }
                catch (Exception)
                {
                    exitcode = 1;
                }
            }
            return exitcode;
        }

        // проверено!
        /// <summary>
        /// Преобразование массива цифр в массив кодов ASCII для отправки
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] BintoChr(byte[] data)
        {
            byte[] mout = new byte[IOBufSize];
            mout[0] = data[0];
            mout[IOBufSize - 2] = data[data.Length - 2];
            mout[IOBufSize - 1] = data[data.Length - 1];
            for (int i = 1; i < data.Length - 2; i++)
            {
                if (data[i] <= 15)
                {
                    mout[i * 2 - 1] = BintoChr(0);
                    mout[i * 2] = BintoChr(data[i]);
                }
                else
                {
                    mout[i * 2 - 1] = BintoChr((byte)(data[i] / 16));
                    mout[i * 2] = BintoChr((byte)(data[i] % 16));
                }
            }
            return mout;
        }


        // проверено!
        /// <summary>
        /// Преобразует число 0-15 (0-F) в его ASCII код
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte BintoChr(byte data)
        {
            if ((data >= 0) & (data <= 9)) return (byte)(data + 48);
            else if ((data >= 10) & (data <= 15)) return (byte)(data + 65);
            else return 48;
        }

        // проверено!
        /// <summary>
        /// Преобразование полученного массива символов ASCII в числа
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] ChrtoBin(byte[] data)
        {
            byte[] mout = new byte[data.Length];
            mout[0] = data[0];
            for (int i = 1; i < data.Length; i += 2)
            {
                mout[(i + 1) / 2] =(byte)((ChrtoBin(data[i]) * 16) + ChrtoBin(data[i + 1]));
            }
            return mout;
        }

        /// <summary>
        /// Преобразование полученного массива символов ASCII в числа, заданного количества байт
        /// </summary>
        /// <param name="data">Массив источник</param>
        /// <param name="count">Число значащих байт в массиве</param>
        public byte[] ChrtoBin(byte[] data, int count)
        {
            byte[] mout = new byte[data.Length];
            mout[0] = data[0];
            for (int i = 1; i < count; i += 2)
            {
                mout[(i + 1) / 2] = (byte)((ChrtoBin(data[i]) * 16) + ChrtoBin(data[i + 1]));
            }
            return mout;
        }

        /// <summary>
        /// Преобразование символа (48-57, 65-70) в число 0 - 15
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte ChrtoBin(byte data)
        {
            if ((data >= 48) & (data <= 57)) return (byte)(data - 48);
            else if ((data >= 65) & (data <= 70)) return (byte)(data - 65);
            else return 0;
        }

        /// <summary>
        /// Извлечение целого числа из принятых данных
        /// </summary>
        /// <param name="data">Принятые данные</param>
        /// <param name="ofset">Смещение</param>
        /// <returns></returns>
        public byte BintoByte(byte[] data, int ofset)
        {
            if ((ofset < data.Length) & (ofset >= 0))
                return data[ofset];
            else return 0;
        }

        /// <summary>
        /// Извлечение целого числа из принятых данных
        /// </summary>
        /// <param name="data">Принятые данные</param>
        /// <param name="ofset">Смещение</param>
        /// <returns></returns>
        public int BintoInt(byte[] data, int ofset)
        {
            if ((ofset <= (data.Length - 2)) & (ofset >= 0))
                return data[ofset] << 8 + data[ofset + 1];
            else return 0;
        }

        // Проверено!
        /// <summary>
        /// Извлечение вещественного числа из принятых данных
        /// </summary>
        /// <param name="data">Принятые данные</param>
        /// <param name="ofset">Смещение</param>
        /// <returns></returns>
        public float BintoFloat(byte[] data, int ofset)
        {
            if ((ofset <= (data.Length - 4)) & (ofset >= 0))
            {
                byte[] aga = new byte[4];
                aga[3] = data[ofset + 3];
                aga[2] = data[ofset + 2];
                aga[1] = data[ofset + 1];
                aga[0] = data[ofset];
                return BitConverter.ToSingle(aga, 0);
            }
            else return 0;
        }



        #endregion

    }
}
