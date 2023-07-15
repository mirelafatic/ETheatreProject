using MyETheater.Services;
using MyETheater.Services.Implementations;
using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class MapController : Controller
    {
        private IActorPlayMapService _actorPlayMapService;
        private IPlayService _playService;
        private IActorService _actorService;

        public MapController(PlayService playService, ActorService actorService, ActorPlayMapService actorPlayMapService) {

            this._actorPlayMapService = actorPlayMapService;
            this._actorService = actorService;
            this._playService = playService;
        }

        public ActionResult Create()
        {
            List<ActorModel> actors = this._actorService.GetActors();
            ViewBag.Actors = actors;

            List<PlayModel> plays = this._playService.GetPlays();
            ViewBag.Plays = plays;

            return View("ActorPlayMap");
        }


        public ActionResult Store(ActorPlayMapModel mapModel)
        {
            bool result = false;

            result = this._actorPlayMapService.InsertMap(mapModel.PlayID, mapModel.ActorID);
            if (result)
            {

                return RedirectToAction("Index", "Play");
            }
            else
            {
                return View("ActorPlayMap", mapModel);
            }

        }


        // GET: Map
        public ActionResult Index()
        {
            return View();
        }
    }
}