namespace AdminLodash
{
    partial class statisticalmanagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statisticalmanagement));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.borderButton1 = new AdminLodash.BorderButton();
            this.pictureBorder1 = new AdminLodash.pictureBorder.PictureBorder();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBorder1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.borderButton1.Location = new System.Drawing.Point(33, 28);
            this.borderButton1.Name = "borderButton1";
            this.borderButton1.Size = new System.Drawing.Size(150, 46);
            this.borderButton1.TabIndex = 0;
            this.borderButton1.Text = "Revenue";
            this.borderButton1.TextColor = System.Drawing.Color.White;
            this.borderButton1.UseVisualStyleBackColor = false;
            this.borderButton1.Click += new System.EventHandler(this.borderButton1_Click);
            // 
            // pictureBorder1
            // 
            this.pictureBorder1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBorder1.BackgroundImage")));
            this.pictureBorder1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pictureBorder1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.pictureBorder1.BorderColor2 = System.Drawing.Color.HotPink;
            this.pictureBorder1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pictureBorder1.BorderSize = 2;
            this.pictureBorder1.GradientAngle = 50F;
            this.pictureBorder1.Location = new System.Drawing.Point(1052, 12);
            this.pictureBorder1.Name = "pictureBorder1";
            this.pictureBorder1.Size = new System.Drawing.Size(209, 209);
            this.pictureBorder1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBorder1.TabIndex = 3;
            this.pictureBorder1.TabStop = false;
            this.pictureBorder1.Click += new System.EventHandler(this.pictureBorder1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(13, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 410);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(20, 24);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(897, 374);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(973, 246);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(348, 245);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // statisticalmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 506);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBorder1);
            this.Controls.Add(this.borderButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "statisticalmanagement";
            this.Text = "statisticalmanagement";
            this.Load += new System.EventHandler(this.statisticalmanagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBorder1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderButton borderButton1;
        private pictureBorder.PictureBorder pictureBorder1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}