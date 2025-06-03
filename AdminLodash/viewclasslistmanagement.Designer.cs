namespace AdminLodash
{
    partial class viewclasslistmanagement
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
            this.dataGridViewLopHoc = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.borderButton1 = new AdminLodash.BorderButton();
            this.label3 = new System.Windows.Forms.Label();
            this.coboHV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLopHoc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLopHoc)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLopHoc
            // 
            this.dataGridViewLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLopHoc.Location = new System.Drawing.Point(419, 1);
            this.dataGridViewLopHoc.Name = "dataGridViewLopHoc";
            this.dataGridViewLopHoc.Size = new System.Drawing.Size(927, 543);
            this.dataGridViewLopHoc.TabIndex = 0;
            this.dataGridViewLopHoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 543);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.borderButton1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.coboHV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboClass);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 290);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add student to the class";
            // 
            // borderButton1
            // 
            this.borderButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(144)))), ((int)(((byte)(215)))));
            this.borderButton1.BoderRadius1 = 40;
            this.borderButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.borderButton1.BorderSize = 0;
            this.borderButton1.FlatAppearance.BorderSize = 0;
            this.borderButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton1.ForeColor = System.Drawing.Color.White;
            this.borderButton1.Location = new System.Drawing.Point(226, 153);
            this.borderButton1.Name = "borderButton1";
            this.borderButton1.Size = new System.Drawing.Size(146, 40);
            this.borderButton1.TabIndex = 5;
            this.borderButton1.Text = "add";
            this.borderButton1.TextColor = System.Drawing.Color.White;
            this.borderButton1.UseVisualStyleBackColor = false;
            this.borderButton1.Click += new System.EventHandler(this.borderButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Student Name";
            // 
            // coboHV
            // 
            this.coboHV.FormattingEnabled = true;
            this.coboHV.Location = new System.Drawing.Point(119, 101);
            this.coboHV.Name = "coboHV";
            this.coboHV.Size = new System.Drawing.Size(253, 24);
            this.coboHV.TabIndex = 4;
            this.coboHV.SelectedIndexChanged += new System.EventHandler(this.coboHV_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cboClass
            // 
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(119, 48);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(253, 24);
            this.cboClass.TabIndex = 2;
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboLopHoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "checking list class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Name";
            // 
            // cboLopHoc
            // 
            this.cboLopHoc.FormattingEnabled = true;
            this.cboLopHoc.Location = new System.Drawing.Point(106, 41);
            this.cboLopHoc.Name = "cboLopHoc";
            this.cboLopHoc.Size = new System.Drawing.Size(253, 24);
            this.cboLopHoc.TabIndex = 0;
            // 
            // viewclasslistmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewLopHoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewclasslistmanagement";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLopHoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLopHoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboClass;
        private BorderButton borderButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox coboHV;
    }
}