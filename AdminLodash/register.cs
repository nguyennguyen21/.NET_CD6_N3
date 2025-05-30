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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        
       
        private void textBox1_Load(object sender, EventArgs e)
        {
            
        }

        private void panelRadius1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void togglecontrol1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void togglecontrol1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            Login register = new Login();
            register.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void borderButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
