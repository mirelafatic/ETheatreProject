using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheater.Services.Interfaces
{
    public interface ITicketService
    {

        List<TicketModel> GetWhatchersTickets(int id);
        List<TicketModel> GetShowingsTickets(int id);
        bool InsertTicket(TicketModel ticket);
        bool DeleteTicket(int ticketID);
    }
}
