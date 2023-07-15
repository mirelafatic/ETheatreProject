using MyETheater.Services.Interfaces;
using MyETheatre.Repository.DBOperations;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyETheater.Services.Implementations
{

    public class TicketService : ITicketService
    {
        public bool DeleteTicket(int TicketID)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return TicketOperations.DeleteTicket(TicketID, connectionString);
        }

        public List<TicketModel> GetShowingsTickets(int id)
        {
            string connectionString = System
                                      .Configuration
                                      .ConfigurationManager
                                      .ConnectionStrings["MyETheatre"]
                                      .ConnectionString;
            return TicketOperations.GetShowingsTickets(connectionString, id);
        }

        public List<TicketModel> GetWhatchersTickets(int id)
        {
            string connectionString = System
                                       .Configuration
                                       .ConfigurationManager
                                       .ConnectionStrings["MyETheatre"]
                                       .ConnectionString;
            return TicketOperations.GetWhatchersTickets(connectionString, id);
        }

        public bool InsertTicket(TicketModel ticket)
        {
            string connectionString = System
                                       .Configuration
                                       .ConfigurationManager
                                       .ConnectionStrings["MyETheatre"]
                                       .ConnectionString;
            return TicketOperations.InsertTicket(ticket, connectionString);
        }
    }
}