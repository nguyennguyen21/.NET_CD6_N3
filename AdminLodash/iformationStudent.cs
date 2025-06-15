using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace AdminLodash
{
    public partial class iformationStudent : Form
    {
        public iformationStudent()
        {
            InitializeComponent();

            txtFullName.Text = "";
            labelDateOfBirth.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            labelTongDaNop.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            labelDateOfBirth.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            labelTongDaNop.Text = "";
        }
        private void DateofBirth_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

    
        private void Search_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Vui lòng nhập mã học viên để tìm kiếm.");
                return;
            }

            // Gọi hàm lấy thông tin học viên từ BUS
            DataTable dt = Bus.BUS.StudentBUS.TimHocVienTheoMa(studentId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Hiển thị thông tin học viên
                txtFullName.Text = row["FullName"].ToString();
                labelDateOfBirth.Text = Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MM/yyyy");
                txtGender.Text = row["Gender"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtEmail.Text = row["Email"].ToString(); // Nếu trong bảng Students có Email
                txtStatus.Text = row["Status"].ToString();
                // ... các field khác nếu cần
            }
            else
            {
                MessageBox.Show("Không tìm thấy học viên với mã đã nhập.");
                ClearFields(); // Hàm xóa trắng các ô input
            }
            DataTable dtFees = Bus.BUS.FeeBUS.LayHocPhiTheoHocVien(studentId);
            decimal tongDaNop = 0;
            foreach (DataRow row in dtFees.Rows)
            {
                decimal paid;
                if (decimal.TryParse(row["PaidAmount"].ToString(), out paid))
                {
                    tongDaNop += paid;
                }
            }

            labelTongDaNop.Text = $" {tongDaNop:N0} VNĐ";


        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }
    }
}
