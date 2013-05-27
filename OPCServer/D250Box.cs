using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPCServer
{
    /// <summary>
    /// Отобажение ведомого устройства.
    /// </summary>
    public partial class D250Box : UserControl
    {
        private bool err = false;
        private int adr;
        private bool onned = false;

        /// <summary>
        /// Список возвращаемых параметров
        /// </summary>
        public class DeventArgs : EventArgs
        {
            private int adr;
            private bool opros;

            /// <summary>
            /// Конструктор класса
            /// </summary>
            /// <param name="adr"></param>
            /// <param name="opros"></param>
            public DeventArgs(int adr, bool opros)
            {
                this.adr = adr;
                this.opros = opros;
            }

            /// <summary>
            /// Адрес
            /// </summary>
            public int Adres
            {
                get
                {
                    return adr;
                }
            }

            /// <summary>
            /// Опрашивается ли
            /// </summary>
            public bool isWork
            {
                get
                {
                    return opros;
                }
            }
        }

        /// <summary>
        /// Делегат исключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void eHandler(object sender, DeventArgs e);

        /// <summary>
        /// Происходит при нажатии на CheckBox компонента.
        /// </summary>
        [Category("Поведение")]
        [Description("Происходит при нажатии на CheckBox компонента.")]
        public event eHandler D250EnChanged;

        /// <summary>
        /// Реакция на изменение состояния CheckBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnEnableChanged(object sender, DeventArgs e)
        {
            if (D250EnChanged != null)
            D250EnChanged(this, e);
        }

        /// <summary>
        /// Отображение и ввод адреса ведомого устройства.
        /// </summary>
        [Category("Поведение")]
        [Description("Адрес ведомого устройства.")]
        public int Adres
        {
            set
            {
                maskedTextBox1.Text = value.ToString();
            }
            get
            {
                bool erk = false;
                try
                {
                    adr = int.Parse(maskedTextBox1.Text);
                }
                catch (Exception)
                {
                    erk = true;
                }
                if ((erk)||(adr > 127)||(adr < 0))
                {
                    maskedTextBox1.Text = "1";
                    return 1;
                }
                else return adr;
            }
        }

        /// <summary>
        /// Показывает включено ли устройство в опрос.
        /// </summary>
        [Category("Поведение")]
        [Description("Показывает включено ли устройство в опрос.")]
        public bool isWork
        {
            get
            {
                return onned;
            }
            set
            {
                onned = value;
                checkBox1.Checked = onned;
            }
        }

        /// <summary>
        /// Отображение статуса ведомого устройства.
        /// </summary>
        [Category("Поведение")]
        [Description("Отображение ошибки.")]
        public bool isError
        {
            get
            {
                return err;
            }
            set
            {
                err = value;
                if (err)
                {

                    label1.ForeColor = Color.Red;
                    label1.Text = "Ошб.";
                }
                else
                {
                    label1.ForeColor = Color.Lime;
                    label1.Text = "Ок.";
                }
            }
        }

        /// <summary>
        /// Конструткор класса по умолчанию
        /// </summary>
        public D250Box()
        {
            adr = 1;
            err = false;
            onned = false;
            InitializeComponent();
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }

        public D250Box(int adres, bool iserror, bool iswork, int x, int y)
        {
            InitializeComponent();
            this.Adres = adres;
            this.isError = iserror;
            this.isWork = iswork;
            this.Left = x;
            this.Top = y;

        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) isWork = true;
            else isWork = false;
            if (D250EnChanged != null)
            D250EnChanged(sender, new DeventArgs(this.Adres, this.isWork));
        }
    }
}
