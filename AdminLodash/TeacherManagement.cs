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
    public partial class TeacherManagement : Form
    {
        public TeacherManagement()
        {
            InitializeComponent();

            this.Load += TeacherManagement_Load;
        }
        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL thông qua lớp BUS
                DataTable dt = BUS.TeacherBUS.LayDanhSachGiaoVien();

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
        private void TeacherManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
