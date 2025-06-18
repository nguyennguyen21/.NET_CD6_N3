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
            // Xóa tất cả form cũ khỏi panel3
            foreach (Control control in panel3.Controls)
            {
                if (control is Form)
                {
                    panel3.Controls.Remove(control);
                }
            }

            // Tạo instance mới của form
            var newForm = (Form)Activator.CreateInstance(formCon.GetType());

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            panel3.Controls.Add(newForm);
            panel3.Tag = newForm;
            newForm.Show();
            newForm.BringToFront();

            // Hiệu ứng fade in
            newForm.Opacity = 0;
            Timer fadeInTimer = new Timer();
            fadeInTimer.Interval = 20;

            fadeInTimer.Tick += (s, args) =>
            {
                if (newForm.Opacity < 1.0)
                {
                    newForm.Opacity += 0.05;
                }
                else
                {
                    fadeInTimer.Stop();
                    fadeInTimer.Dispose();
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
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
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
            panel7.Visible = false;
            panel6.Visible = false;
           
            
        }

        private void hideSubMenu()
        {
            if (panel7.Visible == true)
                panel7.Visible = false;
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
          
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            LoadForm(new TuitionfeesManegement());
            
        }

        private void panel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }

        private void panelRadius1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Studentmanagement());
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadForm(new TeacherManagement());
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Attendancemanagement());
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadForm(new viewclasslistmanagement());
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadForm(new coursemanagement());
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadForm(new classmanagement());
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            LoadForm(new TestManagement());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadForm(new statisticalmanagement());
        }
    }
}
