using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using Data;
using static Bus.BUS;

namespace AdminLodash
{
    public partial class Attendancemanagement : Form
    {
        public Attendancemanagement()
        {
            InitializeComponent();
            acceptButton.Click += acceptButton_Click;
            LoadClasses();
            LoadStudentsByClass();

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(cmbLopHoc.Text) || string.IsNullOrEmpty(studentComboBox.Text) ||
                !presentRadioButton.Checked && !absentRadioButton.Checked)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                int studentID = AttendanceBUS.GetStudentID(studentComboBox.Text);
                int classID = AttendanceBUS.GetClassID(cmbLopHoc.Text);
                DateTime date = DateTime.Parse(dtpNgayDiemDanh.Text);
                string status = presentRadioButton.Checked ? "Present" : "Absent";

                if (AttendanceBUS.CheckAttendance(studentID, classID, date))
                {
                    MessageBox.Show("You have already checked attendance for this day.");
                }
                else
                {
                    if (AttendanceBUS.InsertAttendance(studentID, classID, date, status))
                    {
                        MessageBox.Show("Check attendance successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to check attendance.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadClasses();
            LoadStudents();
        }


        private void LoadClasses()
        {
            

            DataTable dt = ClassBUS.LayDanhLopHoc(); // Lấy danh sách lớp từ BUS
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có lớp nào trong cơ sở dữ liệu.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                cmbLopHoc.Items.Add(row["ClassName"].ToString());
            }



        }

        private void LoadStudents()
        {
            studentComboBox.Items.Clear();

            DataTable dt = Data.SQLServer.laydulieutheotenbang("Students");
            foreach (DataRow row in dt.Rows)
            {
                studentComboBox.Items.Add(row["FullName"].ToString());
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
          
        }
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string className = cmbLopHoc.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(className)) return;

            DataTable dtClasses = ClassBUS.LayDanhLopHoc();
            foreach (DataRow row in dtClasses.Rows)
            {
                if (row["ClassName"].ToString() == className)
                {
                    string classId = row["ClassID"].ToString();
                    DataTable dtHocVien = ClassBUS.LayDanhSachHocVienTheoLop(classId);

                    // Debug: Hiển thị số lượng bản ghi
                    MessageBox.Show($"Tìm thấy {dtHocVien.Rows.Count} học viên trong lớp {classId}");

                    dgvDiemDanh.DataSource = dtHocVien;
                    break;
                }
            }
        }
        private void borderButton1_Click(object sender, EventArgs e)
        {
            if (cmbLopHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một lớp học.");
                return;
            }

            string classId = cmbLopHoc.SelectedValue?.ToString() ?? cmbLopHoc.SelectedItem.ToString();
            DateTime ngayDiemDanh = dtpNgayDiemDanh.Value.Date;

            // Gọi hàm phù hợp dựa trên mục tiêu: Theo lớp và ngày
            DataTable dtDiemDanh = SQLServer.LayDanhSachDiemDanhTheoLopVaNgay(classId, ngayDiemDanh.ToString("yyyy-MM-dd"));

            dgvDiemDanh.DataSource = dtDiemDanh;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void LoadStudentsByClass()
        {
            string className = cmbLopHoc.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(className)) return;

            DataTable dtClasses = ClassBUS.LayDanhLopHoc();
            foreach (DataRow row in dtClasses.Rows)
            {
                if (row["ClassName"].ToString() == className)
                {
                    string classId = row["ClassID"].ToString();
                    DataTable dtHocVien = ClassBUS.LayDanhSachHocVienTheoLop(classId);
                    dgvDiemDanh.DataSource = dtHocVien;
                    break;
                }
            }
        }

        
    }
}
