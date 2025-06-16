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
using System.Xml.Linq;
using System.Security.Cryptography; // mã hóa mật khẩu
using MySql.Data.MySqlClient; // Thêm thư viện MySQL


namespace AdminLodash
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void borderTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_Load(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }
     
        private void borderButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Sinh mã học viên tự động
                string studentId = Data.SQLServer.TaoMaHocVienTuDong();

                // Lấy dữ liệu từ giao diện
                string fullName = txtFullName.Texts.Trim();
                DateTime dateOfBirth = dtpDateOfBirth.Value;
                string gender = "";
                if (radioButtonNam.Checked)
                {
                    gender = "Nam";
                }
                else if (rbnNu.Checked)
                {
                    gender = "Nữ";
                }
                string phone = txtPhone.Texts.Trim();
                string email = txtEmail.Texts.Trim();
                string address = txtAddress.Texts.Trim();
                DateTime registrationDate = DateTime.Now;
                int status = 1; // cũng đúng, nhưng phải đảm bảo hàm ThemSinhVien nhận tham số kiểu int
                string password = txtPassword.Texts.Trim();

                // Kiểm tra thông tin bắt buộc
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Thêm vào database
                int result = Data.SQLServer.ThemSinhVien(studentId, fullName, dateOfBirth, gender,
                                                         phone, email, address, registrationDate, status, password);

                if (result > 0)
                {
                    MessageBox.Show("Đăng ký thành công! Mã học viên của bạn là: " + studentId);
                    this.Close(); // hoặc reset form
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void borderButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Load(object sender, EventArgs e)
        {
            // code nhập tên Name vào
            txtFullName.Text = "";
        }

        private void textBox2_Load(object sender, EventArgs e)
        {

        }
      
         
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void borderButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelLoi_Click(object sender, EventArgs e)
        {

        }
    }


}

