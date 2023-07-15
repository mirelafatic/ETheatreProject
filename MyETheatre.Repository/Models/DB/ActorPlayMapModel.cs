using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.Models.DB
{
    public class ActorPlayMapModel
    {
        public int ActorPlayMapID { get; set; }
        public int ActorID { get; set; }
        public int PlayID { get; set; }
    }
}
