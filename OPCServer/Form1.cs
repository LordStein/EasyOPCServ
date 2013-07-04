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
using Microsoft.Office.Interop.Excel;

namespace OPCServer
{
    /// <summary>
    /// основной класс программы
    /// </summary>
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        Microsoft.Office.Interop.Excel.Application Excel;

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
        /// Имя пользователя БД
        /// </summary>
        static string user = "ST";

        /// <summary>
        /// Имя компьютера
        /// </summary>
        static string host = "comp";

        /// <summary>
        /// Пароль пользователя БД
        /// </summary>
        static string password = "1234";

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        string ConnectionString;

        /// <summary>
        /// частота опроса в мс, не меньше 100*Dnum
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
            Excel = new Microsoft.Office.Interop.Excel.Application();
            //CPORT.Open();
            ReadMaskFromFile();
            ReBindQue();
            OracleBaseCon = new OracleConnection();
            //ConnectToOrclBase();
            testDev = new D250M(CPORT, 1);
            if (testDev.Error.isError)
            {
                addToLog(testDev.Error.Message);
                butReadOnce.Enabled = false;
                butStartCicleRead.Enabled = false;
                SaveErrortoBase();
            }
            oprosstarted = false;
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
            if (testDev.Error.isError) addToLog(testDev.Error.Message);

            int _year = testDev.YearofProduction;
            if (testDev.Error.isError) addToLog(testDev.Error.Message);

            int _serial = testDev.SerialNumber;
            if (testDev.Error.isError) addToLog(testDev.Error.Message);

            //D250M.ArchRecord _testrecord = new D250M.ArchRecord();
            //if (!testDev.GetLastArchRecord(ref _testrecord)) ShowError();

            float datanow = testDev.DataNow;
            if (testDev.Error.isError) addToLog(testDev.Error.Message);

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
                this.textBox1.Text = text;
                if (oprosstarted) this.ReceiveDelay.Enabled = true;
            }
        }

        /// <summary>
        /// Добавление текста ошибки
        /// </summary>
        /// <param name="text"></param>
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
                        addToLog(testDev.Error.Message);
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
                btConnetToBD2.Enabled = false;
                butDisconnectDB.Enabled = true;
                btPreviewDB.Enabled = true;
            }
            catch (Exception exc)
            {
                butConnectDB.Enabled = true;
                btConnetToBD2.Enabled = true;
                btPreviewDB.Enabled = false;
                BaseIsOpen = false;
                addToLog(exc.Message);
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
                    addToLog(exc.Message);
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

        /// <summary>
        /// Сохранение маски опроса и параметров в файл
        /// </summary>
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
                Mask.Write(user);
                Mask.Write(host);
                Mask.Write(password);
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
                user = Mask.ReadString();
                host = Mask.ReadString();
                password = Mask.ReadString();
                Mask.Close();
                ConnectionString = "Data Source=(Description = (Address_list = (Address= (Protocol = TCP)(Host = " + host +
                                   ")(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));User ID=" + user + ";Password=" + password;
                textBox3.Text = host;
                textBox4.Text = user;
                textBox5.Text = "******";
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Не возможно открыть настройки. Введите настройки повторно.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addToLog("Настройки не загружены.");
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка ввода вывода.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Изменение очереди устройств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditQueue(object sender, D250Box.DeventArgs e)
        {
            // Изменение для одного устройства
            D250Box.DeventArgs oleg = (D250Box.DeventArgs)e;
            if (oleg.isWork)
                addToLog("Устройство " + oleg.Adres + " включено в опрос.");
            else
                addToLog("Устройство " + oleg.Adres + " отключено от опроса.");
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
            if (DevCount != -1) ReceiveDelay.Interval = ReadRate / (DevCount + 1);
            else ReceiveDelay.Interval = ReadRate;
        }

        private void StartCicleRead(object sender, EventArgs e)
        {
            addToLog("Опрос начат.");
            ReceiveDelay.Enabled = true;            
            butStartCicleRead.Enabled = false;
            butStopCicleRead.Enabled = true;
        }

        private void StopCicleRead(object sender, EventArgs e)
        {
            addToLog("Опрос остановлен.");
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
                    addToLog(exc.Message);
                }
            }
        }

        /// <summary>
        /// Установить параметры строки соединения с БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetConnParam(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length > 0) & (textBox4.Text.Length > 0) & (textBox5.Text.Length > 0))
            {
                host = textBox3.Text;
                user = textBox4.Text;
                password = textBox5.Text;
                textBox5.Text = "******";
                ConnectionString = "Data Source=(Description = (Address_list = (Address= (Protocol = TCP)(Host = " + host +
                                   ")(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));User ID=" + user + ";Password=" + password;
            }
            else
            {
                MessageBox.Show("Не все данные введены.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Ограничение на число символов в логе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeControl(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 3300)
                textBox2.Text = "";
        }

        /// <summary>
        /// Вывод сохраненных в БД показаний за выбранный день в таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDBInTable(object sender, EventArgs e)
        {
            if (BaseIsOpen)
            {
                try
                {
                    string sql;
                    string[] str = new string[4];
                    sql = SQLQuereBuilder();
                    OracleCommand cmd = new OracleCommand(sql, OracleBaseCon);
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                            str[i] = dr.GetValue(i).ToString();
                        dataGridView1.Rows.Add(str);
                    }
                    btToExcell.Enabled = true;
                }
                catch (Exception exc)
                {
                    addToLog(exc.Message);
                }

            }
        }

        /// <summary>
        /// Построитель запросов по фильтру
        /// </summary>
        /// <returns></returns>
        private string SQLQuereBuilder()
        {
            // Например запрос вида:
            // select * from d250data where readtime > '24-may-13 12.20.10 AM' 
            // and readtime < '28-may-13 2.20.20 PM' and adres = '1';
            string sql = "SELECT * FROM d250data WHERE readtime > ";
            string data = "";
            data += dateTimePicker1.Value.Day + "-";
            string month = "";
            switch (dateTimePicker1.Value.Month)
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
            data += month + "-" + (dateTimePicker1.Value.Year - 2000).ToString();
            sql += "'" + data + " " + "1.0.0 AM" + "'";
            sql += " and readtime < ";
            sql += "'" + data + " " + "12.59.59 PM" + "'";
            sql += " order by readtime";
            return sql;
        }

        /// <summary>
        /// Добавление в лог строки
        /// </summary>
        /// <param name="str">Добавляемая строка.</param>
        private void addToLog(string str)
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
            textBox2.AppendText(Info + str + "\r\n");
        }

        /// <summary>
        /// Экспорт данных из таблицы в Excell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToExcell(object sender, EventArgs e)
        {
            Excel.Application.Workbooks.Add(Type.Missing);
            Excel.Columns.ColumnWidth = 16;
            Excel.Cells[1, 1] = "№";
            Excel.Cells[1, 2] = "Адрес";
            Excel.Cells[1, 3] = "Дата";
            Excel.Cells[1, 4] = "Показание";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Excel.Cells[i + 2, 1] = dataGridView1.Rows[i].Cells[0].Value;
                Excel.Cells[i + 2, 2] = dataGridView1.Rows[i].Cells[1].Value;
                Excel.Cells[i + 2, 3] = dataGridView1.Rows[i].Cells[2].Value;
                Excel.Cells[i + 2, 4] = dataGridView1.Rows[i].Cells[3].Value;
            }
            Excel.Visible = true;
        }

        #endregion









    }
}
