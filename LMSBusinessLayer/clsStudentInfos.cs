using LMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBusinessLayer
{
    public class clsStudentInfos
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentSemester { get; set; }
        public string StudentContact { get; set; }
        public string StudentEmail { get; set; }

        enum enIssueBook { enAddNew = 0, enUpdate = 1 }

        enIssueBook Mode;
        public clsStudentInfos()
        {

            StudentName = "";
            StudentNumber = "";
            StudentDepartment = "";
            StudentSemester = "";
            StudentContact = "";
            StudentEmail = "";

            Mode = enIssueBook.enAddNew;
        }

        public clsStudentInfos(int studentID, string studentName, string studentNumber, string studentDepartment,
             string studentSemester, string studentContact, string studentEmail)
        {
            StudentID = studentID;
            StudentName = studentName;
            StudentNumber = studentNumber;
            StudentDepartment = studentDepartment;
            StudentSemester = studentSemester;
            StudentContact = studentContact;
            StudentEmail = studentEmail;

            Mode = enIssueBook.enUpdate;
        }

        public clsStudentInfos( string studentName, string studentNumber)
        {
            StudentName = studentName;
            StudentNumber = studentNumber;

            Mode = enIssueBook.enUpdate;
        }

        public static clsStudentInfos Find(int studentID)
        {
            string studentName = "", studentNumber = "", studentDepartment = "", studentSemester = "", studentContact = "",
                studentEmail = "";
            if (clsStudentInfosData.GetStudentInfoID(studentID, ref studentName, ref studentNumber, ref studentDepartment, ref studentSemester, ref studentContact,
                ref studentEmail))
            {
                return new clsStudentInfos(studentID, studentName, studentNumber, studentDepartment, studentSemester, studentContact,
                 studentEmail);
            }
            return null;
        }

        public static clsStudentInfos FindStudentNumber(string studentNumber)
        {
            string studentName = "", studentDepartment = "", studentSemester = "", studentContact = "",
                studentEmail = "";
            int studentID = -1;
            if (clsStudentInfosData.GetIssueBookNumberStudent(studentNumber, ref studentName, ref studentDepartment, ref studentSemester, ref studentContact,
                ref studentEmail))
            {
                return new clsStudentInfos(studentID, studentName, studentNumber, studentDepartment, studentSemester, studentContact,
                 studentEmail);
            }
            return null;
        }

        public static clsStudentInfos LogStudent(string studentName, string studentNumber)
        {
            
            if (clsStudentInfosData.LogStudentInfo( ref studentName, ref studentNumber))
            {
                return new clsStudentInfos( studentName, studentNumber);
            }
            return null;
        }

        public static DataTable GetAllStudentInfos()
        {
            return clsStudentInfosData.GetAllStudentInfos();
        }

        private int _AddStudentInfoID()
        {
            return clsStudentInfosData.AddStudentInfoID(StudentName, StudentNumber, StudentDepartment, StudentSemester, StudentContact,
                 StudentEmail);
        }

        private bool _UpdateStudentInfoID()
        {
            return clsStudentInfosData.UpdateStudentInfoID(StudentID, StudentName, StudentNumber, StudentDepartment, StudentSemester, StudentContact,
                 StudentEmail);
        }

        public bool Save()
        {
            if (Mode == enIssueBook.enAddNew)
            {
                this.StudentID = _AddStudentInfoID();
                if (this.StudentID != -1)
                    return true;
            }
            else if (Mode == enIssueBook.enUpdate)
            {
                if (_UpdateStudentInfoID())
                    return true;
            }
            return false;
        }

        public static bool DeleteStudentInfo(int StudentID)
        {
            return clsStudentInfosData.DeleteStudentInfo(StudentID);
        }
    }
}
