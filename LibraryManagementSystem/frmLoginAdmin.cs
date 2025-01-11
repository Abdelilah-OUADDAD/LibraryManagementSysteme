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
    public partial class frmLoginAdmin : Form
    {
        public frmLoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsLogin.Find(ctrlLogin1.LoginName, ctrlLogin1.LoginPassword) != null)
            {
                clsGlobal.UserName = ctrlLogin1.LoginName;
                clsGlobal.Password = ctrlLogin1.LoginPassword;

                this.Close();
                frmDashboard frm = new frmDashboard();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("UserName or Password Is incorrect !","Error");
            }
        }
    }
}
