namespace OPCServer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CPORT = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butReadOnce = new System.Windows.Forms.Button();
            this.ReceiveDelay = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.butConnectDB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butStartCicleRead = new System.Windows.Forms.Button();
            this.butStopCicleRead = new System.Windows.Forms.Button();
            this.butSaveSettings = new System.Windows.Forms.Button();
            this.butDisconnectDB = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btPreviewDB = new System.Windows.Forms.Button();
            this.btToExcell = new System.Windows.Forms.Button();
            this.d250Box16 = new OPCServer.D250Box();
            this.d250Box15 = new OPCServer.D250Box();
            this.d250Box14 = new OPCServer.D250Box();
            this.d250Box13 = new OPCServer.D250Box();
            this.d250Box12 = new OPCServer.D250Box();
            this.d250Box11 = new OPCServer.D250Box();
            this.d250Box10 = new OPCServer.D250Box();
            this.d250Box9 = new OPCServer.D250Box();
            this.d250Box8 = new OPCServer.D250Box();
            this.d250Box7 = new OPCServer.D250Box();
            this.d250Box6 = new OPCServer.D250Box();
            this.d250Box5 = new OPCServer.D250Box();
            this.d250Box4 = new OPCServer.D250Box();
            this.d250Box3 = new OPCServer.D250Box();
            this.d250Box2 = new OPCServer.D250Box();
            this.d250Box1 = new OPCServer.D250Box();
            this.btConnetToBD2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CPORT
            // 
            this.CPORT.PortName = "COM2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(484, 46);
            this.textBox1.TabIndex = 0;
            // 
            // butReadOnce
            // 
            this.butReadOnce.Location = new System.Drawing.Point(6, 74);
            this.butReadOnce.Name = "butReadOnce";
            this.butReadOnce.Size = new System.Drawing.Size(73, 23);
            this.butReadOnce.TabIndex = 1;
            this.butReadOnce.Text = "Прочитать";
            this.butReadOnce.UseVisualStyleBackColor = true;
            this.butReadOnce.Click += new System.EventHandler(this.ReadDataOnce);
            // 
            // ReceiveDelay
            // 
            this.ReceiveDelay.Interval = 5000;
            this.ReceiveDelay.Tick += new System.EventHandler(this.ReadInCycle);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 142);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(484, 260);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.SizeControl);
            // 
            // butConnectDB
            // 
            this.butConnectDB.BackColor = System.Drawing.Color.Gainsboro;
            this.butConnectDB.Location = new System.Drawing.Point(91, 74);
            this.butConnectDB.Name = "butConnectDB";
            this.butConnectDB.Size = new System.Drawing.Size(96, 23);
            this.butConnectDB.TabIndex = 3;
            this.butConnectDB.Text = "Подключить БД";
            this.butConnectDB.UseVisualStyleBackColor = false;
            this.butConnectDB.Click += new System.EventHandler(this.ConnecttoBaseClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.d250Box16);
            this.panel1.Controls.Add(this.d250Box15);
            this.panel1.Controls.Add(this.d250Box14);
            this.panel1.Controls.Add(this.d250Box13);
            this.panel1.Controls.Add(this.d250Box12);
            this.panel1.Controls.Add(this.d250Box11);
            this.panel1.Controls.Add(this.d250Box10);
            this.panel1.Controls.Add(this.d250Box9);
            this.panel1.Controls.Add(this.d250Box8);
            this.panel1.Controls.Add(this.d250Box7);
            this.panel1.Controls.Add(this.d250Box6);
            this.panel1.Controls.Add(this.d250Box5);
            this.panel1.Controls.Add(this.d250Box4);
            this.panel1.Controls.Add(this.d250Box3);
            this.panel1.Controls.Add(this.d250Box2);
            this.panel1.Controls.Add(this.d250Box1);
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 282);
            this.panel1.TabIndex = 5;
            // 
            // butStartCicleRead
            // 
            this.butStartCicleRead.BackColor = System.Drawing.Color.Gainsboro;
            this.butStartCicleRead.Location = new System.Drawing.Point(288, 74);
            this.butStartCicleRead.Name = "butStartCicleRead";
            this.butStartCicleRead.Size = new System.Drawing.Size(98, 23);
            this.butStartCicleRead.TabIndex = 6;
            this.butStartCicleRead.Text = "Старт опрос";
            this.butStartCicleRead.UseVisualStyleBackColor = false;
            this.butStartCicleRead.Click += new System.EventHandler(this.StartCicleRead);
            // 
            // butStopCicleRead
            // 
            this.butStopCicleRead.Location = new System.Drawing.Point(392, 74);
            this.butStopCicleRead.Name = "butStopCicleRead";
            this.butStopCicleRead.Size = new System.Drawing.Size(98, 23);
            this.butStopCicleRead.TabIndex = 7;
            this.butStopCicleRead.Text = "Стоп опрос";
            this.butStopCicleRead.UseVisualStyleBackColor = true;
            this.butStopCicleRead.Click += new System.EventHandler(this.StopCicleRead);
            // 
            // butSaveSettings
            // 
            this.butSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveSettings.Location = new System.Drawing.Point(6, 355);
            this.butSaveSettings.Name = "butSaveSettings";
            this.butSaveSettings.Size = new System.Drawing.Size(104, 37);
            this.butSaveSettings.TabIndex = 8;
            this.butSaveSettings.Text = "Сохранить";
            this.butSaveSettings.UseVisualStyleBackColor = true;
            this.butSaveSettings.Click += new System.EventHandler(this.SaveSettings);
            // 
            // butDisconnectDB
            // 
            this.butDisconnectDB.Enabled = false;
            this.butDisconnectDB.Location = new System.Drawing.Point(193, 74);
            this.butDisconnectDB.Name = "butDisconnectDB";
            this.butDisconnectDB.Size = new System.Drawing.Size(89, 23);
            this.butDisconnectDB.TabIndex = 10;
            this.butDisconnectDB.Text = "Отключить БД";
            this.butDisconnectDB.UseVisualStyleBackColor = true;
            this.butDisconnectDB.Click += new System.EventHandler(this.DisconnectFromDB);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 439);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.butStartCicleRead);
            this.tabPage1.Controls.Add(this.butStopCicleRead);
            this.tabPage1.Controls.Add(this.butConnectDB);
            this.tabPage1.Controls.Add(this.butDisconnectDB);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.butReadOnce);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Управление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.butSaveSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(254, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 282);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "Задать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SetConnParam);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(4, 203);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(213, 41);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "Для подключения используется строка XE из файла tnsnames.ora.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(251, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Настройка подключения к БД";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(4, 132);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(213, 20);
            this.textBox5.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Пароль пользователя БД:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(4, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(213, 20);
            this.textBox4.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Логин пользователя БД:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(4, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(213, 20);
            this.textBox3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Имя компьютера:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btConnetToBD2);
            this.tabPage3.Controls.Add(this.btToExcell);
            this.tabPage3.Controls.Add(this.btPreviewDB);
            this.tabPage3.Controls.Add(this.dateTimePicker1);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(498, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Просмотр БД";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Adres,
            this.Date,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(6, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(479, 348);
            this.dataGridView1.TabIndex = 1;
            // 
            // Num
            // 
            this.Num.HeaderText = "№";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Num.ToolTipText = "Номер сообщения";
            this.Num.Width = 64;
            // 
            // Adres
            // 
            this.Adres.HeaderText = "Адрес";
            this.Adres.Name = "Adres";
            this.Adres.ReadOnly = true;
            this.Adres.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Adres.Width = 64;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Показание";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.Width = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Список опрашиваемых приборов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Лог событий:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btPreviewDB
            // 
            this.btPreviewDB.Enabled = false;
            this.btPreviewDB.Location = new System.Drawing.Point(305, 11);
            this.btPreviewDB.Name = "btPreviewDB";
            this.btPreviewDB.Size = new System.Drawing.Size(86, 37);
            this.btPreviewDB.TabIndex = 3;
            this.btPreviewDB.Text = "Показать в таблице";
            this.btPreviewDB.UseVisualStyleBackColor = true;
            this.btPreviewDB.Click += new System.EventHandler(this.ShowDBInTable);
            // 
            // btToExcell
            // 
            this.btToExcell.Enabled = false;
            this.btToExcell.Location = new System.Drawing.Point(398, 11);
            this.btToExcell.Name = "btToExcell";
            this.btToExcell.Size = new System.Drawing.Size(86, 37);
            this.btToExcell.TabIndex = 4;
            this.btToExcell.Text = "Экспорт в Excell";
            this.btToExcell.UseVisualStyleBackColor = true;
            this.btToExcell.Click += new System.EventHandler(this.ExportToExcell);
            // 
            // d250Box16
            // 
            this.d250Box16.Adres = 1;
            this.d250Box16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box16.isError = false;
            this.d250Box16.isWork = false;
            this.d250Box16.Location = new System.Drawing.Point(120, 244);
            this.d250Box16.Name = "d250Box16";
            this.d250Box16.Size = new System.Drawing.Size(99, 27);
            this.d250Box16.TabIndex = 15;
            this.d250Box16.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box15
            // 
            this.d250Box15.Adres = 1;
            this.d250Box15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box15.isError = false;
            this.d250Box15.isWork = false;
            this.d250Box15.Location = new System.Drawing.Point(6, 244);
            this.d250Box15.Name = "d250Box15";
            this.d250Box15.Size = new System.Drawing.Size(99, 27);
            this.d250Box15.TabIndex = 14;
            this.d250Box15.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box14
            // 
            this.d250Box14.Adres = 1;
            this.d250Box14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box14.isError = false;
            this.d250Box14.isWork = false;
            this.d250Box14.Location = new System.Drawing.Point(120, 211);
            this.d250Box14.Name = "d250Box14";
            this.d250Box14.Size = new System.Drawing.Size(99, 27);
            this.d250Box14.TabIndex = 13;
            this.d250Box14.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box13
            // 
            this.d250Box13.Adres = 1;
            this.d250Box13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box13.isError = false;
            this.d250Box13.isWork = false;
            this.d250Box13.Location = new System.Drawing.Point(6, 211);
            this.d250Box13.Name = "d250Box13";
            this.d250Box13.Size = new System.Drawing.Size(99, 27);
            this.d250Box13.TabIndex = 12;
            this.d250Box13.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box12
            // 
            this.d250Box12.Adres = 1;
            this.d250Box12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box12.isError = false;
            this.d250Box12.isWork = false;
            this.d250Box12.Location = new System.Drawing.Point(120, 178);
            this.d250Box12.Name = "d250Box12";
            this.d250Box12.Size = new System.Drawing.Size(99, 27);
            this.d250Box12.TabIndex = 11;
            this.d250Box12.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box11
            // 
            this.d250Box11.Adres = 1;
            this.d250Box11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box11.isError = false;
            this.d250Box11.isWork = false;
            this.d250Box11.Location = new System.Drawing.Point(6, 178);
            this.d250Box11.Name = "d250Box11";
            this.d250Box11.Size = new System.Drawing.Size(99, 27);
            this.d250Box11.TabIndex = 10;
            this.d250Box11.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box10
            // 
            this.d250Box10.Adres = 1;
            this.d250Box10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box10.isError = false;
            this.d250Box10.isWork = false;
            this.d250Box10.Location = new System.Drawing.Point(120, 145);
            this.d250Box10.Name = "d250Box10";
            this.d250Box10.Size = new System.Drawing.Size(99, 27);
            this.d250Box10.TabIndex = 9;
            this.d250Box10.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box9
            // 
            this.d250Box9.Adres = 1;
            this.d250Box9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box9.isError = false;
            this.d250Box9.isWork = false;
            this.d250Box9.Location = new System.Drawing.Point(6, 145);
            this.d250Box9.Name = "d250Box9";
            this.d250Box9.Size = new System.Drawing.Size(99, 27);
            this.d250Box9.TabIndex = 8;
            this.d250Box9.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box8
            // 
            this.d250Box8.Adres = 1;
            this.d250Box8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box8.isError = false;
            this.d250Box8.isWork = false;
            this.d250Box8.Location = new System.Drawing.Point(120, 112);
            this.d250Box8.Name = "d250Box8";
            this.d250Box8.Size = new System.Drawing.Size(99, 27);
            this.d250Box8.TabIndex = 7;
            this.d250Box8.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box7
            // 
            this.d250Box7.Adres = 1;
            this.d250Box7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box7.isError = false;
            this.d250Box7.isWork = false;
            this.d250Box7.Location = new System.Drawing.Point(6, 112);
            this.d250Box7.Name = "d250Box7";
            this.d250Box7.Size = new System.Drawing.Size(99, 27);
            this.d250Box7.TabIndex = 6;
            this.d250Box7.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box6
            // 
            this.d250Box6.Adres = 1;
            this.d250Box6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box6.isError = false;
            this.d250Box6.isWork = false;
            this.d250Box6.Location = new System.Drawing.Point(120, 79);
            this.d250Box6.Name = "d250Box6";
            this.d250Box6.Size = new System.Drawing.Size(99, 27);
            this.d250Box6.TabIndex = 5;
            this.d250Box6.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box5
            // 
            this.d250Box5.Adres = 1;
            this.d250Box5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box5.isError = false;
            this.d250Box5.isWork = false;
            this.d250Box5.Location = new System.Drawing.Point(6, 79);
            this.d250Box5.Name = "d250Box5";
            this.d250Box5.Size = new System.Drawing.Size(99, 27);
            this.d250Box5.TabIndex = 4;
            this.d250Box5.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box4
            // 
            this.d250Box4.Adres = 1;
            this.d250Box4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box4.isError = false;
            this.d250Box4.isWork = false;
            this.d250Box4.Location = new System.Drawing.Point(120, 47);
            this.d250Box4.Name = "d250Box4";
            this.d250Box4.Size = new System.Drawing.Size(99, 27);
            this.d250Box4.TabIndex = 3;
            this.d250Box4.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box3
            // 
            this.d250Box3.Adres = 1;
            this.d250Box3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box3.isError = false;
            this.d250Box3.isWork = false;
            this.d250Box3.Location = new System.Drawing.Point(6, 47);
            this.d250Box3.Name = "d250Box3";
            this.d250Box3.Size = new System.Drawing.Size(99, 27);
            this.d250Box3.TabIndex = 2;
            this.d250Box3.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box2
            // 
            this.d250Box2.Adres = 1;
            this.d250Box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box2.isError = false;
            this.d250Box2.isWork = false;
            this.d250Box2.Location = new System.Drawing.Point(120, 14);
            this.d250Box2.Name = "d250Box2";
            this.d250Box2.Size = new System.Drawing.Size(99, 27);
            this.d250Box2.TabIndex = 1;
            this.d250Box2.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // d250Box1
            // 
            this.d250Box1.Adres = 1;
            this.d250Box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box1.isError = false;
            this.d250Box1.isWork = false;
            this.d250Box1.Location = new System.Drawing.Point(6, 14);
            this.d250Box1.Name = "d250Box1";
            this.d250Box1.Size = new System.Drawing.Size(99, 27);
            this.d250Box1.TabIndex = 0;
            this.d250Box1.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // btConnetToBD2
            // 
            this.btConnetToBD2.BackColor = System.Drawing.Color.Gainsboro;
            this.btConnetToBD2.Location = new System.Drawing.Point(212, 11);
            this.btConnetToBD2.Name = "btConnetToBD2";
            this.btConnetToBD2.Size = new System.Drawing.Size(86, 37);
            this.btConnetToBD2.TabIndex = 5;
            this.btConnetToBD2.Text = "Подключить БД";
            this.btConnetToBD2.UseVisualStyleBackColor = false;
            this.btConnetToBD2.Click += new System.EventHandler(this.ConnecttoBaseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 442);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 480);
            this.MinimumSize = new System.Drawing.Size(242, 352);
            this.Name = "Form1";
            this.Text = "Сервер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort CPORT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butReadOnce;
        private System.Windows.Forms.Timer ReceiveDelay;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button butConnectDB;
        private System.Windows.Forms.Panel panel1;
        private D250Box d250Box16;
        private D250Box d250Box15;
        private D250Box d250Box14;
        private D250Box d250Box13;
        private D250Box d250Box12;
        private D250Box d250Box11;
        private D250Box d250Box10;
        private D250Box d250Box9;
        private D250Box d250Box8;
        private D250Box d250Box7;
        private D250Box d250Box6;
        private D250Box d250Box5;
        private D250Box d250Box4;
        private D250Box d250Box3;
        private D250Box d250Box2;
        private D250Box d250Box1;
        private System.Windows.Forms.Button butStartCicleRead;
        private System.Windows.Forms.Button butStopCicleRead;
        private System.Windows.Forms.Button butSaveSettings;
        private System.Windows.Forms.Button butDisconnectDB;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btToExcell;
        private System.Windows.Forms.Button btPreviewDB;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btConnetToBD2;
    }
}

