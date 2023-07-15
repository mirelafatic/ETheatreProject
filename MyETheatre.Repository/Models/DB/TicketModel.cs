using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.Models.DB
{
    public class TicketModel
    {
        public int TicketID { get; set; }
        public int ShowingID { get; set; }
        public int WatcherID { get; set; }
        public string StatusName { get; set; }

    }
}
