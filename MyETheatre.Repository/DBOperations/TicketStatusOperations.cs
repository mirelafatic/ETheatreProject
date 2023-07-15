using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class TicketStatusOperations
    {
        public static List<TicketStatusModel> GetTicketStatuses(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM TicketStatus";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<TicketStatusModel> result = new List<TicketStatusModel>();

                    while (reader.Read())
                    {
                        TicketStatusModel ticketStatus = new TicketStatusModel();
                        ticketStatus.StatusName = reader.GetString(0);
                        result.Add(ticketStatus);
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
    }
}
