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
    public partial class frmViewBooks : Form
    {
        public frmViewBooks()
        {
            InitializeComponent();
        }

       
        DataTable data;
        private void frmViewBooks_Load(object sender, EventArgs e)
        {
            data = clsBookInfos.GetAllBookInfos();
            dataGridView1.DataSource = data;
            cmbFilter.SelectedItem = "None";
            lblRecord.Text = data.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderText = "Book ID";
            dataGridView1.Columns[0].Width = 110;

            dataGridView1.Columns[1].HeaderText = "Book Name";
            dataGridView1.Columns[1].Width = 110;

            dataGridView1.Columns[2].HeaderText = "Book Author";
            dataGridView1.Columns[2].Width = 110;

            dataGridView1.Columns[3].HeaderText = "Book Publication";
            dataGridView1.Columns[3].Width = 150;

            dataGridView1.Columns[4].HeaderText = "Book Date";
            dataGridView1.Columns[4].Width = 110;

            dataGridView1.Columns[5].HeaderText = "Book Price";
            dataGridView1.Columns[5].Width = 90;

            dataGridView1.Columns[6].HeaderText = "Book Quantity";
            dataGridView1.Columns[6].Width = 90;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumne = "";
            switch (cmbFilter.SelectedItem)
            {
                case "Book Name":
                    FilterColumne = "bkName";
                    break;

                case "Book Author":
                    FilterColumne = "bkAuthor";
                    break;
                case "Book Publication":
                    FilterColumne = "bkPublication";
                    break;

                case "Book Price":
                    FilterColumne = "bkPrice";
                    break;

                case "Book Quantity":
                    FilterColumne = "bkQuantity";
                    break;
                default :
                    FilterColumne = "None";
                    break;
            }

            if (textBox1.Text.Trim() == "" || FilterColumne == "None")
            {
                data.DefaultView.RowFilter = "";
                lblRecord.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumne == "bkPrice" || FilterColumne == "bkQuantity")
                //in this case we deal with numbers not string.
                data.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumne, textBox1.Text.Trim());
            else
                data.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumne, textBox1.Text.Trim());

            lblRecord.Text = data.Rows.Count.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            clsBookInfos cls = clsBookInfos.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (cls != null)
            {
                ctrlBookAddUpdate1.bkName = cls.BookName;
                ctrlBookAddUpdate1.bkAuthor = cls.BookAuthor;
                ctrlBookAddUpdate1.bkPublication = cls.BookPublication;
                ctrlBookAddUpdate1.bkDate = cls.BookDate;
                ctrlBookAddUpdate1.bkPrice = cls.BookPrice.ToString();
                ctrlBookAddUpdate1.bkQuantity = cls.BookQuantity.ToString();
                ctrlBookAddUpdate1.FillTextBox();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctrlBookAddUpdate1.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string NameBook = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (clsBookInfos.DeleteBookInfo(NameBook))
            {
                MessageBox.Show($"Deleted Book {NameBook} Successfully !", "Deleted");
                ctrlBookAddUpdate1.Clear();
            }
            else
                MessageBox.Show($"Deleted ID {NameBook} Failed !", "Deleted");
            frmViewBooks_Load(null, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ctrlBookAddUpdate1.ValidateChildren())
            {
                ctrlBookAddUpdate1.FillBook();
                clsBookInfos clsBook = new clsBookInfos(ctrlBookAddUpdate1.bkName, ctrlBookAddUpdate1.bkAuthor,
                    ctrlBookAddUpdate1.bkPublication, ctrlBookAddUpdate1.bkDate, int.Parse(ctrlBookAddUpdate1.bkPrice),
                    int.Parse(ctrlBookAddUpdate1.bkQuantity));

                if (clsBook.Save())
                    MessageBox.Show("Book Updated Successfully !", "Updated");
                else
                    MessageBox.Show("Book Failed To Updated!", "Updated");
            }
            frmViewBooks_Load(null, e);
        }
    }
}
