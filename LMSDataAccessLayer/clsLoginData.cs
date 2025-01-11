using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMSDataAccessLayer
{
    public class clsLoginData
    {
        public static bool GetLogin(ref string user,ref string Password)
        {
            bool isFounded = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblLogin where UserName = @user and Password = @Password ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                user = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                
                                isFounded = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

            return isFounded;
        }

        public static int AddLoginUser(string user, string Password)
        {
            int RowAffected = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"insert into tblBookInfos (UserName, Password)
                    value(@user, @Password)
                    Select SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@Password", Password);

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

        public static bool UpdateLoginPassword(string user, string Password)
        {
            bool IsAffected = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = @"Update tblBookInfos  set Password = @Password
                                where UserName = @user ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@BookName", Password);

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

        public static bool DeleteLoginUser(string user)
        {
            bool isDeleted = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"DELETE FROM tblBookInfos WHERE UserName = @user";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user", user);
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
    }
}
