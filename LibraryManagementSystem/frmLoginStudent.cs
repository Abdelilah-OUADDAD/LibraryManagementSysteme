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

namespace LibraryManagementSystem
{
    public partial class frmLoginStudent : Form
    {
        public frmLoginStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsStudentInfos.LogStudent(ctrlLogin1.LoginName,ctrlLogin1.LoginPassword) != null)
            {
                clsGlobal.StudentName = ctrlLogin1.LoginName;
                clsGlobal.StudentPassword = ctrlLogin1.LoginPassword;
                this.Close();
                frmStudentDashboard frm = new frmStudentDashboard();
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("StudentName or StudentPassword Is incorrect !", "Error");
            }
        }
    }
}
