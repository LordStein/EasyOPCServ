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
            this.butWriteToBase = new System.Windows.Forms.Button();
            this.butDisconnectDB = new System.Windows.Forms.Button();
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CPORT
            // 
            this.CPORT.PortName = "COM2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(372, 46);
            this.textBox1.TabIndex = 0;
            // 
            // butReadOnce
            // 
            this.butReadOnce.Location = new System.Drawing.Point(12, 74);
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
            this.textBox2.Location = new System.Drawing.Point(12, 113);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(372, 113);
            this.textBox2.TabIndex = 2;
            // 
            // butConnectDB
            // 
            this.butConnectDB.Location = new System.Drawing.Point(91, 74);
            this.butConnectDB.Name = "butConnectDB";
            this.butConnectDB.Size = new System.Drawing.Size(96, 23);
            this.butConnectDB.TabIndex = 3;
            this.butConnectDB.Text = "Подключить БД";
            this.butConnectDB.UseVisualStyleBackColor = true;
            this.butConnectDB.Click += new System.EventHandler(this.ConnecttoBaseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.panel1.Location = new System.Drawing.Point(404, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 271);
            this.panel1.TabIndex = 5;
            // 
            // butStartCicleRead
            // 
            this.butStartCicleRead.Location = new System.Drawing.Point(12, 245);
            this.butStartCicleRead.Name = "butStartCicleRead";
            this.butStartCicleRead.Size = new System.Drawing.Size(98, 23);
            this.butStartCicleRead.TabIndex = 6;
            this.butStartCicleRead.Text = "Старт опрос";
            this.butStartCicleRead.UseVisualStyleBackColor = true;
            this.butStartCicleRead.Click += new System.EventHandler(this.StartCicleRead);
            // 
            // butStopCicleRead
            // 
            this.butStopCicleRead.Location = new System.Drawing.Point(116, 245);
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
            this.butSaveSettings.Location = new System.Drawing.Point(404, 283);
            this.butSaveSettings.Name = "butSaveSettings";
            this.butSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.butSaveSettings.TabIndex = 8;
            this.butSaveSettings.Text = "Сохранить";
            this.butSaveSettings.UseVisualStyleBackColor = true;
            this.butSaveSettings.Click += new System.EventHandler(this.SaveSettings);
            // 
            // butWriteToBase
            // 
            this.butWriteToBase.Enabled = false;
            this.butWriteToBase.Location = new System.Drawing.Point(193, 74);
            this.butWriteToBase.Name = "butWriteToBase";
            this.butWriteToBase.Size = new System.Drawing.Size(96, 23);
            this.butWriteToBase.TabIndex = 9;
            this.butWriteToBase.Text = "Записать в БД";
            this.butWriteToBase.UseVisualStyleBackColor = true;
            this.butWriteToBase.Click += new System.EventHandler(this.ManualSaveToBase);
            // 
            // butDisconnectDB
            // 
            this.butDisconnectDB.Enabled = false;
            this.butDisconnectDB.Location = new System.Drawing.Point(295, 74);
            this.butDisconnectDB.Name = "butDisconnectDB";
            this.butDisconnectDB.Size = new System.Drawing.Size(89, 23);
            this.butDisconnectDB.TabIndex = 10;
            this.butDisconnectDB.Text = "Отключить БД";
            this.butDisconnectDB.UseVisualStyleBackColor = true;
            this.butDisconnectDB.Click += new System.EventHandler(this.DisconnectFromDB);
            // 
            // d250Box16
            // 
            this.d250Box16.Adres = 1;
            this.d250Box16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box16.isError = false;
            this.d250Box16.isWork = false;
            this.d250Box16.Location = new System.Drawing.Point(108, 234);
            this.d250Box16.Name = "d250Box16";
            this.d250Box16.Size = new System.Drawing.Size(99, 27);
            this.d250Box16.TabIndex = 15;
            // 
            // d250Box15
            // 
            this.d250Box15.Adres = 1;
            this.d250Box15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box15.isError = false;
            this.d250Box15.isWork = false;
            this.d250Box15.Location = new System.Drawing.Point(3, 234);
            this.d250Box15.Name = "d250Box15";
            this.d250Box15.Size = new System.Drawing.Size(99, 27);
            this.d250Box15.TabIndex = 14;
            // 
            // d250Box14
            // 
            this.d250Box14.Adres = 1;
            this.d250Box14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box14.isError = false;
            this.d250Box14.isWork = false;
            this.d250Box14.Location = new System.Drawing.Point(108, 201);
            this.d250Box14.Name = "d250Box14";
            this.d250Box14.Size = new System.Drawing.Size(99, 27);
            this.d250Box14.TabIndex = 13;
            // 
            // d250Box13
            // 
            this.d250Box13.Adres = 1;
            this.d250Box13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box13.isError = false;
            this.d250Box13.isWork = false;
            this.d250Box13.Location = new System.Drawing.Point(3, 201);
            this.d250Box13.Name = "d250Box13";
            this.d250Box13.Size = new System.Drawing.Size(99, 27);
            this.d250Box13.TabIndex = 12;
            // 
            // d250Box12
            // 
            this.d250Box12.Adres = 1;
            this.d250Box12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box12.isError = false;
            this.d250Box12.isWork = false;
            this.d250Box12.Location = new System.Drawing.Point(108, 168);
            this.d250Box12.Name = "d250Box12";
            this.d250Box12.Size = new System.Drawing.Size(99, 27);
            this.d250Box12.TabIndex = 11;
            // 
            // d250Box11
            // 
            this.d250Box11.Adres = 1;
            this.d250Box11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box11.isError = false;
            this.d250Box11.isWork = false;
            this.d250Box11.Location = new System.Drawing.Point(3, 168);
            this.d250Box11.Name = "d250Box11";
            this.d250Box11.Size = new System.Drawing.Size(99, 27);
            this.d250Box11.TabIndex = 10;
            // 
            // d250Box10
            // 
            this.d250Box10.Adres = 1;
            this.d250Box10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box10.isError = false;
            this.d250Box10.isWork = false;
            this.d250Box10.Location = new System.Drawing.Point(108, 135);
            this.d250Box10.Name = "d250Box10";
            this.d250Box10.Size = new System.Drawing.Size(99, 27);
            this.d250Box10.TabIndex = 9;
            // 
            // d250Box9
            // 
            this.d250Box9.Adres = 1;
            this.d250Box9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box9.isError = false;
            this.d250Box9.isWork = false;
            this.d250Box9.Location = new System.Drawing.Point(3, 135);
            this.d250Box9.Name = "d250Box9";
            this.d250Box9.Size = new System.Drawing.Size(99, 27);
            this.d250Box9.TabIndex = 8;
            // 
            // d250Box8
            // 
            this.d250Box8.Adres = 1;
            this.d250Box8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box8.isError = false;
            this.d250Box8.isWork = false;
            this.d250Box8.Location = new System.Drawing.Point(108, 102);
            this.d250Box8.Name = "d250Box8";
            this.d250Box8.Size = new System.Drawing.Size(99, 27);
            this.d250Box8.TabIndex = 7;
            // 
            // d250Box7
            // 
            this.d250Box7.Adres = 1;
            this.d250Box7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box7.isError = false;
            this.d250Box7.isWork = false;
            this.d250Box7.Location = new System.Drawing.Point(3, 102);
            this.d250Box7.Name = "d250Box7";
            this.d250Box7.Size = new System.Drawing.Size(99, 27);
            this.d250Box7.TabIndex = 6;
            // 
            // d250Box6
            // 
            this.d250Box6.Adres = 1;
            this.d250Box6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box6.isError = false;
            this.d250Box6.isWork = false;
            this.d250Box6.Location = new System.Drawing.Point(108, 69);
            this.d250Box6.Name = "d250Box6";
            this.d250Box6.Size = new System.Drawing.Size(99, 27);
            this.d250Box6.TabIndex = 5;
            // 
            // d250Box5
            // 
            this.d250Box5.Adres = 1;
            this.d250Box5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box5.isError = false;
            this.d250Box5.isWork = false;
            this.d250Box5.Location = new System.Drawing.Point(3, 69);
            this.d250Box5.Name = "d250Box5";
            this.d250Box5.Size = new System.Drawing.Size(99, 27);
            this.d250Box5.TabIndex = 4;
            // 
            // d250Box4
            // 
            this.d250Box4.Adres = 1;
            this.d250Box4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box4.isError = false;
            this.d250Box4.isWork = false;
            this.d250Box4.Location = new System.Drawing.Point(108, 37);
            this.d250Box4.Name = "d250Box4";
            this.d250Box4.Size = new System.Drawing.Size(99, 27);
            this.d250Box4.TabIndex = 3;
            // 
            // d250Box3
            // 
            this.d250Box3.Adres = 1;
            this.d250Box3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box3.isError = false;
            this.d250Box3.isWork = false;
            this.d250Box3.Location = new System.Drawing.Point(3, 37);
            this.d250Box3.Name = "d250Box3";
            this.d250Box3.Size = new System.Drawing.Size(99, 27);
            this.d250Box3.TabIndex = 2;
            // 
            // d250Box2
            // 
            this.d250Box2.Adres = 1;
            this.d250Box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box2.isError = false;
            this.d250Box2.isWork = false;
            this.d250Box2.Location = new System.Drawing.Point(108, 4);
            this.d250Box2.Name = "d250Box2";
            this.d250Box2.Size = new System.Drawing.Size(99, 27);
            this.d250Box2.TabIndex = 1;
            // 
            // d250Box1
            // 
            this.d250Box1.Adres = 1;
            this.d250Box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d250Box1.isError = false;
            this.d250Box1.isWork = false;
            this.d250Box1.Location = new System.Drawing.Point(3, 4);
            this.d250Box1.Name = "d250Box1";
            this.d250Box1.Size = new System.Drawing.Size(99, 27);
            this.d250Box1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 314);
            this.Controls.Add(this.butSaveSettings);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butConnectDB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.butReadOnce);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butDisconnectDB);
            this.Controls.Add(this.butWriteToBase);
            this.Controls.Add(this.butStopCicleRead);
            this.Controls.Add(this.butStartCicleRead);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 352);
            this.MinimumSize = new System.Drawing.Size(242, 352);
            this.Name = "Form1";
            this.Text = "Сервер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button butWriteToBase;
        private System.Windows.Forms.Button butDisconnectDB;
    }
}

