using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Bus;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using Google.Protobuf.WellKnownTypes;
using System.Runtime.InteropServices.ComTypes;
using Data;
using System.Globalization;

namespace AdminLodash
{
    public partial class coursemanagement : Form
    {
        public coursemanagement()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

          
            // Khởi tạo ComboBox cấp độ
            cmbLevel.Items.AddRange(new string[] { "Dễ", "Trung bình", "Khó", "Nâng cao" });
            this.Load += coursemanagement_Load;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellContentClick -= dataGridView2_CellContentClick;


        }
        private void InitializeCustomControls()
        {
            // Tạo cmbLevel
            cmbLevel = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200
            };
            cmbLevel.Items.AddRange(new object[] { "Dễ", "Trung bình", "Khó", "Nâng cao" });
            this.Controls.Add(cmbLevel);

            // Tạo dataGridView2
            dataGridView2 = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Top = 50,
                Height = 400
            };
            this.Controls.Add(dataGridView2);
        }
        private void borderButton3_Click(object sender, EventArgs e)
        {

        }


        
        private void coursemanagement_Load(object sender, EventArgs e)
        {
            // Thêm cột nút Xóa (nếu chưa có)
            if (!dataGridView2.Columns.Contains("colXoa"))
            {
                var btnDelete = new DataGridViewButtonColumn()
                {
                    Name = "colXoa",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dataGridView2.Columns.Add(btnDelete);
            }
            LoadData();
           
        }

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL thông qua lớp BUS
                DataTable dt = BUS.LayDanhSachKhoaHoc();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Gán trực tiếp vào dataGridView2 đã có sẵn trên Form
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có khóa học nào trong cơ sở dữ liệu.");
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
      


         

     
     
        private void textBox3_Load(object sender, EventArgs e)
        {

        }

        private void dateandTime1_Load(object sender, EventArgs e)
        {

        }

        private void borderButton5_Click(object sender, EventArgs e)
        {

        }

        private void borderButton6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e) {
            string level = cmbLevel.SelectedItem?.ToString() ?? "";
            string courseId = BUS.TaoMaKhoaHocTuDong(dtpStartDate.Value.Date); // Tự động sinh mã khóa học
            string courseName = txtCourseName.Texts.Trim();

            string description = txtDescription.Texts.Trim();

            string input = txtTuitionFee.Texts.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Học phí không được để trống.");
                return;
            }

            // Kiểm tra độ dài
            if (input.Length > 29)
            {
                MessageBox.Show("Giá trị quá lớn. Vui lòng nhập số nhỏ hơn 10^29.");
                return;
            }

            // Parse với culture en-US
            var culture = new CultureInfo("en-US");
            bool success = decimal.TryParse(
                input,
                NumberStyles.Any,
                culture,
                out decimal tuitionFee
            );

            if (!success)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng học phí.");
                return;
            }

            if (!int.TryParse(txtDuration.Texts.Trim(), out int duration))
            {
                MessageBox.Show("Thời lượng phải là số nguyên.");
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(level))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tên khóa học và cấp độ.");
                return;
            }

            //Gọi hàm thêm khóa học từ lớp BUS
            try
            {
                int ketQua = Bus.BUS.ThemKhoaHoc(
                    courseId,
                    courseName,
                    level,
                    description,
                    tuitionFee,
                    duration,
                    startDate,
                    endDate);

                if (ketQua > 0)
                {
                    MessageBox.Show("Thêm khóa học thành công!");
                    LoadData(); // Làm mới dữ liệu trên lưới
                }
                else if (ketQua == 0)
                {
                    MessageBox.Show("Thêm thất bại: Dữ liệu không hợp lệ hoặc mã khóa học đã tồn tại.");
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

        private void textBox4_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void borderButton4_Click(object sender, EventArgs e)
        {

        }

        private void borderButton7_Click(object sender, EventArgs e)
        {

        }
        private bool isEditingMode = false;
        private void borderButton8_Click(object sender, EventArgs e)
        {
            if (!isEditingMode)
            {
                // Chế độ sửa – đổi tên nút và mở ReadOnly
                borderButton8.Text = "Lưu";
                dataGridView2.ReadOnly = false;
                isEditingMode = true;

                // Đăng ký sự kiện Enter để xác nhận lưu
                dataGridView2.KeyDown += dataGridView2_KeyDown;
            }
            else
            {
                // Chế độ lưu – hiện MessageBox xác nhận
                XacNhanLuuDuLieu();
            }
        }
        private void ResetForm()
        {
            // Xóa trắng các ô nhập liệu
            if (txtCourseName != null) txtCourseName.ResetText();
            //if (txtDescription != null) txtDescription.Clear();
            //if (txtTuitionFee != null) txtTuitionFee.Clear();
            //if (txtDuration != null) txtDuration.Clear();

            //if (cmbLevel != null) cmbLevel.SelectedIndex = -1;

            //if (dtpStartDate != null) dtpStartDate.Value = DateTime.Now;
            //if (dtpEndDate != null) dtpEndDate.Value = DateTime.Now.AddDays(30);
            //cmbLevel.SelectedIndex = -1;
            //txtDescription.Clear();
            //txtTuitionFee.Clear();
            //txtDuration.Clear();
            //dtpStartDate.Value = DateTime.Now;
            //dtpEndDate.Value = DateTime.Now.AddDays(30); // Mặc định 30 ngày sau
        }
        

        private void borderButton8_Click_1(object sender, EventArgs e)
        {
            

            
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                XacNhanLuuDuLieu();
            }
        }

        private void XacNhanLuuDuLieu()
        {
            int rowIndex = dataGridView2.CurrentCell?.RowIndex ?? -1;
            if (rowIndex < 0) return;

            var row = dataGridView2.Rows[rowIndex];
            string courseId = row.Cells["CourseID"].Value?.ToString();

            if (string.IsNullOrEmpty(courseId))
            {
                MessageBox.Show("Không lấy được mã khóa học.");
                return;
            }

            var data = new Dictionary<string, object>
            {
                ["CourseName"] = row.Cells["CourseName"].Value?.ToString(),
                ["Level"] = row.Cells["Level"].Value?.ToString(),
                ["Description"] = row.Cells["Description"].Value?.ToString(),
                ["TuitionFee"] = decimal.TryParse(row.Cells["TuitionFee"].Value?.ToString(), out decimal fee) ? fee : (object)DBNull.Value,
                ["Duration"] = int.TryParse(row.Cells["Duration"].Value?.ToString(), out int dur) ? dur : (object)DBNull.Value,
                ["StartDate"] = Convert.ToDateTime(row.Cells["StartDate"].Value),
                ["EndDate"] = Convert.ToDateTime(row.Cells["EndDate"].Value)
            };

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn lưu thay đổi?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Gọi hàm CapNhatDuLieu từ BUS
                int ketQua = Bus.BUS.CapNhatDuLieu("Courses", data, "CourseID = @CourseID",
                    new MySqlParameter("@CourseID", courseId));

                if (ketQua > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData(); // Làm mới dữ liệu trên lưới
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
            else
            {
                LoadData(); // Khôi phục dữ liệu cũ nếu hủy
            }

            // Trở lại chế độ xem
            dataGridView2.ReadOnly = true;
            borderButton8.Text = "Sửa";
            isEditingMode = false;
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "colXoa")
            {
                string courseId = dataGridView2.Rows[e.RowIndex].Cells["CourseID"].Value?.ToString();

                if (string.IsNullOrEmpty(courseId))
                {
                    MessageBox.Show("Không lấy được mã khóa học.");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc muốn xóa khóa học {courseId}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    int ketQua = Bus.BUS.XoaKhoaHoc(courseId);
                    if (ketQua > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData(); // Làm mới dữ liệu trên lưới
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Có thể do ràng buộc dữ liệu hoặc bản ghi không tồn tại.");
                        }
                    }
                }
            }

        private void borderButton2_Click(object sender, EventArgs e)
        {
              ResetForm();
        }

        private void txtTuitionFee_Load(object sender, EventArgs e)
        {

        }
    }
    }

