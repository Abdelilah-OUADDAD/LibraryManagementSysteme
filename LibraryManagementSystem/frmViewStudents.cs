using LMSBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class frmViewStudents : Form
    {
        public frmViewStudents()
        {
            InitializeComponent();
        }


        DataTable data;
        private void frmViewStudents_Load(object sender, EventArgs e)
        {
            data = clsStudentInfos.GetAllStudentInfos();
            dataGridView1.DataSource = data;
            lblRecord.Text = data.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[0].Width = 110;

            dataGridView1.Columns[1].HeaderText = "Student Name";
            dataGridView1.Columns[1].Width = 110;

            dataGridView1.Columns[2].HeaderText = "Student Number";
            dataGridView1.Columns[2].Width = 110;

            dataGridView1.Columns[3].HeaderText = "Student Department";
            dataGridView1.Columns[3].Width = 110;

            dataGridView1.Columns[4].HeaderText = "Student Semester";
            dataGridView1.Columns[4].Width = 110;

            dataGridView1.Columns[5].HeaderText = "Student Contact";
            dataGridView1.Columns[5].Width = 110;

            dataGridView1.Columns[6].HeaderText = "Student Email";
            dataGridView1.Columns[6].Width = 110;

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cmbFilter.SelectedItem)
            {
                case "Student Name":
                    FilterColumn = "stName";
                    break;

                case "Student Number":
                    FilterColumn = "stNumber";
                    break;

                case "Student Department":
                    FilterColumn = "stDepartment";
                    break;

                case "Student Semester":
                    FilterColumn = "stSemester";
                    break;

                case "Student Contact":
                    FilterColumn = "stContact";
                    break;

                case "Student Email":
                    FilterColumn = "stEmail";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None" || txtFilter.Text == "")
            {
                data.DefaultView.RowFilter = "";
                lblRecord.Text = data.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "stNumber")
                data.DefaultView.RowFilter = string.Format( "[{0}] = {1}",FilterColumn,txtFilter.Text.Trim());
            else
                data.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecord.Text = data.Rows.Count.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctrlStudentAddUpdate1.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ctrlStudentAddUpdate1.ValidateChildren())
            {
                ctrlStudentAddUpdate1.FillStudent();
                clsStudentInfos clsStudent = new clsStudentInfos((int)dataGridView1.CurrentRow.Cells[0].Value,ctrlStudentAddUpdate1.stName, ctrlStudentAddUpdate1.stNumber,
                    ctrlStudentAddUpdate1.stDepartment, ctrlStudentAddUpdate1.stSemester, ctrlStudentAddUpdate1.stContact,
                    ctrlStudentAddUpdate1.stEmail);

                if (clsStudent.Save())
                    MessageBox.Show($"Student {(int)dataGridView1.CurrentRow.Cells[0].Value} Updated Successfully !", "Updated");
                else
                    MessageBox.Show($"Student {(int)dataGridView1.CurrentRow.Cells[0].Value} Failed To Updated!", "Updated");
            }
            frmViewStudents_Load(null, e);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            clsStudentInfos cls = clsStudentInfos.Find((int)dataGridView1.CurrentRow.Cells[0].Value);

            if (cls != null)
            {
                ctrlStudentAddUpdate1.stName = cls.StudentName;
                ctrlStudentAddUpdate1.stNumber = cls.StudentNumber;
                ctrlStudentAddUpdate1.stDepartment = cls.StudentDepartment;
                ctrlStudentAddUpdate1.stSemester = cls.StudentSemester;
                ctrlStudentAddUpdate1.stContact = cls.StudentContact;
                ctrlStudentAddUpdate1.stEmail = cls.StudentEmail;
                ctrlStudentAddUpdate1.FillTextBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int NameStudent = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (clsStudentInfos.DeleteStudentInfo(NameStudent))
            {
                MessageBox.Show($"Deleted Student ID {NameStudent} Successfully !", "Deleted");
                ctrlStudentAddUpdate1.Clear();
            }
            else
                MessageBox.Show($"Deleted Student ID {NameStudent} Failed !", "Deleted");
            frmViewStudents_Load(null, e);
        }
    }
}
