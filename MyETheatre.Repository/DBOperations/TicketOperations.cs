using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class TicketOperations
    {
        public static List<TicketModel> GetWhatchersTickets(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Ticket WHERE WhatcherID = @WatcherID";
                    selectCommand.Parameters.AddWithValue("WatcherID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<TicketModel> result = new List<TicketModel>();
                    while (reader.Read())
                    {
                        TicketModel ticket = new TicketModel();
                        ticket.TicketID = reader.GetInt32(0);
                        ticket.ShowingID = reader.GetInt32(1);
                        ticket.WatcherID = reader.GetInt32(2);
                        ticket.StatusName = reader.GetString(3);
                        result.Add(ticket);
                    }
                    connection.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<TicketModel> GetShowingsTickets(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Ticket WHERE WhatcherID = @ShowingID";
                    selectCommand.Parameters.AddWithValue("ShowingID", id);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<TicketModel> result = new List<TicketModel>();
                    while (reader.Read())
                    {
                        TicketModel ticket = new TicketModel();
                        ticket.TicketID = reader.GetInt32(0);
                        ticket.ShowingID = reader.GetInt32(1);
                        ticket.WatcherID = reader.GetInt32(2);
                        ticket.StatusName = reader.GetString(3);
                        result.Add(ticket);
                    }
                    connection.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool InsertTicket(TicketModel ticket, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Ticket (ShowingID, WatcherID, StatusName) " +
                                                "VALUES (@ShowingID, @WatcherID, @StatusName)";
                    insertCommand.Parameters.AddWithValue("ShowingID", ticket.ShowingID);
                    insertCommand.Parameters.AddWithValue("WatcherID", ticket.WatcherID);
                    insertCommand.Parameters.AddWithValue("StatusName", ticket.StatusName);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    connection.Open();
                    
                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool DeleteTicket(int ticketID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Ticket WHERE " +
                                                "TicketID = @TicketID";
                    deleteCommand.Parameters.AddWithValue("TicketID", ticketID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
