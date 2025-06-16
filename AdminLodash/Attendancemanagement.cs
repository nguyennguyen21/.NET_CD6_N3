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
using Org.BouncyCastle.Asn1.Cmp;
using static Bus.BUS;

namespace AdminLodash
{
    public partial class Attendancemanagement : Form
    {
        internal Timer fadeInTimer;
        public Attendancemanagement()
        {
            InitializeComponent();



           
            LoadClasses();  // Tải danh sách lớp học
            LoadStatusOptions();            // Tải trạng thái vào ComboBox
            dtpDate.Value = DateTime.Now;
            LoadStudents(); // Tải danh sách học viên
            LoadClassesForFind();

        }

        private void LoadStudents()
        {
            try
            {
                DataTable dtStudents = Data.SQLServer.LayDanhSachHocVien();

                if (dtStudents.Rows.Count > 0)
                {
                    studentComboBox.DisplayMember = "FullName"; // Hiển thị tên học viên
                    studentComboBox.ValueMember = "StudentID";  // Lưu mã học viên
                    studentComboBox.DataSource = dtStudents;    // Gán nguồn dữ liệu
                }
                else
                {
                    MessageBox.Show("Không có học viên nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học viên: " + ex.Message);
            }
        }
        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClass.SelectedValue != null)
            {
                string selectedClassId = cbxClass.SelectedValue.ToString();
                LoadStudentsByClass(selectedClassId); // Tải học viên theo lớp
            }
        }
      
        private void LoadStudentsByClass(string classId)
        {
            try
            {
                DataTable dtStudents = Data.SQLServer.LayDanhSachHocVienTheoLop(classId);

                if (dtStudents.Rows.Count > 0)
                {
                    dgvDiemDanh.DataSource = dtStudents;
                }
                else
                {
                    MessageBox.Show("Lớp học này chưa có học viên nào.");
                    dgvDiemDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học viên theo lớp: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm lấy dữ liệu điểm danh từ SQLServer
                DataTable dtAttendance = Data.SQLServer.LayDanhSachDiemDanh();

                // Kiểm tra xem có dữ liệu không
                if (dtAttendance.Rows.Count > 0)
                {
                    dgvDiemDanh.DataSource = dtAttendance;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu điểm danh.");
                    dgvDiemDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu điểm danh: " + ex.Message);
            }
        }
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

     

        private void LoadStatusOptions()
        {
            cbxStatus.Items.Clear();
            cbxStatus.Items.Add("Có mặt");
            cbxStatus.Items.Add("Vắng");
            cbxStatus.SelectedIndex = 0; // Mặc định chọn "Có mặt"
        }

        private void LoadClasses()
        {
            DataTable dt = Data.SQLServer.laydulieutheotenbang("Classes");
            cbxClass.DisplayMember = "ClassName";
            cbxClass.ValueMember = "ClassID";
            cbxClass.DataSource = dt;
        }
        private void LoadAttendance()
        {
            try
            {
                DataTable dt = Data.SQLServer.LayDanhSachDiemDanh();
                dgvDiemDanh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách điểm danh: " + ex.Message);
            }
        }

        private void studentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue != null)
            {
                string studentId = studentComboBox.SelectedValue.ToString();
                Console.WriteLine("StudentID: " + studentId);
            }
            if (cbxClass.SelectedValue != null)
            {
                string selectedClassId = cbxClass.SelectedValue.ToString();
                string selectedDate = dtpDate.Value.ToString("yyyy-MM-dd"); // Nếu dùng DateTimePicker
                LoadAttendanceByClass(selectedClassId, selectedDate);
            }
        }

        private void LoadAttendanceByClass(string classId, string date)
        {
            try
            {
                DataTable dtAttendance = Data.SQLServer.LayDanhSachDiemDanhTheoLopVaNgay(classId, date);

                if (dtAttendance.Rows.Count > 0)
                {
                    dgvDiemDanh.DataSource = dtAttendance;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu điểm danh cho lớp này trong ngày đã chọn.");
                    dgvDiemDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu điểm danh: " + ex.Message);
            }
        }
        private void borderButton1_Click(object sender, EventArgs e)
        {
            string classId = cbxClass.SelectedValue?.ToString();
            string status = cbxStatus.SelectedItem?.ToString();
            DateTime date = dtpDate.Value;

            if (string.IsNullOrEmpty(classId) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Vui lòng chọn lớp và trạng thái.");
                return;
            }

            try
            {
                DataTable students = Data.SQLServer.LayDanhSachHocVienTheoLop(classId);

                foreach (DataRow row in students.Rows)
                {
                    string studentId = row["StudentID"].ToString();

                    // Kiểm tra xem đã điểm danh chưa
                    if (!AttendanceBUS.CheckAttendance(studentId, classId, date))
                    {
                        int result = SQLServer.ThemDiemDanh(studentId, classId, date, status);
                        if (result <= 0)
                        {
                            MessageBox.Show($"Không thể thêm điểm danh cho học viên {studentId}");
                        }
                    }
                }

                MessageBox.Show("Điểm danh thành công!");
                LoadAttendance(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi điểm danh: " + ex.Message);
            }
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


  

        private void absentRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

    

        private void LoadAttendanceByClassAndDate(string classId, string date)
        {
            try
            {
                DataTable dt = Data.SQLServer.LayDanhSachDiemDanhTheoLopVaNgay(classId, date);
                dgvDiemDanh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải điểm danh tự động: " + ex.Message);
            }
        }
        private void borderButton1_Click_1(object sender, EventArgs e)
        {
            // Lấy ClassID từ ComboBox
            if (cbxClass.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một lớp học.");
                return;
            }

            string classId = cbxClass.SelectedValue.ToString();
            string selectedDate = dtpDate.Value.ToString("yyyy-MM-dd"); // Định dạng ngày đúng kiểu SQL

            try
            {
                // Gọi hàm lấy điểm danh theo lớp và ngày
                DataTable dtAttendance = Data.SQLServer.LayDanhSachDiemDanhTheoLopVaNgay(classId, selectedDate);

                if (dtAttendance.Rows.Count > 0)
                {
                    dgvDiemDanh.DataSource = dtAttendance;
                    MessageBox.Show($"Hiển thị {dtAttendance.Rows.Count} bản ghi điểm danh.");
                }
                else
                {
                    dgvDiemDanh.DataSource = null;
                    MessageBox.Show("Không có dữ liệu điểm danh cho lớp và ngày đã chọn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu điểm danh: " + ex.Message);
            }
        }
        private void LoadClassesForFind()
        {
            try
            {
                DataTable dt = Bus.BUS.ClassBUS.LayDanhLopHoc();

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Các cột trong DataTable: " + string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    cbxClassFind.DisplayMember = "ClassName";
                    cbxClassFind.ValueMember = "ClassID";
                    cbxClassFind.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có lớp học nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp học: " + ex.Message);
            }
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
