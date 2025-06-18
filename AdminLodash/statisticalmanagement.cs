using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Data;

namespace AdminLodash
{
    public partial class statisticalmanagement : Form
    {
        public statisticalmanagement()
        {
            InitializeComponent();
        }

        private void statisticalmanagement_Load(object sender, EventArgs e)
        {

        }

        private void LoadThongKeHocPhi()
        {
            string query = @"SELECT ClassID, 
                    SUM(AmountDue) AS TongHocPhi, 
                    SUM(PaidAmount) AS DaThu, 
                    SUM(AmountDue - PaidAmount) AS ConNo 
                    FROM tuition_fees 
                    GROUP BY ClassID";

            DataTable dt = SQLServer.ExecuteQuery(query);

            // Hiển thị trên dataGridView1
            dataGridView1.DataSource = dt;

            // Hiển thị trên chart1
            chart1.Series.Clear();
            var series = chart1.Series.Add("Doanh Thu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (DataRow row in dt.Rows)
            {
                string className = row["ClassID"].ToString();
                decimal tongHocPhi = Convert.ToDecimal(row["TongHocPhi"]);
                series.Points.AddXY(className, tongHocPhi);
            }
        }
        private void borderButton1_Click(object sender, EventArgs e)
        {
         
            LoadThongKeHocPhi();
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBorder1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void borderButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi procedure không lọc theo thời gian
                string query = "CALL ThongKeDoanhThuHocPhi(NULL, NULL);";

                DataTable dt = Data.SQLServer.ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu để hiển thị.");
                    return;
                }

                // Hiển thị dữ liệu trên dataGridView1
                dataGridView1.DataSource = dt; // <-- THÊM DÒNG NÀY

                // Xóa dữ liệu cũ trên chart
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Tạo ChartArea và Series mới
                ChartArea chartArea = new ChartArea();
                Series series = new Series();
                Legend legend = new Legend();

                chart1.ChartAreas.Add(chartArea);
                chart1.Series.Add(series);
                chart1.Legends.Add(legend);

                // Thiết lập loại biểu đồ
                series.ChartType = SeriesChartType.Column; // Có thể dùng Pie, Bar, Line,...
                series.IsValueShownAsLabel = true;

                // Đổ dữ liệu vào chart
                foreach (DataRow row in dt.Rows)
                {
                    string classId = row["ClassID"].ToString();
                    decimal tongDaThu = Convert.ToDecimal(row["TongDaThu"]);
                    series.Points.AddXY(classId, tongDaThu);
                }

                // Cấu hình tiêu đề và nhãn
                chart1.Titles.Clear();
                chart1.Titles.Add("Biểu đồ doanh thu học phí");
                chartArea.AxisX.Title = "Lớp học";
                chartArea.AxisY.Title = "Số tiền đã thu (VNĐ)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    }
}
