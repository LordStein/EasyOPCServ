using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;

namespace OPCServer
{
    /// <summary>
    /// основной класс программы
    /// </summary>
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        /*
         * const string userID = "ST";
         * const string password = "12345";
         * const string dataSource = "XE";
         * 
         * const string ConnectionString = "User Id=" + userID +
                     ";Password=" + password +
                     ";Data Source=" + dataSource + ";";
           const string ConnectionString = "Data Source=" + dataSource + ";" + "User Id=" + userID +
                     ";Password=" + password + ";"; */

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        const string ConnectionString = "Data Source=(Description = (Address_list = (Address= (Protocol = TCP)(Host = comp)(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));User ID=ST;Password=1234";

        /// <summary>
        /// частота опроса в мс, желательно не меньше 100*Dnum
        /// </summary>
        const int ReadRate = 5000;

        /// <summary>
        /// Максимальное число устройств
        /// </summary>
        const int Dnum = 16;

        D250M testDev;

        float data = 0;

        /// <summary>
        /// Число опрашиваемых устройств
        /// </summary>
        int DevCount = 0;

        /// <summary>
        /// Массив адресов опрашиваемых устройств
        /// </summary>
        int[] DevMask = new int[Dnum];

        /// <summary>
        /// Код последней ошибки устройства
        /// </summary>
        int[] LastErr = new int[Dnum];

        /// <summary>
        /// Номер текущего считываемого устройства
        /// </summary>
        int nowReading = 0;

        /// <summary>
        /// Признак старта циклического опроса
        /// </summary>
        bool oprosstarted = false;

        /// <summary>
        /// Соединение к БД
        /// </summary>
        OracleConnection OracleBaseCon;
        
        /// <summary>
        /// Признак успешного открытия БД
        /// </summary>
        bool BaseIsOpen = false;


