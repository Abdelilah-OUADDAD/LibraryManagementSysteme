using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagementSystem
{

    public partial class ctrlBookAddUpdate : UserControl
    {
        public string bkName { get; set; }

        public string bkAuthor { get; set; }
        public string bkPublication { get; set; }
        public string bkDate { get; set; }
        public string bkPrice { get; set; }
        public string bkQuantity { get; set; }
        public ctrlBookAddUpdate()
        {
            InitializeComponent();
        }

        public void FillBook()
        {
            bkName = txtBookName.Text;
            bkAuthor = txtBookAuthor.Text;
            bkPublication = txtBookPublication.Text;
            bkDate = dateTimePicker1.Value.ToString();
            bkPrice = txtBookPrice.Text;
            bkQuantity = txtQuantity.Text;
        }

        public void FillTextBox()
        {
            txtBookName.Text = bkName ;
            txtBookAuthor.Text = bkAuthor ;
            txtBookPublication.Text = bkPublication;
            dateTimePicker1.Text =  bkDate;
            txtBookPrice.Text = bkPrice;
            txtQuantity.Text = bkQuantity;
        }

        public void Clear()
        {
            txtBookName.Clear();
            txtBookAuthor.Clear();
            txtBookPublication.Clear();
            txtBookPrice.Clear();
            txtQuantity.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void txtBookName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                e.Cancel = true;
                txtBookName.Focus();
                errorProvider1.SetError(txtBookName, $"Name book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBookName, "");
            }
        }

        private void txtBookAuthor_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookAuthor.Text))
            {
                e.Cancel = true;
                txtBookAuthor.Focus();
                errorProvider1.SetError(txtBookAuthor, $"Book Author book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBookAuthor, "");
            }
        }

        private void txtBookPublication_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookPublication.Text))
            {
                e.Cancel = true;
                txtBookPublication.Focus();
                errorProvider1.SetError(txtBookPublication, $"Book Publication book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBookPublication, "");
            }
        }

        private void txtBookPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookPrice.Text))
            {
                e.Cancel = true;
                txtBookPrice.Focus();
                errorProvider1.SetError(txtBookPrice, $"Price book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBookPrice, "");
            }
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                e.Cancel = true;
                txtQuantity.Focus();
                errorProvider1.SetError(txtQuantity, $"Quantity book should be have a value.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtQuantity, "");
            }
        }

        private void txtBookPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
