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
    public partial class frmReturnBook : Form
    {
        public frmReturnBook()
        {
            InitializeComponent();
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
        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            FillCombo();
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable data = clsIssueBooks.FindStudentDoesNotReturnBook(txtStNumber.Text);
            if (data.Rows.Count != 0)
            {

                dataGridView1.DataSource = data;

                dataGridView1.Columns[0].HeaderText = "Student Name";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Student Department";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Student Semester";
                dataGridView1.Columns[2].Width = 110;

                dataGridView1.Columns[3].HeaderText = "Student Contact";
                dataGridView1.Columns[3].Width = 110;

                dataGridView1.Columns[4].HeaderText = "Student Email";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "Book Name";
                dataGridView1.Columns[5].Width = 110;

                dataGridView1.Columns[6].HeaderText = "Book Issue Date";
                dataGridView1.Columns[6].Width = 110;

                dataGridView1.Columns[7].HeaderText = "Book Return Date";
                dataGridView1.Columns[7].Width = 110;


            }
            else
                dataGridView1.DataSource = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStNumber.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStNumber.Clear();
            cmbBookName.SelectedItem = "None";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (clsIssueBooks.IsExistBookName(txtStNumber.Text,cmbBookName.SelectedItem.ToString()))
            {
                clsIssueBooks cls = new clsIssueBooks(txtStNumber.Text,dateTimePicker1.Value.ToString(),cmbBookName.SelectedItem.ToString());
                if(cls != null)
                {
                    if (cls.Save())
                    {
                        MessageBox.Show($"Book {cmbBookName.SelectedItem.ToString()} is returned to Library Successfully !","Information"
                            ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        btnSearch_Click(null, null);
                    }
                }
            }
            else
            {
                MessageBox.Show($"{cmbBookName.SelectedItem.ToString()} Book already returned or not Exist  ", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
