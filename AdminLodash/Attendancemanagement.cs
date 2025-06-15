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
        internal Timer fadeInTimer;
        public Attendancemanagement()
        {
            InitializeComponent();
            acceptButton.Click += acceptButton_Click;
          
            LoadClasses();
            LoadStudentsByClass();
            AddStatusColumn(); // Thêm dòng này

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
                string studentID = AttendanceBUS.GetStudentID(studentComboBox.Text);
                string  classID = AttendanceBUS.GetClassID(cmbLopHoc.Text);
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

        private void AddStatusColumn()
        {
            var statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Trạng thái";
            statusColumn.Name = "Status";
            statusColumn.Items.Add("Present");
            statusColumn.Items.Add("Absent");
            if (!dgvDiemDanh.Columns.Contains("Status"))
            {
                dgvDiemDanh.Columns.Add(statusColumn);
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
            if (cmbLopHoc.SelectedItem == null || dgvDiemDanh.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và đảm bảo có học viên.");
                return;
            }

            string className = cmbLopHoc.SelectedItem.ToString();
            string classId = "";

            // Lấy ClassID từ tên lớp
            DataTable dtClasses = ClassBUS.LayDanhLopHoc();
            foreach (DataRow row in dtClasses.Rows)
            {
                if (row["ClassName"].ToString() == className)
                {
                    classId = row["ClassID"].ToString();
                    break;
                }
            }

            if (string.IsNullOrEmpty(classId))
            {
                MessageBox.Show("Không tìm thấy mã lớp.");
                return;
            }

            DateTime date = dtpNgayDiemDanh.Value.Date;

            foreach (DataGridViewRow row in dgvDiemDanh.Rows)
            {
                if (row.IsNewRow) continue;

                string studentId = row.Cells["StudentID"].Value?.ToString();
                string status = row.Cells["Status"].Value?.ToString();

                if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cho tất cả học viên.");
                    return;
                }

                try
                {
                    if (AttendanceBUS.CheckAttendance(studentId, classId, date))
                    {
                        MessageBox.Show($"Đã điểm danh {studentId} hôm nay rồi.");
                        continue;
                    }

                    if (!AttendanceBUS.InsertAttendance(studentId, classId, date, status))
                    {
                        MessageBox.Show($"Không thể điểm danh {studentId}.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            MessageBox.Show("Điểm danh thành công cho lớp " + className);
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

            DataTable dtClasses = ClassBUS.LayDanhLopHoc(); // Lấy danh sách lớp

            foreach (DataRow row in dtClasses.Rows)
            {
                if (row["ClassName"].ToString() == className)
                {
                    string classId = row["ClassID"].ToString();

                    // Lấy danh sách học viên của lớp này từ CSDL
                    DataTable dtHocVien = ClassBUS.LayDanhSachHocVienTheoLop(classId);

                    dgvDiemDanh.DataSource = dtHocVien;
                    break;
                }
            }
        }

        private void absentRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
