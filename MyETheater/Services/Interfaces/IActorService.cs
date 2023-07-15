using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Interfaces
{
    public interface IActorService
    {
        List<ActorModel> GetActors();
        bool InsertActor(ActorModel actor);
        ActorModel GetActorByID(int actorID);
        List<String> GetActorsPlay(int actorID);
        bool DeleteActor(int actorID);
    }
}