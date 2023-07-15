using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class HallService : IHallService
    {
        public List<HallModel> GetHalls()
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return HallOperations.GetHalls(connectionString);
        }
    }
}