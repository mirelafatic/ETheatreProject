using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyETheater.Services
{
    public class PlayService : IPlayService
    {

        public List<PlayModel> GetPlays()
        {

            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return PlayOperations.GetPlays(connectionString);
        }

        public PlayModel GetPlayByID(int playID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return PlayOperations.GetPlayByID(playID, connectionString);
        }

        public List<String> GetPlayActors(int playID) {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return PlayOperations.GetPlayActors(playID, connectionString);
        }

        public bool InsertPlay(PlayModel play)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return PlayOperations.InsertPlay(play, connectionString);
        }

        public bool DeletePlay(int playID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return PlayOperations.DeletePlay(playID, connectionString);
        }
    }
}