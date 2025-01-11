using LibraryManagementSystem.GlobalClass;
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
    public partial class frmIssueBook : Form
    {
        public frmIssueBook()
        {
            InitializeComponent();
        }

        private void ValidationText(TextBox textBox,string message ,CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, $"Student {message} should be have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }
        private void txtStName_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStName,"Name",e);
        }

        private void txtStDepartment_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStDepartment,"Department", e);
        }

        private void txtStSemester_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStSemester, "Semester", e);
        }

        private void txtStContact_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStContact,"Contact", e);
        }

        private void txtStEmail_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStEmail,"Email", e);
            bool isYes = clsValidation.ValidateEmail(txtStEmail.Text);
            if (!isYes)
            {
                e.Cancel = true;
                txtStEmail.Focus();
                errorProvider1.SetError(txtStEmail, "Student Email should be have a '@gmail.com'");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtStEmail, "");
            }
        }

        

        private void txtStNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidationText(txtStNumber,"Number", e);
        }

        private void txtStNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtStContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //txtStName.Clear();
            //txtStDepartment.Clear();
            //txtStSemester.Clear();
            //txtStContact.Clear();
            //txtStEmail.Clear();
            txtStNumber.Clear();
           // cmbBookName.SelectedItem = "None";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsIssueBooks.FindIssueBooksNumberReturn(txtStNumber.Text).Rows.Count < 3)
            {
                clsStudentInfos cls = clsStudentInfos.FindStudentNumber(txtStNumber.Text);

                if (cls != null)
                {
                    txtStName.Text = cls.StudentName;
                    txtStDepartment.Text = cls.StudentDepartment;
                    txtStSemester.Text = cls.StudentSemester;
                    txtStContact.Text = cls.StudentContact;
                    txtStEmail.Text = cls.StudentEmail;
                    //cmbBookName.Text = cls.BookName;
                }
            }
            else
            {
                MessageBox.Show("Student already Issued Three Books","Information");
                btnIssueBook.Enabled = false;
            }
        }

        private void FillCombo()
        {
            cmbBookName.Items.Add("None");
            cmbBookName.SelectedItem = "None";
            DataTable dtBookName = clsBookInfos.GetBookName();
            foreach (DataRow row in dtBookName.Rows)
            {
                cmbBookName.Items.Add(row[0]);
            }
            
        }

        private void frmIssueBook_Load(object sender, EventArgs e)
        {
            FillCombo();
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (clsIssueBooks.FindIssueBooksNumberReturn(txtStNumber.Text).Rows.Count < 3)
                {
                    if (clsIssueBooks.IsExistBookName(txtStNumber.Text, cmbBookName.SelectedItem.ToString()))
                    {
                        MessageBox.Show($"Student already have this book {cmbBookName.SelectedItem.ToString()} Choose Another one", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    clsIssueBooks cls = new clsIssueBooks();
                    cls.StudentName = txtStName.Text;
                    cls.StudentNumber = txtStNumber.Text;
                    cls.StudentDepartment = txtStDepartment.Text;
                    cls.StudentSemester = txtStSemester.Text;
                    cls.StudentContact = txtStContact.Text;
                    cls.StudentEmail = txtStEmail.Text;
                    cls.BookName = cmbBookName.SelectedItem.ToString();
                    cls.BookIssueDate = dateTimePicker1.Value.ToString();
                    if (cls.Save())
                    {
                        MessageBox.Show($"Issue Book {cls.StudentID} Successfully  !");
                    }
                    else
                        MessageBox.Show($"Issue Book Failed !");
                }
                else
                {
                    MessageBox.Show("Student already Issued Three Books", "Information");
                    btnIssueBook.Enabled = false;
                }
            }
        }

        private void txtStNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtStNumber.Text == "")
            {
                txtStName.Clear();
                txtStDepartment.Clear();
                txtStSemester.Clear();
                txtStContact.Clear();
                txtStEmail.Clear();
                txtStNumber.Clear();
                cmbBookName.SelectedItem = "None";
            }
        }
    }
}
