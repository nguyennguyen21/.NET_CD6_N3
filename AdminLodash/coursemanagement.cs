using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Bus;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;

namespace AdminLodash
{
    public partial class coursemanagement : Form
    {
        public coursemanagement()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            InitializeCustomControls();
            // Khởi tạo ComboBox cấp độ
            cmbLevel.Items.AddRange(new string[] { "Dễ", "Trung bình", "Khó", "Nâng cao" });
            this.Load += coursemanagement_Load;


        }
        private void InitializeCustomControls()
        {
            // Tạo cmbLevel
            cmbLevel = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200
            };
            cmbLevel.Items.AddRange(new object[] { "Dễ", "Trung bình", "Khó", "Nâng cao" });
            this.Controls.Add(cmbLevel);

            // Tạo dataGridView2
            dataGridView2 = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Top = 50,
                Height = 400
            };
            this.Controls.Add(dataGridView2);
        }
        private void borderButton3_Click(object sender, EventArgs e)
        {

        }

        private void coursemanagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = BUS.LayDanhSachKhoaHoc();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }
      

        private void textBox3_Load(object sender, EventArgs e)
        {

        }

        private void dateandTime1_Load(object sender, EventArgs e)
        {

        }

        private void borderButton5_Click(object sender, EventArgs e)
        {

        }

        private void borderButton6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e) {

           
        }

        private void textBox4_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void borderButton4_Click(object sender, EventArgs e)
        {

        }

        private void borderButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
