using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class WatcherOperations
    {

        public static List<WatcherModel> GetWatchers(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Watcher";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<WatcherModel> result = new List<WatcherModel>();

                    while (reader.Read())
                    {
                        WatcherModel watcher = new WatcherModel();
                        watcher.WatcherID = reader.GetInt32(0);
                        watcher.WatcherName = reader.GetString(1);
                        watcher.WatcherEmail = reader.GetString(2);
                  
                        result.Add(watcher);
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

        public static bool InsertWatcher(WatcherModel watcher, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Watcher (WatcherName, WatcherEmail) " +
                                                "VALUES (@WatcherName, @WatcherEmail)";
                    insertCommand.Parameters.AddWithValue("WatcherName", watcher.WatcherName);
                    insertCommand.Parameters.AddWithValue("WatcherEmail", watcher.WatcherEmail);


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


        public static List<WatcherModel> GetWatchersNames(string connectionString, int showingID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT w.WatcherID, WatcherName, WatcherEmail " +
                                                "FROM ( SELECT * FROM Ticket WHERE Ticket.ShowingID = @ShowingID ) AS t " + 
                                                "INNER JOIN Watcher w ON t.WatcherID = w.WatcherID";
                    selectCommand.Parameters.AddWithValue("ShowingID", showingID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<WatcherModel> result = new List<WatcherModel>();

                    while (reader.Read())
                    {
                        WatcherModel watcher = new WatcherModel();
                        watcher.WatcherID = reader.GetInt32(0);
                        watcher.WatcherName = reader.GetString(1);
                        watcher.WatcherEmail = reader.GetString(2);

                        result.Add(watcher);
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


        public static bool ClearWatchers(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT w.WatcherID, COUNT(*) FROM Ticket t INNER JOIN WATCHER w ON t.WatcherID = w.WatcherID GROUP BY w.WatcherID";
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<int> result = new List<int>();
                    int currID;
                    while (reader.Read())
                    {
                        currID = reader.GetInt32(0);
                        result.Add(currID);
                    }
                    connection.Close();

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand2 = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT WatcherID FROM Watcher";

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    List<int> result1 = new List<int>();
                    while (reader1.Read())
                    {
                        result1.Add(reader1.GetInt32(0));
                    }

                    connection.Close();
                    
                    for(int i=0; i<result1.Count; i++)
                    {
                        if (!result.Contains(result1[i])) 
                        {
                            connection.ConnectionString = connectionString;
                            connection.Open();

                            SqlCommand deleteCommand = new SqlCommand();
                            deleteCommand.Connection = connection;
                            deleteCommand.CommandText = "DELETE FROM Watcher WHERE " +
                                                        "WatcherID = @WatcherID";
                            deleteCommand.Parameters.AddWithValue("WatcherID", result1[i]);

                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if(rowsAffected == 0)
                            {
                                connection.Close();
                                return false;
                            }

                            connection.Close();
                        }
                    }

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


    }
}
