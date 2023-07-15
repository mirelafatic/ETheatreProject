using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{
    public class TicketStatusService : ITicketStatusService
    {
        List<TicketStatusModel> ITicketStatusService.GetTicketStatuses()
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return TicketStatusOperations.GetTicketStatuses(connectionString);
        }
    }
}