using System;
using System.Data;
using System.Windows.Forms;
using Bus;
using Data;
using static Bus.BUS;

namespace AdminLodash
{
    public partial class viewclasslistmanagement : Form
    {
        internal Timer fadeInTimer;
        public viewclasslistmanagement()
        {

            InitializeComponent();

            this.Load += viewclasslistmanagement_Load;

            // Gán sự kiện nếu chưa làm ở Designer
            if (cboLopHoc != null)
            {
                cboLopHoc.SelectedIndexChanged += cboLopHoc_SelectedIndexChanged;
            }

            // Đăng ký sự kiện click vào lớp học
            dataGridViewLopHoc.SelectionChanged += dataGridViewLopHoc_SelectionChanged;
            dataGridViewLopHoc.SelectionChanged -= dataGridViewLopHoc_SelectionChanged;

        }

        private void viewclasslistmanagement_Load(object sender, EventArgs e)
        {


            
                // Lấy danh sách lớp học đổ vào ComboBox và DataGridView
                DataTable dtClasses = Bus.BUS.ClassBUS.LayDanhLopHoc();

                if (dtClasses.Rows.Count > 0)
                {
                    // Đổ dữ liệu vào ComboBox
                    cboLopHoc.DataSource = dtClasses;
                    cboLopHoc.DisplayMember = "ClassName"; // Tên lớp hiển thị trên ComboBox
                    cboLopHoc.ValueMember = "ClassID";     // Giá trị thật là ClassID

                    // Đổ dữ liệu vào DataGridView lớp học
                    dataGridViewLopHoc.DataSource = dtClasses;
                }
                else
                {
                    MessageBox.Show("Không có lớp học nào.");
                    dataGridViewLopHoc.DataSource = null;
                }
            // Load danh sách lớp học
            var dt = ClassBUS.LayDanhLopHoc();
            dataGridViewLopHoc.DataSource = dt;

            // Kiểm tra và thêm cột hành động nếu chưa có
            if (!dataGridViewLopHoc.Columns.Contains("colXoa") && !dataGridViewLopHoc.Columns.Contains("colSua"))
            {
                var colXoa = new DataGridViewButtonColumn
                {
                    Name = "colXoa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewLopHoc.Columns.Add(colXoa);

                var colSua = new DataGridViewButtonColumn
                {
                    Name = "colSua",
                    Text = "Sửa",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewLopHoc.Columns.Add(colSua);
            }

            // Load danh sách học viên vào cboHocVien
            DataTable dtStudents = Data.SQLServer.laydulieutheotenbang("Students");
            coboHV.DataSource = dtStudents;
            coboHV.DisplayMember = "FullName"; // Hiển thị tên học viên
            coboHV.ValueMember = "StudentID";  // Giá trị thật là StudentID

            // Load danh sách lớp học vào cboLopHoc
            
            cboClass.DataSource = dtClasses;
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassID";

        }
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (cboLopHoc.SelectedItem != null)
            {
               
                    // Lấy dòng hiện tại trong ComboBox (giả sử bạn đổ DataTable vào DataSource)
                    DataRowView selectedRow = cboLopHoc.SelectedItem as DataRowView;

                    // Lấy ClassID từ cột "ClassID"
                    string selectedClassID = selectedRow["ClassID"].ToString();

                    // Gọi hàm từ BUS để lấy danh sách học viên theo lớp
                    DataTable dtStudents = Bus.BUS.ClassBUS.LayDanhSachHocVienTheoLop(selectedClassID);

                    // Kiểm tra dữ liệu trả về
                    if (dtStudents != null && dtStudents.Rows.Count > 0)
                    {
                        // Hiện danh sách học viên trên DataGridView
                        dataGridViewLopHoc.DataSource = dtStudents;
                    }
                    else
                    {
                        // Không có học viên nào
                        dataGridViewLopHoc.DataSource = null;
                        MessageBox.Show("Lớp học này chưa có học viên nào đăng ký.");
                    }
            }
                
        }
        
        private void dataGridViewLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLopHoc.SelectedRows.Count > 0)
            {
                // Lấy ClassID từ dòng được chọn
                string selectedClassID = dataGridViewLopHoc.SelectedRows[0].Cells["ClassID"].Value.ToString();

                try
                {
                    // Gọi hàm lấy danh sách học viên theo lớp
                    DataTable dtStudents = Bus.BUS.ClassBUS.LayDanhSachHocVienTheoLop(selectedClassID);

                    if (dtStudents != null && dtStudents.Rows.Count > 0)
                    {
                        // Hiện danh sách học viên
                        dataGridViewLopHoc.DataSource = dtStudents;
                    }
                    else
                    {
                        // Không có học viên nào
                        dataGridViewLopHoc.DataSource = null;
                        MessageBox.Show("Lớp học này chưa có học viên nào.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách học viên: " + ex.Message);
                }
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            // Lấy mã học viên và mã lớp học được chọn
            string studentId = coboHV.SelectedValue?.ToString();
            string classId = cboClass.SelectedValue?.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(classId))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ học viên và lớp học.");
                return;
            }

            // Kiểm tra xem học viên đã đăng ký lớp này chưa
            if (EnrollmentBUS.KiemTraDaDangKy(studentId, classId))
            {
                MessageBox.Show("Học viên này đã đăng ký lớp này rồi.");
                return;
            }

            // Kiểm tra số học viên tối đa của lớp
            int soLuongHienTai = ClassBUS.LayDanhSachHocVienTheoLop(classId).Rows.Count;
            int maxStudent = ClassBUS.GetMaxStudentFromClass(classId);

            if (soLuongHienTai >= maxStudent)
            {
                MessageBox.Show($"Lớp học này đã đủ {maxStudent} học viên. Không thể thêm nữa.");
                return;
            }

            // Tạo mã đăng ký tự động
            int enrollmentId = EnrollmentBUS.TaoMaDangKyTuDong(); // trả về DK001, DK002,...

            // Thêm bản ghi vào bảng Enrollments
            int ketQua = EnrollmentBUS.ThemDangKy(
                studentId,
                classId,
                DateTime.Now, // Ngày đăng ký
                "1"           // Trạng thái: hoạt động
            );

            if (ketQua > 0)
            {
                MessageBox.Show("Gán học viên vào lớp thành công!");
                // Reload lại danh sách học viên theo lớp (nếu có DataGridView hiển thị)
                dataGridViewLopHoc.DataSource = ClassBUS.LayDanhSachHocVienTheoLop(classId);
            }
            else
            {
                MessageBox.Show("Gán thất bại. Vui lòng thử lại.");
            }
        }

        private void coboHV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}