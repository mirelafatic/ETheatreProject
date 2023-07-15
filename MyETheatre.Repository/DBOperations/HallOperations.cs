using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class HallOperations
    {
        public static List<HallModel> GetHalls(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Hall";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<HallModel> result = new List<HallModel>();

                    while (reader.Read())
                    {
                        HallModel hall = new HallModel();
                        hall.HallID = reader.GetInt32(0);
                        hall.HallSeats = reader.GetInt32(1);
                        result.Add(hall);
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
