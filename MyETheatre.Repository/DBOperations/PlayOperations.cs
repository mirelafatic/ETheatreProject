using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class PlayOperations
    {


        //GET ALL PLAYS
        public static List<PlayModel> GetPlays(string connectionString)
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
                    selectCommand.CommandText = "SELECT * FROM Play";
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<PlayModel> result = new List<PlayModel>();
                    while (reader.Read())
                    {
                        PlayModel play = new PlayModel();
                        play.PlayID = reader.GetInt32(0);
                        play.PlayName = reader.GetString(1);
                        play.Director = reader.GetString(2);
                        play.ShowingID = reader.GetInt32(3);
                        play.Description = reader.GetString(4);
                        result.Add(play);
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

        //GET PLAY BY ID 
        public static PlayModel GetPlayByID(int playID, string connectionString) {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Play WHERE PlayID = @PlayID";
                    selectCommand.Parameters.AddWithValue("PlayID", playID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    PlayModel play = new PlayModel();
                    play.PlayID = reader.GetInt32(0);
                    play.PlayName = reader.GetString(1);
                    play.Director = reader.GetString(2);
                    play.ShowingID = reader.GetInt32(3);
                    play.Description = reader.GetString(4);


                    connection.Close();
                    return play;
                } catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<String> GetPlayActors(int playID, string connectionString) {
            using (SqlConnection connection = new SqlConnection())
            {
                try {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT ActorName FROM ( SELECT ActorID FROM ActorPlayMap WHERE ActorPlayMap.PlayID = @PlayID ) AS act INNER JOIN Actor ON act.ActorID = Actor.ActorID ";
                    selectCommand.Parameters.AddWithValue("PlayID", playID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<String> result = new List<String>();
                    while (reader.Read()) {
                        result.Add(reader.GetString(0));
                    }
                    connection.Close();
                    return result;
                }
                catch (Exception ex) {
                    return null;
                }
            }
        }


        public static bool InsertPlay(PlayModel play, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Play (PlayName, Director, ShowingID, Description) " +
                                                "VALUES (@PlayName, @Director, @ShowingID, @Description)";
                    insertCommand.Parameters.AddWithValue("PlayName", play.PlayName);
                    insertCommand.Parameters.AddWithValue("Director", play.Director);
                    insertCommand.Parameters.AddWithValue("ShowingID", 1);                      //NAKON STO UNESE NOVI SHOWING TREBA ODJE DA MU GA PROSLIJEDI
                    insertCommand.Parameters.AddWithValue("Description", play.Description);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool DeletePlay(int playID, string connectionString) 
        { 
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Play WHERE " +
                                                "PlayID = @PlayID";
                    deleteCommand.Parameters.AddWithValue("PlayID", playID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT ShowingID FROM Showingg WHERE " +
                                                "PlayID = @PlayID";
                    selectCommand.Parameters.AddWithValue("PlayID", playID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<int> showingIDs = new List<int>();
                    while (reader.Read())
                    {
                        showingIDs.Add(reader.GetInt32(0));
                    }
                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand deleteCommand2 = new SqlCommand();
                    deleteCommand2.Connection = connection;
                    deleteCommand2.CommandText = "DELETE FROM Showingg WHERE " +
                                                "PlayID = @PlayID";
                    deleteCommand2.Parameters.AddWithValue("PlayID", playID);

                    int rowsAffected2 = deleteCommand2.ExecuteNonQuery();

                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand deleteCommand3 = new SqlCommand();
                    deleteCommand3.Connection = connection;
                    for(int i=0; i<showingIDs.Count; i++)
                    {
                        deleteCommand3.CommandText = "DELETE FROM Ticket WHERE " +
                                                     "ShowingID = @ShowingID";
                        deleteCommand3.Parameters.AddWithValue("ShowingID", showingIDs[i]);

                        int rowsAffected3 = deleteCommand3.ExecuteNonQuery();
                    };

                    connection.Close();
                    return rowsAffected == 1 && rowsAffected2 == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }    
        }

    }
}
