using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using ClosedXML.Excel;
using Data;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.WellKnownTypes;
using static Bus.BUS;
namespace AdminLodash
{
    public partial class classmanagement : Form
    {
        internal Timer fadeInTimer;
        public classmanagement()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.Load += classmanagement_Load;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;

            this.KeyPreview = true;
            this.KeyDown += classmanagement_KeyDown;


        }

        private int currentRowIndex = -1; // Thêm dòng này đầu class (khai báo biến toàn cục)
        private bool isEditingMode = false;
        private void LoadDataForClass()
        {
            try
            {
                // Lấy dữ liệu từ lớp BUS
                DataTable dt = Bus.BUS.ClassBUS.LayDanhLopHoc();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có lớp học nào.");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lớp học: " + ex.Message);
            }
        }
        private void classmanagement_Load(object sender, EventArgs e)
        {
            LoadDataForClass();

            try
            {
                // Lấy danh sách khóa học từ BUS
                DataTable dtCourses = Bus.BUS.LayDanhSachKhoaHoc();

                if (dtCourses.Rows.Count > 0)
                {
                    cboCourseID.DataSource = dtCourses;
                    cboCourseID.DisplayMember = "CourseName";
                    cboCourseID.ValueMember = "CourseID";
                }
                else
                {   
                    MessageBox.Show("Không có khóa học nào trong hệ thống.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khóa học: " + ex.Message);
            }
            // Thêm cột Sửa nếu chưa có
            if (!dataGridView1.Columns.Contains("colSua"))
            {
                var btnSua = new DataGridViewButtonColumn()
                {
                    Name = "colSua",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Sửa"
                };
                dataGridView1.Columns.Add(btnSua);
            }
            try
            {
                // Lấy danh sách lớp học từ BUS
                DataTable dtTeacher = Bus.BUS.TeacherBUS.LayDanhSachGiaoVien();

                if (dtTeacher.Rows.Count > 0)
                {
                    cboTeacher.DataSource = dtTeacher;
                    cboTeacher.DisplayMember = "FullName";
                    cboTeacher.ValueMember = "TeacherID";
                }
                else
                {
                    MessageBox.Show("Không có khóa học nào trong hệ thống.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khóa học: " + ex.Message);
            }

            // Thêm cột Xóa nếu chưa có
            if (!dataGridView1.Columns.Contains("colXoa"))
            {
                var btnXoa = new DataGridViewButtonColumn()
                {
                    Name = "colXoa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Xóa"
                };
                dataGridView1.Columns.Add(btnXoa);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void borderButton5_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dữ liệu để xuất không
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    return;
                }

                // Chọn đường dẫn lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = "DanhSachLopHoc.xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = saveFileDialog.FileName;

                // Lấy dữ liệu từ DataGridView
                var dataTable = new DataTable("Classes");

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Visible)
                        dataTable.Columns.Add(column.HeaderText ?? column.Name);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var dataRow = dataTable.NewRow();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Value != null)
                                dataRow[i] = row.Cells[i].Value.ToString();
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                // Tạo workbook và xuất dữ liệu
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(dataTable);
                    workbook.SaveAs(filePath);
                }

                // Hỏi người dùng có muốn mở file không
                DialogResult result = MessageBox.Show("Xuất dữ liệu thành công! Bạn có muốn mở file Excel?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer", filePath); // Mở thư mục chứa file
                                                                            // Hoặc dùng: System.Diagnostics.Process.Start(filePath);
                }

                MessageBox.Show("Đã xuất dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
            }
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            // Lấy tên lớp từ textbox
            string className = txtClassName.Text.Trim();

            // Tạo mã lớp học tự động từ Data.SQLServer
            string classId = Data.SQLServer.TaoMaLopHoc(className);

            // Lấy CourseID từ ComboBox (giả sử bạn đã đổ dữ liệu vào cboCourseID)
            string selectedCourseID = cboCourseID.SelectedValue?.ToString();

            // Lấy TeacherID từ ComboBox giáo viên (nếu có)
            string selectedTeacher = cboTeacher.SelectedValue?.ToString();

            // Các giá trị khác
            int maxStudent;
            if (!int.TryParse(txtMaxStudent.Texts.Trim(), out maxStudent) || maxStudent <= 0)
            {
                MessageBox.Show("Số lượng học viên tối đa phải là số dương.");
                return;
            }
            string schedule = textBox1.Texts.Trim();
            string room = txtRoom.Texts.Trim();

            // Gọi hàm ThemLopHoc từ ClassBUS để thêm lớp học
         

            try
            {
                int ketQua = Bus.BUS.ClassBUS.ThemLopHoc(
                classId,
                selectedCourseID,
                selectedTeacher,
                className,
                maxStudent,
                schedule,
                room
                );

                if (ketQua > 0)
                {
                    MessageBox.Show("Thêm khóa học thành công!");
                   LoadDataForClass(); // Làm mới dữ liệu trên lưới
                }
                else if (ketQua == 0)
                {
                    MessageBox.Show("Thêm thất bại: Dữ liệu không hợp lệ hoặc mã Lớp học đã tồn tại.");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại do lỗi hệ thống. Vui lòng kiểm tra kết nối hoặc liên hệ quản trị viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName == "colXoa")
            {
                string classId = dataGridView1.Rows[e.RowIndex].Cells["ClassID"].Value?.ToString();

                if (string.IsNullOrEmpty(classId))
                {
                    MessageBox.Show("Không lấy được mã lớp học.");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc muốn xóa lớp học {classId}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    int ketQua = Bus.BUS.ClassBUS.XoaLopHocKhongRangBuoc(classId);
                    if (ketQua > 0)
                    {
                        MessageBox.Show("Xóa lớp học thành công!");
                        LoadDataForClass(); // Làm mới dữ liệu trên lưới
                    }
                    else
                    {
                        LoadDataForClass();
                        MessageBox.Show("Xóa thất bại hoặc lớp học không tồn tại.");
                    }
                }
            }
        

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

           

            if (columnName == "colSua")
            {
                // Giả sử bạn có các TextBox sau:
                // txtClassID, txtCourseID, txtTeacherID, txtClassName, txtMaxStudent, txtSchedule, txtRoom
                dataGridView1.ReadOnly = false;
              
                isEditingMode = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

               
                txtClassName.Text = row.Cells["ClassName"].Value?.ToString();
                txtMaxStudent.Text = row.Cells["MaxStudent"].Value?.ToString();
                textBox1.Text = row.Cells["Schedule"].Value?.ToString();
                txtRoom.Text = row.Cells["Room"].Value?.ToString();

                // Cho phép chỉnh sửa
                txtClassName.ReadOnly = false;
                txtMaxStudent.Enabled = true;
                textBox1.Enabled = true;
                txtRoom.Enabled = true;

                currentRowIndex = e.RowIndex;
            }
        }

        void classmanagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && currentRowIndex >= 0)
            {
                e.SuppressKeyPress = true;

                var result = MessageBox.Show("Bạn có muốn lưu thay đổi?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Lấy dữ liệu từ DataGridView để cập nhật
                        string classId = dataGridView1.Rows[currentRowIndex].Cells["ClassID"].Value?.ToString();
                        string className = txtClassName.Text.Trim();

                        // Lấy giá trị từ ComboBox hoặc TextBox
                        string courseId = cboCourseID.SelectedValue?.ToString();
                        string teacherId = cboTeacher.SelectedValue?.ToString();
                        int maxStudent = int.Parse(txtMaxStudent.Text.Trim());
                        string schedule = textBox1.Text.Trim(); // Đảm bảo bạn có txtSchedule
                        string room = txtRoom.Text.Trim();       // Đảm bảo bạn có txtRoom

                        // Gọi hàm cập nhật lớp học
                        int ketQua = Bus.BUS.ClassBUS.CapNhatLopHoc(
                            classId,
                            courseId,
                            teacherId,
                            className,
                            maxStudent,
                            schedule,
                            room);

                        if (ketQua > 0)
                        {
                            MessageBox.Show("Cập nhật lớp học thành công!");
                            LoadDataForClass(); // Làm mới dữ liệu trên gridview
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại.");
                        }

                        SetControlsReadOnly(true);
                        currentRowIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    SetControlsReadOnly(true);
                    currentRowIndex = -1;
                }
            }
        }

        private void SetControlsReadOnly(bool isReadOnly)
        {
            txtClassName.ReadOnly = isReadOnly;
            txtMaxStudent.Enabled = true;
            textBox1.Enabled = true;
            txtRoom.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Texts.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.");
                return;
            }

            try
            {
                DataTable dt = BUS.ClassBUS.LopHocTheoTenHoacMa(keyword);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khóa học nào.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy khóa học nào.");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            txtClassName.Clear();
            txtMaxStudent.Enabled = true;
            textBox1.Enabled = true;
            txtRoom.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void borderButton7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Load(object sender, EventArgs e)
        {

        }

        private void borderButton6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
