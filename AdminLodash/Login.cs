using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;  // Xóa hoặc thay bằng MySql.Data nếu sử dụng MySQL
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
            FullName.Text = "";
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
    }


}

