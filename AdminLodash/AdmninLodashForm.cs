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
    public partial class AdmninLodashForm : Form
    {
        public AdmninLodashForm()
        {
            InitializeComponent();
            customizeDesgn();
        }

        private void customizeDesgn()
        {
            panel4.Visible = false;

        }
        private void HideSubMenu()
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
        }
        private void ShowMenu( Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowMenu(panel4);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdmninLodashForm_Load(object sender, EventArgs e)
        {

        }
        private Form activeForm = null;
        private void openchidlform(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm); // Assuming you have a panelMain
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // panel 4 là chứ nút phụ
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void borderButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
