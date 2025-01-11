using LMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBusinessLayer
{
    public class clsIssueBooks
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentSemester { get; set; }
        public string StudentContact { get; set; }
        public string StudentEmail { get; set; }
        public string BookName { get; set; }
        public string BookIssueDate { get; set; }
        public string BookReturnDate { get; set; }

        enum enIssueBook { enAddNew = 0, enUpdate = 1 }

        enIssueBook Mode;
        public clsIssueBooks()
        {

            StudentName = "";
            StudentNumber = "";
            StudentDepartment = "";
            StudentSemester = "";
            StudentContact = "";
            StudentEmail = "";
            BookName = "";
            BookIssueDate = "";
            BookReturnDate = "";

            Mode = enIssueBook.enAddNew;
        }

        public clsIssueBooks(int studentID, string studentName, string studentNumber, string studentDepartment,
             string studentSemester, string studentContact, string studentEmail, string bookName, string bookIssueDate, string bookReturnDate)
        {
            StudentID = studentID;
            StudentName = studentName;
            StudentNumber = studentNumber;
            StudentDepartment = studentDepartment;
            StudentSemester = studentSemester;
            StudentContact = studentContact;
            StudentEmail = studentEmail;
            BookName = bookName;
            BookIssueDate = bookIssueDate;
            BookReturnDate = bookReturnDate;

            Mode = enIssueBook.enUpdate;
        }

        public clsIssueBooks( string studentNumber, string bookReturnDate,string bookName)
        {
           
            StudentNumber = studentNumber;
            BookReturnDate = bookReturnDate;
            BookName = bookName;
            Mode = enIssueBook.enUpdate;
        }

        public static clsIssueBooks Find(int studentID)
        {
            string studentName = "", studentNumber = "", studentDepartment = "", studentSemester = "", studentContact = "",
                studentEmail = "" , bookName = "", bookIssueDate = "", bookReturnDate = "";
            if (clsIssueBooksData.GetIssueBookID(studentID, ref studentName, ref studentNumber, ref studentDepartment, ref studentSemester, ref studentContact,
                ref studentEmail, ref bookName, ref bookIssueDate, ref bookReturnDate))
            {
                return new clsIssueBooks(studentID,studentName, studentNumber, studentDepartment, studentSemester, studentContact,
                 studentEmail, bookName, bookIssueDate, bookReturnDate);
            }
            return null;
        }

        

        public static DataTable GetAllIssueBooks()
        {
           return clsIssueBooksData.GetAllIssueBooks();
        }

        public static DataTable FindIssueBooksNumberReturn(string StudentNumber)
        {
            return clsIssueBooksData.GetIssueBooksNumberReturn(StudentNumber);
        }

        public static DataTable FindStudentDoesNotReturnBook(string StudentNumber)
        {
            return clsIssueBooksData.GetStudentDoesNotReturnBook(StudentNumber);
        }

        private int _AddIssueBookID()
        {
            return clsIssueBooksData.AddIssueBookID(StudentName, StudentNumber, StudentDepartment, StudentSemester, StudentContact,
                 StudentEmail, BookName, BookIssueDate, BookReturnDate);
        }

        private bool _UpdateIssueBookID()
        {
            return clsIssueBooksData.UpdateIssueBookID( StudentNumber,BookReturnDate,BookName);
        }

        public bool Save()
        {
            if (Mode == enIssueBook.enAddNew)
            {
                this.StudentID = _AddIssueBookID();
                if (this.StudentID != -1)
                    return true;
            }
            else if (Mode == enIssueBook.enUpdate)
            {
                if (_UpdateIssueBookID())
                    return true;
            }
            return false;
        }

        public static bool DeleteIssueBook(int ID)
        {
            return clsIssueBooksData.DeleteIssueBook(ID);
        }

        public static bool IsExistBookName(string StudentNumber, string BookName)
        {
            return clsIssueBooksData.IsExistBookName(StudentNumber, BookName);
        }

        public static DataTable GetAllStudentReturnBook()
        {
            return clsIssueBooksData.GetAllStudentReturnBook();
        }

        public static DataTable GetAllStudentDoesNotReturnBook()
        {
            return clsIssueBooksData.GetAllStudentDoesNotReturnBook();
        }

    }
}
