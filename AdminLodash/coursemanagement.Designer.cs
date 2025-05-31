namespace AdminLodash
{
    partial class coursemanagement
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.txtDuration = new AdminLodash.TextBox.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new AdminLodash.Datepicker.DateandTime();
            this.dtpStartDate = new AdminLodash.Datepicker.DateandTime();
            this.txtTuitionFee = new AdminLodash.TextBox.TextBox();
            this.txtDescription = new AdminLodash.TextBox.TextBox();
            this.txtCourseName = new AdminLodash.TextBox.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.borderButton2 = new AdminLodash.BorderButton();
            this.borderButton1 = new AdminLodash.BorderButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new AdminLodash.TextBox.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.borderButton8 = new AdminLodash.BorderButton();
            this.borderButton7 = new AdminLodash.BorderButton();
            this.borderButton6 = new AdminLodash.BorderButton();
            this.borderButton5 = new AdminLodash.BorderButton();
            this.borderButton4 = new AdminLodash.BorderButton();
            this.borderButton3 = new AdminLodash.BorderButton();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 530);
            this.panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbLevel);
            this.groupBox2.Controls.Add(this.txtDuration);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.txtTuitionFee);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.txtCourseName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.borderButton2);
            this.groupBox2.Controls.Add(this.borderButton1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 384);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "level";
            // 
            // cmbLevel
            // 
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "",
            "easy",
            "normal",
            "difficult",
            "advanced"});
            this.cmbLevel.Location = new System.Drawing.Point(94, 223);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(257, 24);
            this.cmbLevel.TabIndex = 17;
            // 
            // txtDuration
            // 
            this.txtDuration.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.txtDuration.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDuration.BorderSize = 3;
            this.txtDuration.Location = new System.Drawing.Point(99, 151);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.txtDuration.Multiline = false;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Padding = new System.Windows.Forms.Padding(28, 21, 28, 21);
            this.txtDuration.PasswordChar = false;
            this.txtDuration.Size = new System.Drawing.Size(252, 59);
            this.txtDuration.TabIndex = 16;
            this.txtDuration.Texts = "";
            this.txtDuration.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Duration";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEndDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpEndDate.BorderSize = 0;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpEndDate.Location = new System.Drawing.Point(94, 296);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(100, 35);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Padding = new System.Windows.Forms.Padding(5);
            this.dtpEndDate.Size = new System.Drawing.Size(253, 35);
            this.dtpEndDate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.dtpEndDate.TabIndex = 14;
            this.dtpEndDate.TextColor = System.Drawing.Color.White;
            this.dtpEndDate.Value = new System.DateTime(2025, 5, 28, 18, 53, 51, 4);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpStartDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpStartDate.BorderSize = 0;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpStartDate.Location = new System.Drawing.Point(94, 255);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(100, 35);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Padding = new System.Windows.Forms.Padding(5);
            this.dtpStartDate.Size = new System.Drawing.Size(254, 35);
            this.dtpStartDate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.dtpStartDate.TabIndex = 13;
            this.dtpStartDate.TextColor = System.Drawing.Color.White;
            this.dtpStartDate.Value = new System.DateTime(2025, 5, 28, 18, 53, 51, 4);
            this.dtpStartDate.Load += new System.EventHandler(this.dateandTime1_Load);
            // 
            // txtTuitionFee
            // 
            this.txtTuitionFee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.txtTuitionFee.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTuitionFee.BorderSize = 3;
            this.txtTuitionFee.Location = new System.Drawing.Point(99, 100);
            this.txtTuitionFee.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtTuitionFee.Multiline = false;
            this.txtTuitionFee.Name = "txtTuitionFee";
            this.txtTuitionFee.Padding = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.txtTuitionFee.PasswordChar = false;
            this.txtTuitionFee.Size = new System.Drawing.Size(256, 51);
            this.txtTuitionFee.TabIndex = 12;
            this.txtTuitionFee.Texts = "";
            this.txtTuitionFee.UnderlinedStyle = true;
            this.txtTuitionFee.Load += new System.EventHandler(this.txtTuitionFee_Load);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.txtDescription.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDescription.BorderSize = 3;
            this.txtDescription.Location = new System.Drawing.Point(99, 54);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.txtDescription.PasswordChar = false;
            this.txtDescription.Size = new System.Drawing.Size(256, 45);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.Texts = "";
            this.txtDescription.UnderlinedStyle = true;
            this.txtDescription.Load += new System.EventHandler(this.textBox4_Load);
            // 
            // txtCourseName
            // 
            this.txtCourseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.txtCourseName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCourseName.BorderSize = 3;
            this.txtCourseName.Location = new System.Drawing.Point(99, 14);
            this.txtCourseName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCourseName.Multiline = false;
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.txtCourseName.PasswordChar = false;
            this.txtCourseName.Size = new System.Drawing.Size(253, 39);
            this.txtCourseName.TabIndex = 10;
            this.txtCourseName.Texts = "";
            this.txtCourseName.UnderlinedStyle = true;
            this.txtCourseName.Load += new System.EventHandler(this.textBox3_Load);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "EndDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "StartDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "TuitionFee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "CourseName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // borderButton2
            // 
            this.borderButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton2.BoderRadius1 = 31;
            this.borderButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton2.BorderSize = 0;
            this.borderButton2.FlatAppearance.BorderSize = 0;
            this.borderButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton2.ForeColor = System.Drawing.Color.White;
            this.borderButton2.Location = new System.Drawing.Point(99, 337);
            this.borderButton2.Name = "borderButton2";
            this.borderButton2.Size = new System.Drawing.Size(120, 41);
            this.borderButton2.TabIndex = 3;
            this.borderButton2.Text = "ReNew";
            this.borderButton2.TextColor = System.Drawing.Color.White;
            this.borderButton2.UseVisualStyleBackColor = false;
            this.borderButton2.Click += new System.EventHandler(this.borderButton2_Click);
            // 
            // borderButton1
            // 
            this.borderButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton1.BoderRadius1 = 31;
            this.borderButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton1.BorderSize = 0;
            this.borderButton1.FlatAppearance.BorderSize = 0;
            this.borderButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton1.ForeColor = System.Drawing.Color.White;
            this.borderButton1.Location = new System.Drawing.Point(225, 337);
            this.borderButton1.Name = "borderButton1";
            this.borderButton1.Size = new System.Drawing.Size(120, 41);
            this.borderButton1.TabIndex = 2;
            this.borderButton1.Text = "Add";
            this.borderButton1.TextColor = System.Drawing.Color.White;
            this.borderButton1.UseVisualStyleBackColor = false;
            this.borderButton1.Click += new System.EventHandler(this.borderButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "course Id";
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.textBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox1.BorderSize = 3;
            this.textBox1.Location = new System.Drawing.Point(6, 64);
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(7);
            this.textBox1.PasswordChar = false;
            this.textBox1.Size = new System.Drawing.Size(339, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.Texts = "";
            this.textBox1.UnderlinedStyle = true;
            this.textBox1.Load += new System.EventHandler(this.textBox1_Load);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(407, 95);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(930, 447);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // borderButton8
            // 
            this.borderButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton8.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton8.BoderRadius1 = 40;
            this.borderButton8.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton8.BorderSize = 0;
            this.borderButton8.FlatAppearance.BorderSize = 0;
            this.borderButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderButton8.ForeColor = System.Drawing.Color.White;
            this.borderButton8.Location = new System.Drawing.Point(1187, 39);
            this.borderButton8.Name = "borderButton8";
            this.borderButton8.Size = new System.Drawing.Size(150, 50);
            this.borderButton8.TabIndex = 11;
            this.borderButton8.Text = "repair";
            this.borderButton8.TextColor = System.Drawing.Color.White;
            this.borderButton8.UseVisualStyleBackColor = false;
            this.borderButton8.Click += new System.EventHandler(this.borderButton8_Click_1);
            // 
            // borderButton7
            // 
            this.borderButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton7.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton7.BoderRadius1 = 40;
            this.borderButton7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton7.BorderSize = 0;
            this.borderButton7.FlatAppearance.BorderSize = 0;
            this.borderButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderButton7.ForeColor = System.Drawing.Color.White;
            this.borderButton7.Location = new System.Drawing.Point(875, 39);
            this.borderButton7.Name = "borderButton7";
            this.borderButton7.Size = new System.Drawing.Size(150, 50);
            this.borderButton7.TabIndex = 10;
            this.borderButton7.Text = "sort  TutionFee";
            this.borderButton7.TextColor = System.Drawing.Color.White;
            this.borderButton7.UseVisualStyleBackColor = false;
            this.borderButton7.Click += new System.EventHandler(this.borderButton7_Click);
            // 
            // borderButton6
            // 
            this.borderButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton6.BoderRadius1 = 40;
            this.borderButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton6.BorderSize = 0;
            this.borderButton6.FlatAppearance.BorderSize = 0;
            this.borderButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.borderButton6.ForeColor = System.Drawing.Color.White;
            this.borderButton6.Location = new System.Drawing.Point(1031, 39);
            this.borderButton6.Name = "borderButton6";
            this.borderButton6.Size = new System.Drawing.Size(150, 50);
            this.borderButton6.TabIndex = 8;
            this.borderButton6.Text = "export file";
            this.borderButton6.TextColor = System.Drawing.Color.White;
            this.borderButton6.UseVisualStyleBackColor = false;
            this.borderButton6.Click += new System.EventHandler(this.borderButton6_Click);
            // 
            // borderButton5
            // 
            this.borderButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton5.BoderRadius1 = 40;
            this.borderButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton5.BorderSize = 0;
            this.borderButton5.FlatAppearance.BorderSize = 0;
            this.borderButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderButton5.ForeColor = System.Drawing.Color.White;
            this.borderButton5.Location = new System.Drawing.Point(719, 39);
            this.borderButton5.Name = "borderButton5";
            this.borderButton5.Size = new System.Drawing.Size(150, 50);
            this.borderButton5.TabIndex = 7;
            this.borderButton5.Text = "sort  EndDate";
            this.borderButton5.TextColor = System.Drawing.Color.White;
            this.borderButton5.UseVisualStyleBackColor = false;
            this.borderButton5.Click += new System.EventHandler(this.borderButton5_Click);
            // 
            // borderButton4
            // 
            this.borderButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton4.BoderRadius1 = 37;
            this.borderButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton4.BorderSize = 0;
            this.borderButton4.FlatAppearance.BorderSize = 0;
            this.borderButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderButton4.ForeColor = System.Drawing.Color.White;
            this.borderButton4.Location = new System.Drawing.Point(407, 39);
            this.borderButton4.Name = "borderButton4";
            this.borderButton4.Size = new System.Drawing.Size(150, 50);
            this.borderButton4.TabIndex = 5;
            this.borderButton4.Text = "select All";
            this.borderButton4.TextColor = System.Drawing.Color.White;
            this.borderButton4.UseVisualStyleBackColor = false;
            this.borderButton4.Click += new System.EventHandler(this.borderButton4_Click);
            // 
            // borderButton3
            // 
            this.borderButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.borderButton3.BoderRadius1 = 40;
            this.borderButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton3.BorderSize = 0;
            this.borderButton3.FlatAppearance.BorderSize = 0;
            this.borderButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderButton3.ForeColor = System.Drawing.Color.White;
            this.borderButton3.Location = new System.Drawing.Point(563, 39);
            this.borderButton3.Name = "borderButton3";
            this.borderButton3.Size = new System.Drawing.Size(150, 50);
            this.borderButton3.TabIndex = 4;
            this.borderButton3.Text = "sort  startDate";
            this.borderButton3.TextColor = System.Drawing.Color.White;
            this.borderButton3.UseVisualStyleBackColor = false;
            this.borderButton3.Click += new System.EventHandler(this.borderButton3_Click);
            // 
            // coursemanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 545);
            this.Controls.Add(this.borderButton8);
            this.Controls.Add(this.borderButton7);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.borderButton6);
            this.Controls.Add(this.borderButton5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.borderButton4);
            this.Controls.Add(this.borderButton3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "coursemanagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "coursemanagement";
            this.Load += new System.EventHandler(this.coursemanagement_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BorderButton borderButton1;
        private BorderButton borderButton2;
        private BorderButton borderButton3;
        private BorderButton borderButton4;
        private System.Windows.Forms.Panel panel2;
        private TextBox.TextBox textBox1;
        private BorderButton borderButton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private BorderButton borderButton6;
        private TextBox.TextBox txtCourseName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Datepicker.DateandTime dtpStartDate;
        private TextBox.TextBox txtTuitionFee;
        private TextBox.TextBox txtDescription;
        private Datepicker.DateandTime dtpEndDate;
        private BorderButton borderButton7;
        private TextBox.TextBox txtDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private BorderButton borderButton8;
    }
}