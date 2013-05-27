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
            this.button1 = new System.Windows.Forms.Button();
            this.ReceiveDelay = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Прочитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReceiveDelay
            // 
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Подключить БД";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.connclick);
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
            this.panel1.Location = new System.Drawing.Point(443, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 271);
            this.panel1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Старт опрос";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(118, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Стоп опрос";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(443, 283);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Сохранить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.d250Box16.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box15.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box14.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box13.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box12.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box11.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box10.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box9.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box8.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box7.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box6.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box5.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box4.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box3.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box2.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
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
            this.d250Box1.D250EnChanged += new OPCServer.D250Box.eHandler(this.EditQueue);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Сервер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProgramClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort CPORT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer ReceiveDelay;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
    }
}

