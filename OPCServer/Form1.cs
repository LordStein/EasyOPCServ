using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPCServer
{
    /// <summary>
    /// основной класс программы
    /// </summary>
    public partial class Form1 : Form
    {

        D250M testDev;

        /// <summary>
        /// Инициализация формы приложения
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModBusASCII test = new ModBusASCII(CPORT);
            byte[] oleg = new byte[] {0x3A, 0x1, 0x4, 0x4, 0x0, 0x0, 0x48, 0xC1 ,0xD, 0xA };
            //byte[] oleg = new byte[] { 58, 48, 49, 48, 51, 48, 49, 51, 49, 48, 48, 48, 49, 49, 78, 13, 10};
            //58 48 49 48 51 48 49 51 49 48 48 48 49 49 78 13 10 строка
            /*byte[] itog = test.ChrtoBin(oleg);
            foreach (byte sim in itog)
            {
                textBox1.AppendText(sim + " ");
            }*/
            textBox1.Text = test.BintoFloat(oleg, 4).ToString();
            textBox1.Text = testDev.testregister.ToString();
        }

        /// <summary>
        /// Загрузка формы, начальная инициализация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CPORT.Open();
            testDev = new D250M(CPORT, 1);
        }

        /// <summary>
        /// Закрытие программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramClosed(object sender, FormClosedEventArgs e)
        {
            if (CPORT != null) CPORT.Close();
        }

    }
}
