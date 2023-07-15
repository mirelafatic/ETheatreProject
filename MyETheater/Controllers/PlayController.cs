using MyETheater.Services;
using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class PlayController : Controller
    {

        private IPlayService _playService;
        private IShowingService _showingService;
        public PlayController(IPlayService playService, IShowingService showingService, IActorService actorService)
        {
            this._playService = playService;
            this._showingService = showingService;
        }

        // GET: Theatre       //GET ALL 
        public ActionResult Index()
        {

            List<PlayModel> plays = this._playService.GetPlays();
            ViewBag.Plays = plays;

            return View();
        }

        //GET BY ID
        public ActionResult ViewPlayDetails(int id)
        {
            PlayModel result = this._playService.GetPlayByID(id);
            List<String> actNames = this._playService.GetPlayActors(id);
            ViewBag.ActorNames = actNames;
            ViewBag.Play = result;
            return View();
        }

        public ActionResult ViewShowings(int id)
        {
            List<ShowingModel> showings = this._showingService.GetShowings(id);
            ViewBag.Showings = showings;
            return View("ViewShowings");
        }


        public ActionResult Create() 
        {
            return View("Play");
        }


        public ActionResult Store(PlayModel play) 
        {

            bool result = this._playService.InsertPlay(play);
            if (result) {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Play", play);
            }
        }

        

        public ActionResult DeletePlay(int id)
        {
            bool result = this._playService.DeletePlay(id);
            if (result == true) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}