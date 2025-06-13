namespace AdminLodash
{
    partial class Attendancemanagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.absentRadioButton = new System.Windows.Forms.RadioButton();
            this.acceptButton = new AdminLodash.BorderButton();
            this.studentComboBox = new System.Windows.Forms.ComboBox();
            this.presentRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLopHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.dtpNgayDiemDanh = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.absentRadioButton);
            this.panel1.Controls.Add(this.acceptButton);
            this.panel1.Controls.Add(this.studentComboBox);
            this.panel1.Controls.Add(this.presentRadioButton);
            this.panel1.Controls.Add(this.dtpNgayDiemDanh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbLopHoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 145);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(648, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 109);
            this.panel2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Student Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Status";
            // 
            // absentRadioButton
            // 
            this.absentRadioButton.AutoSize = true;
            this.absentRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.absentRadioButton.Location = new System.Drawing.Point(214, 105);
            this.absentRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.absentRadioButton.Name = "absentRadioButton";
            this.absentRadioButton.Size = new System.Drawing.Size(76, 22);
            this.absentRadioButton.TabIndex = 9;
            this.absentRadioButton.TabStop = true;
            this.absentRadioButton.Text = "absent";
            this.absentRadioButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.White;
            this.acceptButton.BackgroundColor = System.Drawing.Color.White;
            this.acceptButton.BoderRadius1 = 31;
            this.acceptButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.acceptButton.BorderSize = 0;
            this.acceptButton.FlatAppearance.BorderSize = 0;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.ForeColor = System.Drawing.Color.Blue;
            this.acceptButton.Location = new System.Drawing.Point(295, 18);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(123, 31);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "accept";
            this.acceptButton.TextColor = System.Drawing.Color.Blue;
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.borderButton1_Click);
            // 
            // studentComboBox
            // 
            this.studentComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentComboBox.FormattingEnabled = true;
            this.studentComboBox.Location = new System.Drawing.Point(436, 49);
            this.studentComboBox.Name = "studentComboBox";
            this.studentComboBox.Size = new System.Drawing.Size(181, 26);
            this.studentComboBox.TabIndex = 7;
            this.studentComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // presentRadioButton
            // 
            this.presentRadioButton.AutoSize = true;
            this.presentRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentRadioButton.Location = new System.Drawing.Point(120, 105);
            this.presentRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.presentRadioButton.Name = "presentRadioButton";
            this.presentRadioButton.Size = new System.Drawing.Size(82, 22);
            this.presentRadioButton.TabIndex = 4;
            this.presentRadioButton.TabStop = true;
            this.presentRadioButton.Text = "present";
            this.presentRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // cmbLopHoc
            // 
            this.cmbLopHoc.FormattingEnabled = true;
            this.cmbLopHoc.Location = new System.Drawing.Point(139, 21);
            this.cmbLopHoc.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLopHoc.Name = "cmbLopHoc";
            this.cmbLopHoc.Size = new System.Drawing.Size(151, 21);
            this.cmbLopHoc.TabIndex = 1;
            this.cmbLopHoc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvDiemDanh
            // 
            this.dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemDanh.Location = new System.Drawing.Point(19, 170);
            this.dgvDiemDanh.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDiemDanh.Name = "dgvDiemDanh";
            this.dgvDiemDanh.RowHeadersWidth = 51;
            this.dgvDiemDanh.RowTemplate.Height = 24;
            this.dgvDiemDanh.Size = new System.Drawing.Size(1303, 315);
            this.dgvDiemDanh.TabIndex = 7;
            this.dgvDiemDanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dtpNgayDiemDanh
            // 
            this.dtpNgayDiemDanh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDiemDanh.Location = new System.Drawing.Point(139, 50);
            this.dtpNgayDiemDanh.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayDiemDanh.Name = "dtpNgayDiemDanh";
            this.dtpNgayDiemDanh.Size = new System.Drawing.Size(151, 20);
            this.dtpNgayDiemDanh.TabIndex = 3;
            // 
            // Attendancemanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 506);
            this.Controls.Add(this.dgvDiemDanh);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Attendancemanagement";
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbLopHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton presentRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDiemDanh;
        private System.Windows.Forms.RadioButton absentRadioButton;
        private BorderButton acceptButton;
        private System.Windows.Forms.ComboBox studentComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpNgayDiemDanh;
    }
}