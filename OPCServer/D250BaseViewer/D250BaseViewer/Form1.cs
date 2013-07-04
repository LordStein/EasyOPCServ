using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace D250BaseViewer
{
    /// <summary>
    /// Класс формы приложения.
    /// </summary>
    public partial class MainForm : Form
    {

        Microsoft.Office.Interop.Excel.Application Excel;

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        const string ConnectionString = "Data Source=(Description = (Address_list = (Address= (Protocol = TCP)(Host = comp)(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));User ID=ST;Password=1234";
        
        /// <summary>
        /// Соединение к БД
        /// </summary>
        OracleConnection Conn;

        /// <summary>
        /// Признак успешного открытия БД
        /// </summary>
        bool BaseIsOpen = false;

        /// <summary>
        /// стандартный инициализатор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btReadData.Enabled = false;
            btToExcel.Enabled = false;
            btToTXT.Enabled = false;
            Conn = new OracleConnection();
            Excel = new Microsoft.Office.Interop.Excel.Application();
        }

        /// <summary>
        /// Попытка соединения к БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectDB_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                BaseIsOpen = true;
                btConnectDB.Enabled = false;
                btReadData.Enabled = true;
                AddToLog("Подключение установлено.");

            }
            catch (Exception exc)
            {
                btConnectDB.Enabled = true;
                BaseIsOpen = false;
                AddToLog(exc.Message);
            }
        }

        /// <summary>
        /// Чтение данных из БД и отображение их в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadData(object sender, EventArgs e)
        {
            if (BaseIsOpen)
            {   try
                {
                    string sql;
                    string[] str = new string[4];
                    sql = SQLQuereBuilder();
                    OracleCommand cmd = new OracleCommand(sql, Conn);
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                            str[i] = dr.GetValue(i).ToString();
                        dataGridView1.Rows.Add(str);
                    }
                    btToExcel.Enabled = true;
                    btToTXT.Enabled = true;
                    AddToLog("Данные получены.");                    
                }
                catch (Exception exc)
                {
                    AddToLog(exc.Message);
                }

            }
        }

        /// <summary>
        /// Добавление информации в лог.
        /// </summary>
        /// <param name="text"></param>
        private void AddToLog(string text)
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
            textBox1.AppendText(Info + text + "\r\n");
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
            if (NeedTimeRange.Checked)
            {
                if (startTime.Value < stopTime.Value)
                {
                    sql += "'" + data + " " + Time(startTime) + "'";
                    sql += " and readtime < ";
                    sql += "'" + data + " "+ Time(stopTime) + "'";
                }
                else
                {
                    MessageBox.Show("Начальное время должно быть меньше.", "Ошибка ввода диапазона времени.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else sql += "'" + data + "'";
            if (OneD250.Checked)
            {
                int adres = Int32.Parse(AdresBox.Text);
                if ((adres > 127) || (adres <= 0))
                    MessageBox.Show("Номер устройства должен находиться в диапазоне 1-127.", "Ошибка ввода номера устройства.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sql += " and adres = '" + adres.ToString() + "'";
                }
            }
            return sql;
        }

        /// <summary>
        /// Возвращает строку времени в формате HH:MM:SS AM(PM)
        /// </summary>
        /// <param name="date">Объект даты</param>
        /// <returns></returns>
        private string Time(DateTimePicker date)
        {
            string temp ="";
            int hour = date.Value.Hour;
            if ((hour > 12) & (hour <= 23))
            {
                temp += (hour - 12).ToString() + ":" + date.Value.Minute + ":" + date.Value.Second + " PM";
            }
            else if (hour == 12)
            {
                temp += hour.ToString() + ":" + date.Value.Minute + ":" + date.Value.Second + " PM";
            }
            else if (hour == 0)
            {
                temp += "12:" + date.Value.Minute + ":" + date.Value.Second + " AM";
            }
            else temp += hour.ToString() + ":" + date.Value.Minute + ":" + date.Value.Second + " AM";
            return temp;
        }

        private void ExportToTXT(object sender, EventArgs e)
        {
            string Info;
            Info = DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt";
            ExportTXTDialog.FileName = Info;
            ExportTXTDialog.ShowDialog();
        }

        private void ExportToExcel(object sender, EventArgs e)
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

        private void SaveToTXT(object sender, CancelEventArgs e)
        {
            string FileName = ExportTXTDialog.FileName;
            FileStream textfile;
            try
            {
                textfile = new FileStream(FileName, FileMode.Create);
            }
            catch (IOException exc)
            {
                AddToLog("Ошибка создания файла " + exc.Message);
                return;
            }
            StreamWriter writer = new StreamWriter(textfile);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                writer.Write(dataGridView1.Rows[i].Cells[0].Value + " ");
                writer.Write(dataGridView1.Rows[i].Cells[1].Value + " ");
                writer.Write(dataGridView1.Rows[i].Cells[2].Value+ " ");
                writer.WriteLine(dataGridView1.Rows[i].Cells[3].Value);
                
            }
            writer.Close();
            textfile.Close();
            
            AddToLog("Файл сохранен.");
        }

        /// <summary>
        /// Закрытие базы при выходе из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Closed(object sender, FormClosedEventArgs e)
        {
            if (BaseIsOpen && Conn != null) Conn.Close();
        }
    }
}
