using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class ActorPlayMapService : IActorPlayMapService
    {
        public bool InsertMap(int playID, int actorID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorPlayMapOperations.InsertMap(playID, actorID, connectionString);
        }
    }
}