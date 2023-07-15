using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyETheater.Services.Interfaces
{
    public interface IPlayService
    {
        List<PlayModel> GetPlays();

        PlayModel GetPlayByID(int playID);

        List<String> GetPlayActors(int playID);

        bool InsertPlay(PlayModel play);

        bool DeletePlay(int playID);

    }
}
