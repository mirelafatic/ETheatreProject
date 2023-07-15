using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class ActorService : IActorService
    {

        public ActorModel GetActorByID(int actorID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorOperations.GetActorByID(actorID, connectionString);
        }

        public List<ActorModel> GetActors()
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorOperations.GetActors(connectionString);
        }

        public List<string> GetActorsPlay(int actorID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorOperations.GetActorsPlay(actorID, connectionString);
        }

        public bool InsertActor(ActorModel actor)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorOperations.InsertActor(actor, connectionString);   
        }

        public bool DeleteActor(int actorID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return ActorOperations.DeleteActor(actorID, connectionString);
        }
    }
}