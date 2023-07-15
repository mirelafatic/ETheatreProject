using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.DBOperations
{
    public class InfosOperations
    {
        public static InfoModel GetInfos(string connectionString)
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
                    selectCommand.CommandText = "SELECT * FROM TheatreInfos";
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read();
                    
                    InfoModel infos = new InfoModel();
                    infos.TheatreName = reader.GetString(0);
                    infos.TheatreInfos = reader.GetString(1);
                    infos.TheatreOwner = reader.GetString(2);
                    infos.ForReservation = reader.GetString(3);
                    infos.ForNewActors = reader.GetString(4);
                    infos.OwnerEmail = reader.GetString(5);
                    infos.ForReservationEmail = reader.GetString(6);
                    infos.ForNewActorsEmail = reader.GetString(7);
                    infos.ForOtherInfos = reader.GetString(8);
                    infos.ForOtherInfosEmail = reader.GetString(9);
                    connection.Close();
                    return infos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
