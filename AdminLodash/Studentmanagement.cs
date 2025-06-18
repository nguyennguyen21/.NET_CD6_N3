using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using ClosedXML.Excel;
using Data;

namespace AdminLodash
{
    public partial class Studentmanagement : Form
    {
        internal Timer fadeInTimer;
        public Studentmanagement()
        {
            InitializeComponent();
            this.Load += StudentManagement_Load;
            borderButton2.Click += borderButton2_Click;
            borderButton2.Click -= borderButton2_Click;
            LoadData();
        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            LoadData();
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

                var btnrepair = new DataGridViewButtonColumn()
                {
                    Name = "colsua",
                    Text = "repair",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dataGridView2.Columns.Add(btnrepair);

            }
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
          
        }
        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ CSDL thông qua lớp BUS
                DataTable dt = BUS.StudentBUS.LayDanhSachHocVien();

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
        private bool isEditingMode = false;
        private DataTable originalData; // Lưu bản sao dữ liệu gốc để phục hồi nếu hủy
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột "Xóa"
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "colXoa")
            {
                var studentId = dataGridView2.Rows[e.RowIndex].Cells["StudentID"].Value?.ToString();

                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Không tìm thấy mã học viên.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa học viên {studentId}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowsAffected = SQLServer.XoaHocVienKhongRangBuoc(studentId);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa học viên thành công!");
                        LoadData(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Xóa học viên thành công!");
                        LoadData();
                    }
                }
            }

            // Kiểm tra nếu click vào cột "Sửa"
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "colsua")
            {
                var studentId = dataGridView2.Rows[e.RowIndex].Cells["StudentID"].Value?.ToString();

                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Không tìm thấy mã học viên.");
                    return;
                }

                // Bắt đầu chế độ sửa
                isEditingMode = true;
                originalData = (DataTable)dataGridView2.DataSource;

                // Sao chép dữ liệu để có thể quay lại nếu người dùng hủy
                var dtCopy = originalData.Copy();
                dataGridView2.ReadOnly = false;
                dataGridView2.AllowUserToAddRows = false;

                // Đăng ký sự kiện KeyDown để bắt Enter
                dataGridView2.KeyDown += DataGridView2_KeyDown;
            }
        }

        private void DataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isEditingMode)
            {
                e.Handled = true; // Ngăn xử lý mặc định của Enter

                DialogResult result = MessageBox.Show("Bạn có muốn lưu các thay đổi không?", "Xác nhận", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    // Gọi hàm cập nhật dữ liệu thực tế xuống database
                    SaveChangesToDatabase();
                    MessageBox.Show("Lưu thành công!");
                }
                else if (result == DialogResult.No)
                {
                    // Phục hồi dữ liệu cũ
                    dataGridView2.DataSource = originalData;
                    MessageBox.Show("Thay đổi đã bị hủy.");
                }

                // Thoát chế độ sửa
                isEditingMode = false;
                dataGridView2.ReadOnly = true;
                dataGridView2.KeyDown -= DataGridView2_KeyDown;
            }
        }

        private void SaveChangesToDatabase()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    string studentId = row.Cells["StudentID"].Value?.ToString();
                    string fullName = row.Cells["FullName"].Value?.ToString();
                    string phone = row.Cells["Phone"].Value?.ToString();
                    string email = row.Cells["Email"].Value?.ToString();
                    string address = row.Cells["Address"].Value?.ToString();

                    if (string.IsNullOrEmpty(studentId)) continue;

                    int rowsAffected = Data.SQLServer.CapNhatHocVien(studentId, fullName, phone, email, address);
                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show($"Cập nhật học viên {studentId} thất bại.");
                    }
                }

                LoadData(); // Làm mới dữ liệu từ CSDL
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }


        private void borderButton3_Click(object sender, EventArgs e)
        {
            iformationStudent iformationStudent = new iformationStudent();
            iformationStudent.Show();

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
                saveFileDialog.FileName = "DanhSachHocVien.xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = saveFileDialog.FileName;

                // Lấy dữ liệu từ DataGridView
                var dataTable = new DataTable("Students");

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

        private void borderButton2_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy nguồn dữ liệu từ DataGridView
                DataTable dt = dataGridView2.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để sắp xếp.");
                    return;
                }

                // Sắp xếp theo cột "Tên học viên", giả sử tên cột là "TenHocVien"
                DataView dv = dt.DefaultView;
                dv.Sort = "FullName DESC"; // Thay "TenHocVien" bằng tên cột đúng trong CSDL của bạn

                // Gán lại nguồn dữ liệu đã được sắp xếp
                dataGridView2.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sắp xếp: " + ex.Message);
            }
            
        }

        private void borderButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy nguồn dữ liệu từ DataGridView
                DataTable dt = dataGridView2.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để sắp xếp.");
                    return;
                }

                // Sắp xếp theo cột "Tên học viên", giả sử tên cột là "TenHocVien"
                DataView dv = dt.DefaultView;
                dv.Sort = "Address DESC"; // Thay "TenHocVien" bằng tên cột đúng trong CSDL của bạn

                // Gán lại nguồn dữ liệu đã được sắp xếp
                dataGridView2.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sắp xếp: " + ex.Message);
            }
        }

        private void Studentmanagement_Load_1(object sender, EventArgs e)
        {

        }

        private void borderButton5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
