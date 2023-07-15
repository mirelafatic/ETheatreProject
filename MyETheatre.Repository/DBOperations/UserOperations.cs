using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class UserOperations
    {
        public static UserModel Login(UserModel userData, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand userCommand = new SqlCommand();
                    userCommand.Connection = connection;
                    userCommand.CommandText = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";
                    userCommand.Parameters.AddWithValue("Username", userData.Username);
                    userCommand.Parameters.AddWithValue("Password", userData.Password);

                    SqlDataReader reader = userCommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        return null;
                    }

                    //reader.GetString()...
                    //userData popunjavanje(isAdmin, email, name...)

                    connection.Close();
                    return userData;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        
        public static bool Register(UserModel user, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try 
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO [User] (Email, Password, Username) " +
                                                "VALUES (@Email, @Password, @Username)";
                    insertCommand.Parameters.AddWithValue("Email", user.Email);
                    insertCommand.Parameters.AddWithValue("Password", user.Password);
                    insertCommand.Parameters.AddWithValue("Username", user.Username);

                    int rowAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowAffected == 1;
                }
                catch(Exception e)
                {
                    return false;
                }

            }
        }
     

    }
}
