using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class ActorOperations
    {
        public static List<ActorModel> GetActors(string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Actor";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ActorModel> result = new List<ActorModel>();

                    while (reader.Read())
                    {
                        ActorModel actor = new ActorModel();
                        actor.ActorID = reader.GetInt32(0);
                        actor.ActorName = reader.GetString(1);

                        result.Add(actor);
                    }
                    connection.Close();
                    return result;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool InsertActor(ActorModel actor, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Actor (ActorName) " +
                                                "VALUES (@ActorName)";
                    insertCommand.Parameters.AddWithValue("ActorName", actor.ActorName);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected == 1;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        public static ActorModel GetActorByID(int actorID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Actor WHERE ActorID = @ActorID";
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    ActorModel actor = new ActorModel();
                    actor.ActorID = reader.GetInt32(0);
                    actor.ActorName = reader.GetString(1);

                    connection.Close();
                    return actor;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }


        public static List<String> GetActorsPlay(int actorID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT PlayName FROM ( SELECT PlayID FROM ActorPlayMap WHERE ActorPlayMap.ActorID = @ActorID ) AS p INNER JOIN Play On p.PlayID = Play.PlayID ";
                    selectCommand.Parameters.AddWithValue("ActorID", actorID);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<String> result = new List<String>();

                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    connection.Close();
                    return result;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }


        public static bool DeleteActor(int id, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand1 = new SqlCommand();
                    deleteCommand1.Connection = connection;
                    deleteCommand1.CommandText = "DELETE FROM ActorPlayMap WHERE " +
                                                "ActorID = @ActorID";
                    deleteCommand1.Parameters.AddWithValue("ActorID", id);

                    int rowsAffected1 = deleteCommand1.ExecuteNonQuery();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Actor WHERE " +
                                                "ActorID = @ActorID";
                    deleteCommand.Parameters.AddWithValue("ActorID", id);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1  && rowsAffected1 == 1;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

    }
}
