using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class ShowingOperations
    {

        public static List<ShowingModel> GetShowings(int playID, string connectionString)
        {
            //kacenje na bazu 
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Showingg WHERE PlayID = @PlayID";
                    selectCommand.Parameters.AddWithValue("PlayID", playID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ShowingModel> result = new List<ShowingModel>();
                    while (reader.Read())
                    {
                        ShowingModel showing = new ShowingModel();
                        showing.ShowingID = reader.GetInt32(0);
                        showing.HallID = reader.GetInt32(1);
                        showing.ShowingDate = reader.GetDateTime(2);
                        showing.PlayID = reader.GetInt32(3);
                        showing.Cijena = reader.GetInt32(4);
                        showing.SlobodnaMijesta = reader.GetInt32(5);
                        result.Add(showing);
                    }
                    connection.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public static bool InsertShowing(ShowingModel showing, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try 
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT HallSeats FROM Hall WHERE HallID=@HallID";
                    selectCommand.Parameters.AddWithValue("HallID", showing.HallID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    showing.SlobodnaMijesta = reader.GetInt32(0);

                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Showingg (HallID, ShowingDate, PlayID, Cijena, SlobodnaMijesta) " +
                                                "VALUES (@HallID, @ShowingDate, @PlayID, @Cijena, @SlobodnaMijesta)";
                    insertCommand.Parameters.AddWithValue("HallID", showing.HallID);
                    insertCommand.Parameters.AddWithValue("ShowingDate", showing.ShowingDate);
                    insertCommand.Parameters.AddWithValue("PlayID", showing.PlayID);
                    insertCommand.Parameters.AddWithValue("Cijena", showing.Cijena);
                    insertCommand.Parameters.AddWithValue("SlobodnaMijesta", showing.SlobodnaMijesta);
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool UpdateShowing(int id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT SlobodnaMijesta FROM Showingg WHERE ShowingID=@ShowingID";
                    selectCommand.Parameters.AddWithValue("ShowingID", id);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    int currNum = reader.GetInt32(0);
                    int newNum = currNum - 1;

                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Showingg " +
                                                "SET SlobodnaMijesta = @SlobodnaMijesta " +
                                                "WHERE ShowingID = @ShowingID";
                    updateCommand.Parameters.AddWithValue("SlobodnaMijesta", newNum);
                    updateCommand.Parameters.AddWithValue("ShowingID", id);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool DeleteShowing(int playID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Showingg WHERE " +
                                                "PlayID = @PlayID";
                    deleteCommand.Parameters.AddWithValue("PlayID", playID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


    }
}
