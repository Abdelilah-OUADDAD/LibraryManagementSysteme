using LibraryManagementSystem.GlobalClass;
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
    public partial class ctrlStudentAddUpdate : UserControl
    {
        public string stName { get ;  set ;}
        
        public string stNumber { get; set; }
        public string stDepartment { get; set; }
        public string stSemester { get; set; }
        public string stContact { get; set; }
        public string stEmail { get; set; }
        public ctrlStudentAddUpdate()
        {
            InitializeComponent();
        }

        public void FillStudent()
        {
            stName = txtName.Text;
            stNumber = txtNumber.Text;
            stDepartment = txtDepartment.Text;
            stSemester = txtSemester.Text;
            stContact = txtContact.Text;
            stEmail = txtEmail.Text;
        }

        public void FillTextBox()
        {
            txtName.Text =stName ;
            txtNumber.Text = stNumber;
            txtDepartment.Text = stDepartment;
            txtSemester.Text = stSemester;
            txtContact.Text = stContact;
            txtEmail.Text = stEmail;   
        }

        public void Clear()
        {
            txtName.Clear();
            txtNumber.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider1.SetError(txtName, $"Name book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                e.Cancel = true;
                txtNumber.Focus();
                errorProvider1.SetError(txtNumber, $"Number book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNumber, "");
            }
        }

        private void txtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                e.Cancel = true;
                txtDepartment.Focus();
                errorProvider1.SetError(txtDepartment, $"Department book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDepartment, "");
            }
        }

        private void txtSemester_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSemester.Text))
            {
                e.Cancel = true;
                txtSemester.Focus();
                errorProvider1.SetError(txtSemester, $"Semester book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSemester, "");
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContact.Text))
            {
                e.Cancel = true;
                txtContact.Focus();
                errorProvider1.SetError(txtContact, $"Contact book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtContact, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, $"Email book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }

            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, $"Email book should be have a ' @gmail.com '.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
