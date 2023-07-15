using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.Models.DB
{
    public class ShowingModel
    {
        public int ShowingID { get; set; }
        public int HallID { get; set; }
        public DateTime ShowingDate { get; set; }
        public int PlayID { get; set; }
        public int Cijena { get; set; }

        public int SlobodnaMijesta { get; set; }
    }
}
