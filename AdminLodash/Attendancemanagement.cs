using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bus.BUS;

namespace AdminLodash
{
    public partial class Attendancemanagement : Form
    {
        public Attendancemanagement()
        {
            InitializeComponent();
            acceptButton.Click += acceptButton_Click;

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(classComboBox.Text) || string.IsNullOrEmpty(studentComboBox.Text) ||
                !presentRadioButton.Checked && !absentRadioButton.Checked)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                int studentID = AttendanceBUS.GetStudentID(studentComboBox.Text);
                int classID = AttendanceBUS.GetClassID(classComboBox.Text);
                DateTime date = DateTime.Parse(dtpNgay.Text);
                string status = presentRadioButton.Checked ? "Present" : "Absent";

                if (AttendanceBUS.CheckAttendance(studentID, classID, date))
                {
                    MessageBox.Show("You have already checked attendance for this day.");
                }
                else
                {
                    if (AttendanceBUS.InsertAttendance(studentID, classID, date, status))
                    {
                        MessageBox.Show("Check attendance successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to check attendance.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadClasses();
            LoadStudents();
        }


        private void LoadClasses()
        {
            classComboBox.Items.Clear();

            DataTable dt = Data.SQLServer.laydulieutheotenbang("Classes");
            foreach (DataRow row in dt.Rows)
            {
                classComboBox.Items.Add(row["classID"].ToString());
            }
        }

        private void LoadStudents()
        {
            studentComboBox.Items.Clear();

            DataTable dt = Data.SQLServer.laydulieutheotenbang("Students");
            foreach (DataRow row in dt.Rows)
            {
                studentComboBox.Items.Add(row["studentID"].ToString());
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
          
        }
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void borderButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
