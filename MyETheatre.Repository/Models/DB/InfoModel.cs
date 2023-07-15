using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheatre.Repository.Models.DB
{
    public class InfoModel
    {
        public string TheatreName { get; set; }
        public string TheatreInfos { get; set; }
        public string TheatreOwner { get; set; }
        public string ForReservation { get; set; }
        public string ForNewActors { get; set; }
        public string OwnerEmail { get; set; }
        public string ForReservationEmail { get; set; }
        public string ForNewActorsEmail { get; set; }
        public string ForOtherInfos { get; set; }
        public string ForOtherInfosEmail { get; set; }
    }
}
