namespace D250BaseViewer
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btToExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btToTXT = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btConnectDB = new System.Windows.Forms.Button();
            this.btReadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AdresBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stopTime = new System.Windows.Forms.DateTimePicker();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.NeedTimeRange = new System.Windows.Forms.CheckBox();
            this.AllD250 = new System.Windows.Forms.RadioButton();
            this.OneD250 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ExportTXTDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(481, 405);
            this.dataGridView1.TabIndex = 0;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btToExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btToTXT);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btConnectDB);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 166);
            this.panel1.TabIndex = 1;
            // 
            // btToExcel
            // 
            this.btToExcel.Location = new System.Drawing.Point(114, 125);
            this.btToExcel.Name = "btToExcel";
            this.btToExcel.Size = new System.Drawing.Size(102, 36);
            this.btToExcel.TabIndex = 1;
            this.btToExcel.Text = "Excel";
            this.btToExcel.UseVisualStyleBackColor = true;
            this.btToExcel.Click += new System.EventHandler(this.ExportToExcel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Экспорт таблицы";
            // 
            // btToTXT
            // 
            this.btToTXT.Location = new System.Drawing.Point(3, 125);
            this.btToTXT.Name = "btToTXT";
            this.btToTXT.Size = new System.Drawing.Size(102, 36);
            this.btToTXT.TabIndex = 0;
            this.btToTXT.Text = "Текстовый файл";
            this.btToTXT.UseVisualStyleBackColor = true;
            this.btToTXT.Click += new System.EventHandler(this.ExportToTXT);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(210, 52);
            this.textBox1.TabIndex = 2;
            // 
            // btConnectDB
            // 
            this.btConnectDB.Location = new System.Drawing.Point(3, 8);
            this.btConnectDB.Name = "btConnectDB";
            this.btConnectDB.Size = new System.Drawing.Size(102, 36);
            this.btConnectDB.TabIndex = 0;
            this.btConnectDB.Text = "Подключить БД";
            this.btConnectDB.UseVisualStyleBackColor = true;
            this.btConnectDB.Click += new System.EventHandler(this.ConnectDB_Click);
            // 
            // btReadData
            // 
            this.btReadData.Location = new System.Drawing.Point(3, 125);
            this.btReadData.Name = "btReadData";
            this.btReadData.Size = new System.Drawing.Size(102, 36);
            this.btReadData.TabIndex = 1;
            this.btReadData.Text = "Запросить данные";
            this.btReadData.UseVisualStyleBackColor = true;
            this.btReadData.Click += new System.EventHandler(this.ReadData);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(1, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 415);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.AdresBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.stopTime);
            this.panel3.Controls.Add(this.startTime);
            this.panel3.Controls.Add(this.NeedTimeRange);
            this.panel3.Controls.Add(this.AllD250);
            this.panel3.Controls.Add(this.OneD250);
            this.panel3.Controls.Add(this.btReadData);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Location = new System.Drawing.Point(229, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 166);
            this.panel3.TabIndex = 3;
            // 
            // AdresBox
            // 
            this.AdresBox.Location = new System.Drawing.Point(77, 93);
            this.AdresBox.Mask = "###";
            this.AdresBox.Name = "AdresBox";
            this.AdresBox.PromptChar = ' ';
            this.AdresBox.Size = new System.Drawing.Size(33, 20);
            this.AdresBox.TabIndex = 10;
            this.AdresBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Фильтр запроса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "до";
            // 
            // stopTime
            // 
            this.stopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.stopTime.Location = new System.Drawing.Point(174, 54);
            this.stopTime.Name = "stopTime";
            this.stopTime.Size = new System.Drawing.Size(84, 20);
            this.stopTime.TabIndex = 7;
            // 
            // startTime
            // 
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime.Location = new System.Drawing.Point(66, 54);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(84, 20);
            this.startTime.TabIndex = 6;
            // 
            // NeedTimeRange
            // 
            this.NeedTimeRange.AutoSize = true;
            this.NeedTimeRange.Location = new System.Drawing.Point(2, 56);
            this.NeedTimeRange.Name = "NeedTimeRange";
            this.NeedTimeRange.Size = new System.Drawing.Size(68, 17);
            this.NeedTimeRange.TabIndex = 5;
            this.NeedTimeRange.Text = "Время с";
            this.NeedTimeRange.UseVisualStyleBackColor = true;
            // 
            // AllD250
            // 
            this.AllD250.AutoSize = true;
            this.AllD250.Location = new System.Drawing.Point(120, 96);
            this.AllD250.Name = "AllD250";
            this.AllD250.Size = new System.Drawing.Size(90, 17);
            this.AllD250.TabIndex = 4;
            this.AllD250.Text = "все приборы";
            this.AllD250.UseVisualStyleBackColor = true;
            // 
            // OneD250
            // 
            this.OneD250.AutoSize = true;
            this.OneD250.Checked = true;
            this.OneD250.Location = new System.Drawing.Point(2, 94);
            this.OneD250.Name = "OneD250";
            this.OneD250.Size = new System.Drawing.Size(75, 17);
            this.OneD250.TabIndex = 3;
            this.OneD250.TabStop = true;
            this.OneD250.Text = "прибор №";
            this.OneD250.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // ExportTXTDialog
            // 
            this.ExportTXTDialog.DefaultExt = "txt";
            this.ExportTXTDialog.Filter = "Текстовый файл|*.txt";
            this.ExportTXTDialog.Title = "Сохранение в текстовый файл";
            this.ExportTXTDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveToTXT);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 595);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Просмотр базы Д250М";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btReadData;
        private System.Windows.Forms.Button btConnectDB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton AllD250;
        private System.Windows.Forms.RadioButton OneD250;
        private System.Windows.Forms.Button btToExcel;
        private System.Windows.Forms.Button btToTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker stopTime;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.CheckBox NeedTimeRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox AdresBox;
        private System.Windows.Forms.SaveFileDialog ExportTXTDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}

