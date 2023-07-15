using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Interfaces
{
    public interface IShowingService
    {
        List<ShowingModel> GetShowings(int playID);
        bool InsertShowing(ShowingModel showing);
        bool UpdateShowing(int id);
    }
}