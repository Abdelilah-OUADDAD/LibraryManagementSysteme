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
    public partial class frmStudentDashboard : Form
    {
        public frmStudentDashboard()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHomePage frm = new frmHomePage();
            frm.ShowDialog();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueBook frm = new frmIssueBook();
            frm.ShowDialog();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook frm = new frmReturnBook();
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
