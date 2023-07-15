using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class WatcherService : IWatcherService
    {
        public bool ClearWatchers()
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return WatcherOperations.ClearWatchers(connectionString);
        }

        public List<WatcherModel> GetWatchers()
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return WatcherOperations.GetWatchers(connectionString);
        }

        public List<WatcherModel> GetWatchersNames(int showingID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return WatcherOperations.GetWatchersNames(connectionString, showingID);
        }

        public bool InsertWatcher(WatcherModel watcher)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString; ;
            return WatcherOperations.InsertWatcher(watcher, connectionString);
        }
    }
}