using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminLodash.ToggleControls;
using static Bus.BUS;

namespace AdminLodash
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        
       
        private void textBox1_Load(object sender, EventArgs e)
        {
            
        }

        private void panelRadius1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void togglecontrol1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void togglecontrol1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void borderButton2_Click(object sender, EventArgs e)
        {
           
        }
        private void borderButton2_Click_1(object sender, EventArgs e)
        {
            string teacherId = txtTeacherId.Texts.Trim();
            string password = txtPassword.Texts.Trim();

            if (string.IsNullOrEmpty(teacherId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đúng id nhập và mật khẩu.");
                return;
            }

            // Kiểm tra thông tin đăng nhập
            if (TeacherBUS.KiemTraDangNhapGiaoVien(teacherId, password))
            {
               

                // Chuyển sang form giáo viên
                this.Hide();
                Manege manege = new Manege(); // Giả sử bạn có form tên là TeacherDashboard
                manege.FormClosed += (s, args) => this.Close(); // Đóng form đăng nhập khi form mới đóng
                manege.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void togglecontrol1_CheckedChanged_2(object sender, EventArgs e)
        {
            // Nếu toggle bật (Checked = true) → hiện mật khẩu
            if (toggleControl1.Checked)
            {
                txtPassword.PasswordChar = false;
            }
            else
            {
                // Ngược lại, ẩn mật khẩu bằng ký tự '*'
                txtPassword.PasswordChar = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
