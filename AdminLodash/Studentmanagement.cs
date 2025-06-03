using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;

namespace AdminLodash
{
    public partial class Studentmanagement : Form
    {
        public Studentmanagement()
        {
            InitializeComponent();
            this.Load += StudentManagement_Load;
        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            if (!dataGridView2.Columns.Contains("colXoa"))
            {
                var btnDelete = new DataGridViewButtonColumn()
                {
                    Name = "colXoa",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dataGridView2.Columns.Add(btnDelete);

                var btnrepair = new DataGridViewButtonColumn()
                {
                    Name = "colsua",
                    Text = "repair",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dataGridView2.Columns.Add(btnrepair);

            }
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL thông qua lớp BUS
                DataTable dt = BUS.StudentBUS.LayDanhSachHocVien();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Gán trực tiếp vào dataGridView2 đã có sẵn trên Form
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có khóa học nào trong cơ sở dữ liệu.");
                    dataGridView2.DataSource = null;
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

        private void borderButton3_Click(object sender, EventArgs e)
        {
            iformationStudent iformationStudent = new iformationStudent();
            iformationStudent.Show();

        }
    }
}
