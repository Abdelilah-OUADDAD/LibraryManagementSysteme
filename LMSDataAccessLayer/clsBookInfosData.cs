using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDataAccessLayer
{
    public class clsBookInfosData
    {
        public static bool GetBookInfosID(int BookID,ref string BookName,ref string BookAuthor,ref string BookPublication , ref string BookDate
            ,ref int BookPrice,ref int BookQuantity)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = "select * from tblBookInfos where bkId = @BookID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@BookId", BookID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                BookName = (string)reader["bkName"];
                                BookAuthor = (string)reader["bkAuthor"];
                                BookPublication = (string)reader["bkPublication"];
                                BookDate = (string)reader["bkDate"];

                                BookQuantity =  (int)reader["bkQuantity"];
                                BookPrice = (int)reader["bkPrice"];
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

        public static DataTable GetAllBookInfos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = "select * from tblBookInfos ";

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

        public static DataTable GetBookName()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = "select bkName from tblBookInfos ";

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

        public static int AddBookInfosID( string BookName, string BookAuthor, string BookPublication, string BookDate
            , int BookPrice, int BookQuantity)
        {
            int RowAffected = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"insert into tblBookInfos (bkName, bkAuthor, bkPublication, bkDate, bkPrice, bkQuantity)
                    values(@BookName, @BookAuthor, @BookPublication, @BookDate, @BookPrice, @BookQuantity)
                    Select SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BookName", BookName);
                    command.Parameters.AddWithValue("@BookAuthor", BookAuthor);
                    command.Parameters.AddWithValue("@BookPublication", BookPublication);
                    command.Parameters.AddWithValue("@BookDate", BookDate);
                    command.Parameters.AddWithValue("@BookPrice", BookPrice);
                    command.Parameters.AddWithValue("@BookQuantity", BookQuantity);

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

        public static bool UpdateBookInfosID(string BookName, string BookAuthor, string BookPublication, string BookDate
            , int BookPrice, int BookQuantity)
        {
            bool IsAffected = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                string query = @"Update tblBookInfos  set bkName = @BookName, bkAuthor = @BookAuthor, 
                                bkPublication = @BookPublication, bkDate = @BookDate, bkPrice = @BookPrice, bkQuantity = @BookQuantity
                                where bkName = @BookName ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@BookID", BookID);
                    command.Parameters.AddWithValue("@BookName", BookName);
                    command.Parameters.AddWithValue("@BookAuthor", BookAuthor);
                    command.Parameters.AddWithValue("@BookPublication", BookPublication);
                    command.Parameters.AddWithValue("@BookDate", BookDate);
                    command.Parameters.AddWithValue("@BookPrice", BookPrice);
                    command.Parameters.AddWithValue("@BookQuantity", BookQuantity);

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

        public static bool DeleteBookInfo(string BookName)
        {
            bool isDeleted = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"DELETE FROM tblBookInfos WHERE bkName = @BookName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookName", BookName);
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
