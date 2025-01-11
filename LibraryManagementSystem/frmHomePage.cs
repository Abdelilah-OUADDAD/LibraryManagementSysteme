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
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginAdmin frm = new frmLoginAdmin();
            frm.ShowDialog();
        }

        private void studentLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginStudent frm = new frmLoginStudent();
            frm.ShowDialog();
        }

        private void bookSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookSearch frm = new frmBookSearch();
            frm.ShowDialog();
        }
    }
}
