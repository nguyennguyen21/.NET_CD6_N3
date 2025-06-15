using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLodash
{
    public partial class Manege : Form
    {
        public Manege()
        {
            InitializeComponent();
            customizDesing();

        }

        private void LoadForm(Form formCon)
        {
       
            // Kiểm tra xem form này đã tồn tại chưa
            foreach (Control control in panel3.Controls)
            {
                if (control.GetType() == formCon.GetType())
                {
                    control.BringToFront();
                    return;
                }
            }

            // Nếu chưa có thì thêm mới
            foreach (Control control in panel3.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                }
            }

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panel3.Controls.Add(formCon);
            panel3.Tag = formCon;
            formCon.BringToFront();

            // Thiết lập Opacity ban đầu là 0
            formCon.Opacity = 0;
            formCon.Show();

            // Tạo Timer để thực hiện hiệu ứng fade in
            Timer fadeInTimer = new Timer();
            fadeInTimer.Interval = 20; // Tốc độ cập nhật (miligiây)

            fadeInTimer.Tick += (s, args) =>
            {
                if (formCon.Opacity < 1.0)
                {
                    formCon.Opacity += 0.05; // Tăng độ sáng
                }
                else
                {
                    fadeInTimer.Stop(); // Dừng khi đạt Opacity tối đa
                    fadeInTimer.Dispose(); // Giải phóng tài nguyên
                }
            };

            fadeInTimer.Start();
        
        }



        private Timer fadeInTimer;
        private void Manege_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Bắt đầu từ trong suốt

            fadeInTimer = new Timer();
            fadeInTimer.Interval = 20; // Tốc độ hiệu ứng (miligiây)

            fadeInTimer.Tick += (s, args) =>
            {
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.05; // Tăng độ rõ
                }
                else
                {
                    fadeInTimer.Stop(); // Dừng khi đầy độ sáng
                    fadeInTimer.Dispose(); // Giải phóng tài nguyên
                }
            };

            fadeInTimer.Start();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm(new classmanagement());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadForm(new coursemanagement());
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new TeacherManagement());
            hideSubMenu();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm(new viewclasslistmanagement());
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(new Attendancemanagement());
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new Studentmanagement());
            hideSubMenu();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void customizDesing()
        {
            panel4.Visible = false;
            panel6.Visible = false;
           
            
        }

        private void hideSubMenu()
        {
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
                subMenu.AutoSize = true;
            }
            else
            {
                subMenu.Visible = false;
                subMenu.Size = new Size(0, 0);
            }
        }
        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadForm(new TuitionfeesManegement());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
