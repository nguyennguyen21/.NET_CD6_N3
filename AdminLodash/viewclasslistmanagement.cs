using System;
using System.Data;
using System.Windows.Forms;
using Bus;
using Data;

namespace AdminLodash
{
    public partial class viewclasslistmanagement : Form
    {
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
            
        }

        private void viewclasslistmanagement_Load(object sender, EventArgs e)
        {
            string selectedClassID = "L003"; // Mã lớp cần lấy học viên

            try
            {
                // 1. Lấy danh sách lớp học đổ vào ComboBox hoặc DataGridView lớp học
                DataTable dtClasses = Bus.BUS.ClassBUS.LayDanhLopHoc();
                if (dtClasses.Rows.Count > 0)
                {
                    dataGridViewLopHoc.DataSource = dtClasses;
                }

                // 2. Lấy danh sách học viên của lớp có mã "L003"
                DataTable dtStudents = Bus.BUS.ClassBUS.LayDanhSachHocVienTheoLop(selectedClassID);
                if (dtStudents.Rows.Count > 0)
                {
                    dataGridViewLopHoc.DataSource = dtStudents;
                }
                else
                {
                    dataGridViewLopHoc.DataSource = null;
                    MessageBox.Show("Lớp học này chưa có học viên nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (cboLopHoc.SelectedItem != null)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách học viên: " + ex.Message);
                }
            }
        }
        private void dataGridViewLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLopHoc.SelectedRows.Count > 0)
            {
                // Lấy ClassID từ dòng được chọn
                string selectedClassID = dataGridViewLopHoc.SelectedRows[0].Cells["ClassID"].Value.ToString();

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
                    
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}