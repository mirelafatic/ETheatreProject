using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.Models.DB
{
    public class PlayModel
    {
            public int PlayID { get; set; }
            public string PlayName { get; set; }
            public string Director { get; set; }
            public int ShowingID { get; set; }
            public string Description { get; set; }
        
    }
}
