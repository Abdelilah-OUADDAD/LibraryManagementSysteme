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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBook frm = new frmAddBook();
            frm.ShowDialog();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStudent frm = new frmAddStudent();
            frm.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHomePage frm = new frmHomePage();
            frm.ShowDialog();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewBooks frm = new frmViewBooks();
            frm.ShowDialog();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewStudents frm = new frmViewStudents();
            frm.ShowDialog();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueBook frm = new frmIssueBook();
            frm.ShowDialog();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook frm = new frmReturnBook();
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompleteBookDetails frm = new frmCompleteBookDetails();
            frm.ShowDialog();
        }
    }
}
