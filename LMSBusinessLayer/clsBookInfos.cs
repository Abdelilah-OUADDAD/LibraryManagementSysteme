using LMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMSBusinessLayer
{
    public class clsBookInfos
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookPublication { get; set; }
        public string BookDate { get; set; }
        public int BookPrice { get; set; }
        public int BookQuantity { get; set; }

        public enum enBook { enAddNew = 0, enUpdate = 1}

        public enBook Mode = enBook.enAddNew;
        public clsBookInfos()
        {
            BookName = "";
            BookAuthor = "";
            BookPublication = "";
            BookDate = "";
            BookPrice = -1;
            BookQuantity = -1;
            Mode = enBook.enAddNew;
        }

        public clsBookInfos(string bookName, string bookAuthor, string bookPublication, string bookDate
            , int bookPrice, int bookQuantity)
        {
            BookName = bookName;
            BookAuthor = bookAuthor;
            BookPublication = bookPublication;
            BookDate = bookDate;
            BookPrice = bookPrice;
            BookQuantity = bookQuantity;

            Mode = enBook.enUpdate;
        }

        public static clsBookInfos Find(int BookID)
        {
            string bookName = "", bookAuthor = "", bookPublication = "", bookDate = "";
            int bookPrice = -1, bookQuantity = -1;
            if (clsBookInfosData.GetBookInfosID(BookID ,ref bookName,ref bookAuthor, ref bookPublication ,ref bookDate,ref bookPrice 
                ,ref bookQuantity))
                return new clsBookInfos(bookName, bookAuthor, bookPublication, bookDate, bookPrice, bookQuantity);
            
            return null;
        }

        public static DataTable GetAllBookInfos()
        {
            return clsBookInfosData.GetAllBookInfos();
        }

        public static DataTable GetBookName()
        {
            return clsBookInfosData.GetBookName();
        }

        private int _AddBookInfosID()
        {
            return clsBookInfosData.AddBookInfosID(this.BookName,this.BookAuthor,this.BookPublication,this.BookDate,this.BookPrice,this.BookQuantity);
        }

        private bool _UpdateBookInfosID()
        {
            return clsBookInfosData.UpdateBookInfosID(this.BookName, this.BookAuthor, this.BookPublication, this.BookDate, this.BookPrice, this.BookQuantity);
        }

        public bool Save()
        {
            if (Mode == enBook.enAddNew)
            {
                this.BookID = _AddBookInfosID();
                if (this.BookID != -1)
                    return true;
                
            }
            else if(Mode == enBook.enUpdate)
            {
                if (_UpdateBookInfosID())
                    return true;
            }

            return false;
        }

        public static bool DeleteBookInfo(string BookName)
        {
            return clsBookInfosData.DeleteBookInfo(BookName);
        }

    }
}
