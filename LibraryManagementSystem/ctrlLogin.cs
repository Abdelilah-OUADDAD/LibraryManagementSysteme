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
    public partial class ctrlLogin : UserControl
    {
        private string _UserName = "Name" ;
        private string _Password = "Password";
        public string LoginName
        { 
            get 
            {
                return _UserName;
            }
            set 
            {
                _UserName = value;
            }
        }

        public string LoginPassword
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public ctrlLogin()
        {
            InitializeComponent();
            
        }
        
        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == LoginName)
                txtUserName.Clear();
            
        }

        private void ctrlLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = _UserName;
            txtPassword.Text = _Password;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == LoginPassword)
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
                
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, $"{LoginName} should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");

                LoginName = txtUserName.Text;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, $"{LoginName} should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");

                LoginPassword = txtPassword.Text;
            }
        }
    }
}
