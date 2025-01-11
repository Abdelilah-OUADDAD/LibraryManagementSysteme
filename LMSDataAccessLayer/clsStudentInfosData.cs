using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDataAccessLayer
{
    public class clsStudentInfosData
    {
        public static bool GetStudentInfoID(int StudentID, ref string StudentName, ref string StudentNumber, ref string StudentDepartment,
           ref string StudentSemester, ref string StudentContact, ref string StudentEmail)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblStudentInfos where stId = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentID", StudentID);

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

        public static bool GetIssueBookNumberStudent(string StudentNumber, ref string StudentName, ref string StudentDepartment,
            ref string StudentSemester, ref string StudentContact, ref string StudentEmail)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblStudentInfos where stNumber = @StudentNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);

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

        public static bool LogStudentInfo(ref string StudentName, ref string StudentNumber)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblStudentInfos where stName = @StudentName and stNumber = @StudentNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentName", StudentName);
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                StudentName = (string)reader["stName"];
                                StudentNumber = (string)reader["stNumber"];
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
        public static DataTable GetAllStudentInfos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblStudentInfos ";

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

        public static int AddStudentInfoID(string StudentName, string StudentNumber, string StudentDepartment,
             string StudentSemester, string StudentContact, string StudentEmail)
        {
            int RowAffected = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = @"INSERT INTO tblStudentInfos
                                               (stName
                                               ,stNumber
                                               ,stDepartment
                                               ,stSemester
                                               ,stContact
                                               ,stEmail)
                                         VALUES
                                               (@StudentName
                                               ,@StudentNumber
                                               ,@StudentDepartment
                                               ,@StudentSemester
                                               ,@StudentContact 
                                               ,@StudentEmail)
                                select scope_identity() ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentName", StudentName);
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    command.Parameters.AddWithValue("@StudentDepartment", StudentDepartment);
                    command.Parameters.AddWithValue("@StudentSemester", StudentSemester);
                    command.Parameters.AddWithValue("@StudentContact", StudentContact);
                    command.Parameters.AddWithValue("@StudentEmail", StudentEmail);

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

        public static bool UpdateStudentInfoID(int StudentID, string StudentName, string StudentNumber, string StudentDepartment,
             string StudentSemester, string StudentContact, string StudentEmail)
        {
            bool IsAffected = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"UPDATE tblStudentInfos
                                               SET stName = @StudentName
                                                  ,stNumber = @StudentNumber
                                                  ,stDepartment = @StudentDepartment
                                                  ,stSemester = @StudentSemester
                                                  ,stContact = @StudentContact
                                                  ,stEmail = @StudentEmail
                                             WHERE stId = @StudentID ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    command.Parameters.AddWithValue("@StudentName", StudentName);
                    command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                    command.Parameters.AddWithValue("@StudentDepartment", StudentDepartment);
                    command.Parameters.AddWithValue("@StudentSemester", StudentSemester);
                    command.Parameters.AddWithValue("@StudentContact", StudentContact);
                    command.Parameters.AddWithValue("@StudentEmail", StudentEmail);

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

        public static bool DeleteStudentInfo(int StudentID)
        {
            bool isDeleted = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"DELETE FROM tblStudentInfos WHERE stId = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if(result != 0) 
                            isDeleted = true;
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            return isDeleted;
        }

    }
}
