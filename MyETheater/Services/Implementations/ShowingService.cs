using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class ShowingService : IShowingService
    {
        public List<ShowingModel> GetShowings(int playID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ShowingOperations.GetShowings(playID, connectionString);
        }

        public bool InsertShowing(ShowingModel showing)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ShowingOperations.InsertShowing(showing, connectionString);
        }

        public bool UpdateShowing(int id)
        {
            string connectionString = System
                                       .Configuration
                                       .ConfigurationManager
                                       .ConnectionStrings["MyETheatre"]
                                       .ConnectionString;
            return ShowingOperations.UpdateShowing(id, connectionString);
        }
    }
}