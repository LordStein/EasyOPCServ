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

namespace OPCServer
{
    /// <summary>
    /// основной класс программы
    /// </summary>
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        const string userID = "ST";
        const string password = "12345";
        const string dataSource = "XE";

        /*const string ConnectionString = "User Id=" + userID +
                     ";Password=" + password +
                     ";Data Source=" + dataSource + ";"; */
        /*const string ConnectionString = "Data Source=" + dataSource + ";" + "User Id=" + userID +
                     ";Password=" + password + ";"; */

        const string ConnectionString = "Data Source=(Description = (Address_list = (Address= (Protocol = TCP)(Host = microsof-eed687)(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));User ID=ST;Password=1234";

        D250M testDev;

        OracleConnection OracleBaseCon;
        bool BaseIsOpen = false;

        /// <summary>
        /// Инициализация формы приложения
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// На каждое считывание создается отдельный поток
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
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
            Thread t = new Thread(new ThreadStart(this.RefreshInfo));
            t.Start();
        }

        /// <summary>
        /// Отдельный поток считыания информации
        /// </summary>
        private void RefreshInfo()
        {
            string Info;

            int _month = testDev.MonthofProdaction;
            if (testDev.iserror) ShowError();

            int _year = testDev.YearofProduction;
            if (testDev.iserror) ShowError();

            int _serial = testDev.SerialNumber;
            if (testDev.iserror) ShowError();

            D250M.ArchRecord _testrecord = new D250M.ArchRecord();
            if (!testDev.GetLastArchRecord(ref _testrecord)) ShowError();

            Info = "Прибор произведен: " + _month + ".";
            if (_year < 10) Info += "200" + _year;
            else Info += "20" + _year;
            Info += ", серийный номер: " + _serial + "\r\n";
            Info += "Последняя архивная запись: " + _testrecord.Hour + ":" + _testrecord.Minute;
            Info += " измерено: " + _testrecord.Data;
            addtext(Info);
        }

        /// <summary>
        /// Вывести ошибку в лог
        /// </summary>
        private void ShowError()
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
            adderrortext(Info + testDev.errorcode + "\r\n");
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
                this.textBox2.AppendText(text);
            }
        }

        /// <summary>
        /// Загрузка формы, начальная инициализация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //CPORT.Open();
            testDev = new D250M(CPORT, 1);
            if (testDev.iserror)
            {
                string Info;
                Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                this.textBox2.AppendText(Info + testDev.errorcode + "\r\n");
                button1.Enabled = false;
            }
            OracleBaseCon = new OracleConnection();
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
                button2.Enabled = false;
                string sql = "select loc from dept" + " where deptno = 10";
                OracleCommand cmd = new OracleCommand(sql, OracleBaseCon);
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.AppendText(dr.GetString(0));

            }
            catch (Exception exc)
            {
                button2.Enabled = true;
                BaseIsOpen = false;
                string Info;
                Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
                textBox2.AppendText(Info + exc.Message + "\r\n");
            }
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

        private void connclick(object sender, EventArgs e)
        {
            ConnectToOrclBase();
        }

    }
}
