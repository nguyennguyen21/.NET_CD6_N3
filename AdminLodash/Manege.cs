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
        }

        private void LoadForm(Form formCon)
        {
            // Kiểm tra xem form này đã tồn tại chưa
            foreach (Control control in panel6.Controls)
            {
                if (control.GetType() == formCon.GetType())
                {
                    control.BringToFront();
                    return;
                }
            }

            // Nếu chưa có thì thêm mới
            foreach (Control control in panel6.Controls)
            {
                if (control is Form)
                {
                    control.Dispose();
                }
            }

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panel6.Controls.Add(formCon);
            panel6.Tag = formCon;
            formCon.BringToFront();
            formCon.Show();
        }
        private void Manege_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm(new classmanagement());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadForm(new coursemanagement());
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm(new viewclasslistmanagement());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(new Attendancemanagement());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new Studentmanagement());
        }

        private void borderButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
