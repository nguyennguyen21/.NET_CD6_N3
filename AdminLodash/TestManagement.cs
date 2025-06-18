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
using Data;

namespace AdminLodash
{
    public partial class TestManagement : Form
    {
        public TestManagement()
        {
            InitializeComponent();
            LoadTestData();
            LoadDanhSachLopHoc();
        }

        private void LoadTestData()
        {
            try
            {
                DataTable dtTests = SQLServer.laydulieutheotenbang("Tests");
                dataGridView1.DataSource = dtTests;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDanhSachLopHoc()
        {
            try
            {
                DataTable dt = BUS.ClassBUS.LayDanhLopHoc(); // Hàm có sẵn trong SQLServer
                if (dt.Rows.Count > 0)
                {
                    cmbClassID.DataSource = dt;
                    cmbClassID.DisplayMember = "ClassName"; // Hiển thị tên lớp
                    cmbClassID.ValueMember = "ClassID";     // Giá trị thực là ClassID
                }
                else
                {
                    cmbClassID.Items.Add("Không có lớp nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lớp học: " + ex.Message);
            }
        }
        private void borderButton1_Click(object sender, EventArgs e)
        {
            string classId = cmbClassID.SelectedValue?.ToString();
            
            string testName = txtName.Text.Trim();
            DateTime testDate = dtpTestDate.Value;
            string description = txtDescription.Text.Trim();
            decimal fee = 0;

            if (!string.IsNullOrEmpty(txtFee.Text))
                decimal.TryParse(txtFee.Text, out fee);

            int ketQua = SQLServer.ThemBaiThi(classId, testName, testDate, description, fee);

            if (ketQua > 0)
            {
                MessageBox.Show("Thêm bài thi thành công!");
                LoadTestData(); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }
    }
}