        #region Методы
        /// <summary>
        /// Инициализация формы приложения
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы, начальная инициализация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //CPORT.Open();
            OracleBaseCon = new OracleConnection();
            ConnectToOrclBase();
            testDev = new D250M(CPORT, 1);
            if (testDev.Error.isError)
            {
                string Info;
                Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                this.textBox2.AppendText(Info + testDev.Error.Message + "\r\n");
                butReadOnce.Enabled = false;
                butStartCicleRead.Enabled = false;
                SaveErrortoBase();
            }
            oprosstarted = false;
            ReadMaskFromFile();
            ReBindQue();
            butStartCicleRead.Enabled = true;
            butStopCicleRead.Enabled = false;
        }

        /// <summary>
        /// На каждое считывание создается отдельный поток
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadDataOnce(object sender, EventArgs e)
        {
            //ModBusASCII test = new ModBusASCII(CPORT);
            //byte[] oleg = new byte[] {0x3A, 0x1, 0x4, 0x4, 0x0, 0x0, 0x48, 0xC1 ,0xD, 0xA };
            //byte[] oleg = new byte[] { 58, 48, 49, 48, 51, 48, 49, 51, 49, 48, 48, 48, 49, 49, 78, 13, 10};
            //58 48 49 48 51 48 49 51 49 48 48 48 49 49 78 13 10 строка
            /*byte[] itog = test.ChrtoBin(oleg);
            foreach (byte sim in itog)
            {
                textBox1.AppendText(sim + " ");
            }*/
            //textBox1.Text = test.BintoFloat(oleg, 4).ToString();
            Thread t = new Thread(new ThreadStart(this.ReadOnce));
            t.Start();
        }

        /// <summary>
        /// Считать данные один раз
        /// </summary>
        private void ReadOnce()
        {
            string Info;

            int _month = testDev.MonthofProdaction;
            if (testDev.Error.isError) ShowError();

            int _year = testDev.YearofProduction;
            if (testDev.Error.isError) ShowError();

            int _serial = testDev.SerialNumber;
            if (testDev.Error.isError) ShowError();

            //D250M.ArchRecord _testrecord = new D250M.ArchRecord();
            //if (!testDev.GetLastArchRecord(ref _testrecord)) ShowError();

            float datanow = testDev.DataNow;
            if (testDev.Error.isError) ShowError();

            Info = "Прибор произведен: " + _month + ".";
            if (_year < 10) Info += "200" + _year;
            else Info += "20" + _year;
            Info += ", серийный номер: " + _serial + "\r\n";
            //Info += "Последняя архивная запись: " + _testrecord.Hour + ":" + _testrecord.Minute;
            Info += " измерено: " + datanow + "\r\n";

            addtext(Info);
        }

        /// <summary>
        /// Отдельный поток считывания информации
        /// </summary>
        private void RefreshInfo()
        {
            data = testDev.DataNow;
            addtext("");
        }

        /// <summary>
        /// Внесение изменений в форму, по окончании считывания
        /// </summary>
        /// <param name="text"></param>
        private void addtext(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addtext);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text);
                if (oprosstarted) this.ReceiveDelay.Enabled = true;
            }
        }

        private void adderrortext(string text)
        {
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(adderrortext);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (this.textBox2 != null)
                    this.textBox2.AppendText(text);
            }
        }

        /// <summary>
        /// Чтение данных в цикле - подготовка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadInCycle(object sender, EventArgs e)
        {
            if (oprosstarted)
            {
                if (!testDev.Error.isError)
                {
                    SaveDattoBase(data);
                    foreach (D250Box Disk in panel1.Controls)
                    {
                        if ((Disk.isWork) && (Disk.Adres == testDev.Adres))
                        {
                            Disk.isError = false;
                            break;
                        }
                    }
                }
                else
                {
                    // проверим что данная ошибка происходит впервые
                    // для избежания множественной записи ошибки в базу
                    if (LastErr[nowReading] != testDev.Error.ErrorCode)
                    {
                        LastErr[nowReading] = testDev.Error.ErrorCode;
                        //запись ошибки в базу
                        SaveErrortoBase();
                        ShowError();
                        foreach (D250Box Disk in panel1.Controls)
                        {
                            if ((Disk.isWork) && (Disk.Adres == testDev.Adres))
                            {
                                Disk.isError = true;
                                break;
                            }
                        }
                    }
                }
            }
            ReceiveDelay.Enabled = false;

            testDev.Adres = (byte)DevMask[nowReading];
            nowReading++;
            if (nowReading > DevCount) nowReading = 0;

            if (!oprosstarted)
            {
                oprosstarted = true;
            }

            Thread t = new Thread(new ThreadStart(this.RefreshInfo));
            t.Start();
        }

        /// <summary>
        /// Вывести ошибку в лог
        /// </summary>
        private void ShowError()
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
            adderrortext(Info + testDev.Error.Message + "\r\n");
        }

        /// <summary>
        /// Попытка подключения к базе данных
        /// </summary>
        private void ConnectToOrclBase()
        {
            try
            {
                OracleBaseCon.ConnectionString = ConnectionString;
                OracleBaseCon.Open();
                BaseIsOpen = true;
                butConnectDB.Enabled = false;
                butDisconnectDB.Enabled = true;
            }
            catch (Exception exc)
            {
                butConnectDB.Enabled = true;
                BaseIsOpen = false;
                string Info;
                Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                textBox2.AppendText(Info + exc.Message + "\r\n");
            }

            // Тестовое чтение параметров из БД

            /*
            if (BaseIsOpen)
            {
                butWriteToBase.Enabled = true;
                butStartCicleRead.Enabled = true;
                try
                {
                    //команда записи в таблицу измерений, работает, осталось под нее написать класс-конвертер или процедуру отдельную
                    //string sql = "INSERT INTO devmdata VALUES(MESSNUMADDDAT.NEXTVAL, '6', '24-MAY-13 12:56:03 AM', '33')";

                    // sql = "select d250adres from devmdata where messagenum > 5";
                    // sql = "SELECT * FROM d250data WHERE data > 10";
                    // "select loc from dept" + " where deptno = 10"
                    
                    string sql;
                    sql = "SELECT * FROM d250data WHERE readtime > '24-May-13'";
                    OracleCommand cmd = new OracleCommand(sql, OracleBaseCon);
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++ )
                            textBox2.AppendText(dr.GetValue(i).ToString() + " ");
                        textBox2.AppendText("\r\n");
                    }
                }
                catch (Exception exc)
                {
                    string Info;
                    Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                    textBox2.AppendText(Info + exc.Message + "\r\n");
                }
            }
             */
        }

        private void SaveDattoBase(float dat)
        {
            string sql = "insert into d250data values(messnumadddat.nextval, '";
            sql += testDev.Adres + "', '";
            sql += DateTime.Now.Day + "-";
            string month = "";
            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "jan";
                    break;
                case 2:
                    month = "feb";
                    break;
                case 3:
                    month = "mar";
                    break;
                case 4:
                    month = "apr";
                    break;
                case 5:
                    month = "may";
                    break;
                case 6:
                    month = "jun";
                    break;
                case 7:
                    month = "jul";
                    break;
                case 8:
                    month = "aug";
                    break;
                case 9:
                    month = "sep";
                    break;
                case 10:
                    month = "oct";
                    break;
                case 11:
                    month = "nov";
                    break;
                case 12:
                    month = "dec";
                    break;
            }
            sql += month + "-" + (DateTime.Now.Year - 2000).ToString() + " ";
            int hour = DateTime.Now.Hour;

            if ((hour > 12)&(hour <= 23))
            {
                sql += (hour - 12).ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " PM";
            }
            else if (hour == 12)
            {
                sql += hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " PM";
            }
            else if (hour == 0)
            {
                sql += "12:" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " AM";
            }
            else sql += hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " AM";
            sql += "', '" + dat.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")) + "')";

            if (BaseIsOpen)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(sql, OracleBaseCon);
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                }
                catch (Exception exc)
                {
                    string Info;
                    Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                    textBox2.AppendText(Info + exc.Message + "\r\n");
                }
            }
            //textBox2.AppendText(sql);
        }

        /// <summary>
        /// Ручная запись в файл - тест
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualSaveToBase(object sender, EventArgs e)
        {
            SaveDattoBase((float)Math.PI*DateTime.Now.Second/3);
        }

        /// <summary>
        /// Закрытие программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramClosed(object sender, FormClosedEventArgs e)
        {
            if (CPORT != null) CPORT.Close();
            if (BaseIsOpen) OracleBaseCon.Close();            
        }

        /// <summary>
        /// Ручное соединение к базе - тест
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnecttoBaseClick(object sender, EventArgs e)
        {
            ConnectToOrclBase();
        }

        private void SaveMaskToFile()
        {
            BinaryWriter Mask;
            /* *********************************
             * запись маски устройств в файл
             * записываются все устройства из 
             * формы с адресами и факт их опроса
             * ********************************** */
            try
            {
                Mask = new BinaryWriter(new FileStream("settings.st", FileMode.Create));
                foreach (D250Box Disk in panel1.Controls)
                {
                    Mask.Write(Disk.Adres);
                    Mask.Write(Disk.isWork);
                }
                Mask.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Не возможно сохранить настройки", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ReadMaskFromFile()
        {
            BinaryReader Mask;
            /* *********************************
             * запись маски устройств в файл
             * записываются все устройства из 
             * формы с адресами и факт их опроса
             * ********************************** */
            try
            {
                Mask = new BinaryReader(new FileStream("settings.st", FileMode.Open));
                foreach (D250Box Disk in panel1.Controls)
                {
                    Disk.Adres = Mask.ReadInt32();
                    Disk.isWork = Mask.ReadBoolean();
                }
                Mask.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Не возможно открыть настройки", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Изменение очереди устройств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditQueue(object sender, D250Box.DeventArgs e)
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";

            // Изменение для одного устройства
            D250Box.DeventArgs oleg = (D250Box.DeventArgs)e;
            if (oleg.isWork)
                textBox2.AppendText(Info + "Устройство " + oleg.Adres + " включено в опрос." + "\r\n");
            else
                textBox2.AppendText(Info + "Устройство " + oleg.Adres + " отключено от опроса." + "\r\n");
            ReBindQue();

        }

        private void ReBindQue()
        {
            DevCount = -1;
            foreach (D250Box Disk in panel1.Controls)
            {
                if (Disk.isWork)
                {
                    DevCount++;
                    DevMask[DevCount] = Disk.Adres;
                }
            }

            // время задержки опроса зависит от числа устройств
            // в итоге каждое устройство опрашивается 1 раз в 5 секунд
            ReceiveDelay.Interval = ReadRate / (DevCount + 1);
        }

        private void StartCicleRead(object sender, EventArgs e)
        {
            
            ReceiveDelay.Enabled = true;            
            butStartCicleRead.Enabled = false;
            butStopCicleRead.Enabled = true;
        }

        private void StopCicleRead(object sender, EventArgs e)
        {
            oprosstarted = false;
            ReceiveDelay.Enabled = false;
            butStartCicleRead.Enabled = true;
            butStopCicleRead.Enabled = false;
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            SaveMaskToFile();
        }
        

        private void DisconnectFromDB(object sender, EventArgs e)
        {
            if (BaseIsOpen)
            {
                OracleBaseCon.Close();
                BaseIsOpen = false;
                butConnectDB.Enabled = true;
                butWriteToBase.Enabled = false;
            }
        }

        /// <summary>
        /// Сохранение ошибок работы в базу данных
        /// </summary>
        private void SaveErrortoBase()
        {
            string sql = "insert into d250error values(messnumadder.nextval, '";
            sql += testDev.Adres + "', '";
            sql += DateTime.Now.Day + "-";
            string month = "";
            switch (DateTime.Now.Month)
            {
                case 1:
                    month = "jan";
                    break;
                case 2:
                    month = "feb";
                    break;
                case 3:
                    month = "mar";
                    break;
                case 4:
                    month = "apr";
                    break;
                case 5:
                    month = "may";
                    break;
                case 6:
                    month = "jun";
                    break;
                case 7:
                    month = "jul";
                    break;
                case 8:
                    month = "aug";
                    break;
                case 9:
                    month = "sep";
                    break;
                case 10:
                    month = "oct";
                    break;
                case 11:
                    month = "nov";
                    break;
                case 12:
                    month = "dec";
                    break;
            }
            sql += month + "-" + (DateTime.Now.Year - 2000).ToString() + " ";
            int hour = DateTime.Now.Hour;

            if ((hour > 12) & (hour <= 23))
            {
                sql += (hour - 12).ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " PM";
            }
            else if (hour == 12)
            {
                sql += hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " PM";
            }
            else if (hour == 0)
            {
                sql += "12:" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " AM";
            }
            else sql += hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " AM";
            sql += "', '" + testDev.Error.ErrorCode.ToString();
            sql += "', '" + testDev.Error.Message.Replace("'","") + "')";

            if (BaseIsOpen)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(sql, OracleBaseCon);
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                }
                catch (Exception exc)
                {
                    string Info;
                    Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                    textBox2.AppendText(Info + exc.Message + "\r\n");
                }
            }
        }


        #endregion

    }
}
