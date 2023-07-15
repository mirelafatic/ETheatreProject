using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyETheatre.Repository.Models.DB;

namespace MyETheater.Services.Interfaces
{
    public interface IHallService
    {
        List<HallModel> GetHalls();
    }
}