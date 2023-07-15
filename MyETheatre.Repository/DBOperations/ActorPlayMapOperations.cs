using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class ActorPlayMapOperations
    {
        public static bool InsertMap(int playID, int actorID, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO ActorPlayMap (ActorID, PlayID) " +
                                                "VALUES (@ActorID, @PlayID)";
                    insertCommand.Parameters.AddWithValue("ActorID", actorID);
                    insertCommand.Parameters.AddWithValue("PlayID", playID);

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
    }
}
