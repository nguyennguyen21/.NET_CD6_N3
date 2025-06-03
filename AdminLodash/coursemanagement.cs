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
using ClosedXML.Excel;

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

            borderButton8.Click += borderButton8_Click_1;
            borderButton8.Click -= borderButton8_Click_1;


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
        private bool sortedByStartDate = false;

        private void borderButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource == null)
                {
                    MessageBox.Show("Chưa có dữ liệu để sắp xếp.");
                    return;
                }

                // Sắp xếp theo StartDate tăng dần
                if (dataGridView2.DataSource is DataTable originalDt)
                {
                    DataView dv = new DataView(originalDt)
                    {
                        Sort = "StartDate ASC"
                    };
                    dataGridView2.DataSource = dv;
                }

                // Vô hiệu hóa nút kia
                borderButton5.Enabled = false;

                // Bật lại nút này nếu nhấn lại
                borderButton3.Click -= borderButton3_Click;
                borderButton3.Click += borderButton3_ResetClick;

                // Đổi text hoặc thông báo tùy chọn
                borderButton3.Text = "Sorted by StartDate";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void borderButton3_ResetClick(object sender, EventArgs e)
        {
            try
            {
                // Quay về chế độ mặc định (không sắp xếp)
                LoadData(); // Hàm tải lại dữ liệu gốc

                // Bật lại nút kia
                borderButton5.Enabled = true;

                // Khôi phục trạng thái ban đầu của nút
                borderButton3.Text = "Sort by StartDate";

                // Đăng ký lại sự kiện ban đầu
                borderButton3.Click -= borderButton3_ResetClick;
                borderButton3.Click += borderButton3_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
            try
            {
                if (dataGridView2.DataSource == null)
                {
                    MessageBox.Show("Chưa có dữ liệu để sắp xếp.");
                    return;
                }

                // Sắp xếp theo EndDate tăng dần
                if (dataGridView2.DataSource is DataTable originalDt)
                {
                    DataView dv = new DataView(originalDt)
                    {
                        Sort = "EndDate ASC"
                    };
                    dataGridView2.DataSource = dv;
                }

                // Vô hiệu hóa nút kia
                borderButton3.Enabled = false;

                // Thay đổi hành vi khi nhấn lại
                borderButton5.Click -= borderButton5_Click;
                borderButton5.Click += borderButton5_ResetClick;

                // Đổi tên nút để người dùng biết đang ở chế độ sắp xếp
                borderButton5.Text = "Sorted by EndDate";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void borderButton5_ResetClick(object sender, EventArgs e)
        {
            try
            {
                // Tải lại dữ liệu gốc
                LoadData();

                // Bật lại nút kia
                borderButton3.Enabled = true;

                // Khôi phục tên nút và sự kiện
                borderButton5.Text = "Sort by EndDate";
                borderButton5.Click -= borderButton5_ResetClick;
                borderButton5.Click += borderButton5_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void borderButton6_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dữ liệu để xuất không
                if (dataGridView2.DataSource == null)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    return;
                }

                // Chọn đường dẫn lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = "DanhSachKhoaHoc.xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = saveFileDialog.FileName;

                // Lấy dữ liệu từ DataGridView
                var dataTable = new DataTable("Courses");

                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (column.Visible)
                        dataTable.Columns.Add(column.HeaderText ?? column.Name);
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
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
            try
            {
                if (dataGridView2.DataSource is DataTable dt)
                {
                    DataView dv = new DataView(dt)
                    {
                        Sort = "TuitionFee ASC"
                    };

                    dataGridView2.DataSource = dv;
                    MessageBox.Show("Sắp xếp theo học phí thành công!");
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ để sắp xếp.");
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua cảnh báo về ex nếu không dùng
                MessageBox.Show("Lỗi khi sắp xếp.");
            }
        }
        private bool isEditingMode = false;
        private void borderButton8_Click(object sender, EventArgs e)
        {
            if (!isEditingMode)
            {
                // Chế độ sửa – đổi tên nút và mở ReadOnly
                borderButton8.Text = "Save";
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
            if (txtTimKiem != null)
                txtTimKiem.Texts = "";

            if (txtCourseName != null)
                txtCourseName.Texts = "";

            if (txtDescription != null)
                txtDescription.Texts = "";

            if (txtTuitionFee != null)
                txtTuitionFee.Texts = "";

            if (txtDuration != null)
                txtDuration.Texts = "";

            if (cmbLevel != null)
            {
                cmbLevel.SelectedIndex = -1; // Bỏ chọn
                cmbLevel.Text = "";          // Đặt lại text (nếu có)
            }

            if (dtpStartDate != null)
                dtpStartDate.Value = DateTime.Now;

            if (dtpEndDate != null)
                dtpEndDate.Value = DateTime.Now.AddDays(30); // Mặc định +30 ngày
        
        }

        private bool isEdittingMode = false;
        private void borderButton8_Click_1(object sender, EventArgs e)
        {
            if (!isEdittingMode)
            {
                // Bắt đầu chế độ sửa
                dataGridView2.ReadOnly = false;
                borderButton8.Text = "Save";
                isEditingMode = true;

                // Đăng ký sự kiện KeyDown để bắt phím Enter
                dataGridView2.KeyDown += dataGridView2_KeyDown;
            }
            else
            {
                // Kết thúc chế độ sửa – hiện MessageBox xác nhận
                XacNhanLuuDuLieu();
            }



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
                "acept",
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
            borderButton8.Text = "repair";
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
                    int ketQua = Bus.BUS.XoaKhoaHocKhongRangBuoc(courseId); // Hoặc XoaKhoaHoc
                    
                        LoadData(); // Làm mới dữ liệu trên lưới
                   
                   
                }
            }
        }

        private void borderButton2_Click(object sender, EventArgs e)
        {
              ResetForm();
              LoadData();
        }

        private void txtTuitionFee_Load(object sender, EventArgs e)
        {

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
                DataTable dt = BUS.TimKhoaHocTheoTenHoacMa(keyword);

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khóa học nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

