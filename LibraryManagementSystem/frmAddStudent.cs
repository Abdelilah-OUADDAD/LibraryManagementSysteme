using LMSBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (this.ValidateChildren())
            {
                ctrlStudentAddUpdate1.FillStudent();
                clsStudentInfos clsStudent = new clsStudentInfos();
                clsStudent.StudentName = ctrlStudentAddUpdate1.stName;
                clsStudent.StudentNumber = ctrlStudentAddUpdate1.stNumber;
                clsStudent.StudentDepartment = ctrlStudentAddUpdate1.stDepartment;
                clsStudent.StudentSemester = ctrlStudentAddUpdate1.stSemester;
                clsStudent.StudentContact = ctrlStudentAddUpdate1.stContact;
                clsStudent.StudentEmail = ctrlStudentAddUpdate1.stEmail;

                if (clsStudent.Save())
                {
                    MessageBox.Show($"Student {clsStudent.StudentID} Add Successfully !");
                }
                else
                {
                    MessageBox.Show($"Failed to add book !");
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctrlStudentAddUpdate1.Clear();
        }

       
    }
}
