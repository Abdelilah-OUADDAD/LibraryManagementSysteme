using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDataAccessLayer
{
    public class clsIssueBooksData
    {
        public static bool GetIssueBookID(int ID, ref string StudentName, ref string StudentNumber, ref string StudentDepartment,
            ref string StudentSemester, ref string StudentContact, ref string StudentEmail,ref string BookName , ref string BookIssueDate,
            ref string BookReturnDate)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblIssueBooks where Id = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                StudentName = (string)reader["stName"];
                                StudentNumber = (string)reader["stNumber"];
                                StudentDepartment = (string)reader["stDepartment"];
                                StudentSemester = (string)reader["stSemester"];
                                StudentContact = (string)reader["stContact"];
                                StudentEmail = (string)reader["stEmail"];
                                BookName = (string)reader["bkName"];
                                BookIssueDate = (string)reader["bkIssueDate"];
                                if (reader["bkReturnDate"] != DBNull.Value)
                                    BookReturnDate = (string)reader["bkReturnDate"];
                                else
                                    BookReturnDate = "";
                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return isFound;
        }

        public static DataTable GetAllIssueBooks()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblIssueBooks ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return dt;
        }

        public static DataTable GetIssueBooksNumberReturn(string StudentNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select X = 'yes' from tblIssueBooks where stNumber = @StudentNumber and bkReturnDate is null ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return dt;
        }

        public static DataTable GetStudentDoesNotReturnBook(string StudentNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"select stName, stDepartment, stSemester, stContact, stEmail, bkName, bkIssueDate, bkReturnDate
                                from tblIssueBooks where stNumber = @StudentNumber and bkReturnDate is null ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return dt;
        }
        public static int AddIssueBookID(string StudentName, string StudentNumber, string StudentDepartment,
             string StudentSemester, string StudentContact, string StudentEmail, string BookName, string BookIssueDate, string BookReturnDate)
        {
            int RowAffected = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = @"INSERT INTO tblIssueBooks
                                               (stName
                                               ,stNumber
                                               ,stDepartment
                                               ,stSemester
                                               ,stContact
                                               ,stEmail
                                               ,bkName
                                               ,bkIssueDate
                                               ,bkReturnDate)
                                         VALUES
                                               (@StudentName
                                               ,@StudentNumber
                                               ,@StudentDepartment
                                               ,@StudentSemester
                                               ,@StudentContact 
                                               ,@StudentEmail
                                               ,@BookName 
                                               ,@BookIssueDate 
                                               ,@BookReturnDate)
                                select scope_identity() ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentName", StudentName );
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber );
                    command.Parameters.AddWithValue("@StudentDepartment",StudentDepartment );
                    command.Parameters.AddWithValue("@StudentSemester",StudentSemester );
                    command.Parameters.AddWithValue("@StudentContact",StudentContact );
                    command.Parameters.AddWithValue("@StudentEmail", StudentEmail );
                    command.Parameters.AddWithValue("@BookName ", BookName  );
                    command.Parameters.AddWithValue("@BookIssueDate ",BookIssueDate  );
                    if(BookReturnDate == "")
                        command.Parameters.AddWithValue("@BookReturnDate", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@BookReturnDate", BookReturnDate);


                    try
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int intResult))
                        {
                            RowAffected = intResult;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return RowAffected;
        }

        public static bool UpdateIssueBookID( string StudentNumber,string BookReturnDate,string BookName)
        {
            bool IsAffected = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"UPDATE tblIssueBooks SET bkReturnDate = @BookReturnDate
                                             WHERE stNumber = @StudentNumber and bkName = @BookName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    command.Parameters.AddWithValue("@BookReturnDate", BookReturnDate);
                    command.Parameters.AddWithValue("@BookName", BookName);

                    try
                    {
                        int result = command.ExecuteNonQuery();

                        if (result != 0)
                        {
                            IsAffected = true;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return IsAffected;
        }


        public static bool DeleteIssueBook(int ID)
        {
            bool isDeleted = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"DELETE FROM tblIssueBooks WHERE Id = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result != 0)
                            isDeleted = true;
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return isDeleted;
        }

        public static bool IsExistBookName(string StudentNumber, string BookName)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"select X = 'yes' from tblIssueBooks where stNumber = @StudentNumber and bkReturnDate is null and bkName = @BookName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    command.Parameters.AddWithValue("@BookName", BookName);
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                isExist = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return isExist;
        }

        public static DataTable GetAllStudentReturnBook()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"select Id, stName, stDepartment, stSemester, stContact, stEmail, bkName, bkIssueDate, bkReturnDate  from tblIssueBooks
                      where bkReturnDate is not null ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return dt;
        }

        public static DataTable GetAllStudentDoesNotReturnBook()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"select stName, stDepartment, stSemester, stContact, stEmail, bkName, bkIssueDate, bkReturnDate
                                from tblIssueBooks where bkReturnDate is null ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return dt;
        }
    }
}
