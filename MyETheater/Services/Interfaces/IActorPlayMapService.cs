using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Interfaces
{
    public interface IActorPlayMapService
    {
        bool InsertMap(int playID, int actorID);
    }
}