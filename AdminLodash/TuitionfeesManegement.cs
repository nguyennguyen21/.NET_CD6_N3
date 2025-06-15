using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using Data;
using static Bus.BUS;

namespace AdminLodash
{

    public partial class TuitionfeesManegement : Form
    {
        internal Timer fadeInTimer;
        public TuitionfeesManegement()
        {
            InitializeComponent();
            Load += frmTuitionFee_Load;
        }
        private void frmTuitionFee_Load(object sender, EventArgs e)
        {
            LoadHocPhi();
            LoadDanhSachLop();
        }

        private void LoadHocPhi()
        {
            
            DataTable dtHocPhi = SQLServer.laydulieutheotenbang("tuition_fees");
            if (dtHocPhi.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtHocPhi;
            }
            else
            {
                dataGridView2.DataSource = null;
                MessageBox.Show("Không có dữ liệu học phí.");
            }
        }
        private void LoadDanhSachLop()
        {
            DataTable dt = BUS.ClassBUS.LayDanhLopHoc();
            if (dt.Rows.Count > 0)
            {
                comboBoxClass.DataSource = dt;
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ClassID";
            }
            else
            {
                MessageBox.Show("Chưa có lớp học nào.");
            }
        }
        private void LoadDanhSachHocVienTheoLop(string classId)
        {
            DataTable dt = SQLServer.LayDanhSachHocVienTheoLop(classId);
            if (dt.Rows.Count > 0)
            {
                comboBoxStudent.DataSource = dt;
                comboBoxStudent.DisplayMember = "FullName"; // Tên hiển thị
                comboBoxStudent.ValueMember = "StudentID";  // Giá trị thực tế
            }
            else
            {
                comboBoxStudent.DataSource = null;
                MessageBox.Show("Lớp học này chưa có học viên nào.");
            }
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void borderButton8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TuitionfeesManegement_Load(object sender, EventArgs e)
        {
            LoadHocPhi();

           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            string studentId = comboBoxStudent.SelectedValue?.ToString();
            string classId = comboBoxClass.SelectedValue?.ToString();

            // Kiểm tra sinh viên và lớp học
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(classId))
            {
                MessageBox.Show("Vui lòng chọn học viên và lớp học.");
                return;
            }

            // Kiểm tra học viên có tồn tại không
            bool tonTaiHocVien = SQLServer.KiemTraTonTaiHocVien(studentId);
            if (!tonTaiHocVien)
            {
                MessageBox.Show("Học viên không tồn tại.");
                return;
            }

            // Kiểm tra lớp học có tồn tại không
            bool tonTaiLop = SQLServer.KiemTraTonTaiLopHoc(classId);
            if (!tonTaiLop)
            {
                MessageBox.Show("Lớp học không tồn tại.");
                return;
            }

            // Tiền phải trả
            if (!decimal.TryParse(txtAmountDue.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amountDue))
            {
                MessageBox.Show("Vui lòng nhập số tiền phải trả hợp lệ.", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tiền đã trả
            decimal paidAmount = 0;
            string paidText = txtPaidAmount.Text.Trim();
            if (!string.IsNullOrWhiteSpace(paidText))
            {
                if (!decimal.TryParse(paidText.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out paidAmount))
                {
                    MessageBox.Show("Vui lòng nhập số tiền đã trả hợp lệ.", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime dueDate = dtpDueDate.Value;
            DateTime? paymentDate = paidAmount >= amountDue ? DateTime.Now.Date : (DateTime?)null;
            byte status = paidAmount >= amountDue ? (byte)1 : (byte)0;

            try
            {
                int result = FeeBUS.ThemHocPhi(studentId, classId, amountDue, paidAmount, dueDate, paymentDate ?? default, status);

                if (result > 0)
                {
                    MessageBox.Show("Thêm học phí thành công!");
                    LoadHocPhi(); // Refresh datagridview
                }
                else if (result == 0)
                {
                    MessageBox.Show("Không có dòng nào bị ảnh hưởng. Dữ liệu có thể đã tồn tại.");
                }
                else
                {
                    MessageBox.Show("Thêm học phí thất bại. Lỗi hệ thống.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm học phí: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedValue != null)
            {
                string selectedClassId = comboBoxClass.SelectedValue.ToString();
                LoadDanhSachHocVienTheoLop(selectedClassId);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
