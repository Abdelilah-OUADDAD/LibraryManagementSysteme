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
    public partial class frmBookSearch : Form
    {
        public frmBookSearch()
        {
            InitializeComponent();
        }

        DataTable data;
        private void frmBookSearch_Load(object sender, EventArgs e)
        {
            data = clsBookInfos.GetAllBookInfos();
            dataGridView1.DataSource = data;
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
            if (textBox1.Text.Trim() == "")
            {
                data.DefaultView.RowFilter = "";
                lblRecord.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            else 
                data.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", "bkName", textBox1.Text.Trim());

            lblRecord.Text = data.Rows.Count.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
