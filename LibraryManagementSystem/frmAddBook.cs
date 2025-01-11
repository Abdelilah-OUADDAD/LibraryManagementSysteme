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
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            
            if (this.ValidateChildren())
            {
                ctrlBookAddUpdate1.FillBook();

                clsBookInfos clsBook = new clsBookInfos();

                clsBook.BookName = ctrlBookAddUpdate1.bkName;
                clsBook.BookAuthor = ctrlBookAddUpdate1.bkAuthor;
                clsBook.BookPublication = ctrlBookAddUpdate1.bkPublication;
                clsBook.BookDate = ctrlBookAddUpdate1.bkDate;
                clsBook.BookPrice = int.Parse(ctrlBookAddUpdate1.bkPrice);
                clsBook.BookQuantity = int.Parse(ctrlBookAddUpdate1.bkQuantity);

                if (clsBook.Save())
                {
                    MessageBox.Show($"Book {clsBook.BookID} Add Successfully !");
                }
                else
                {
                    MessageBox.Show($"Failed to add book !");

                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctrlBookAddUpdate1.Clear();
        }

       
    }
}
