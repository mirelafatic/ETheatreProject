using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class ActorController : Controller
    {

        private IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            this._actorService = actorService;
        }

        // GET: Actor
        public ActionResult Index()
        {

            List<ActorModel> actors = this._actorService.GetActors();
            ViewBag.Actors = actors;

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            foreach (var item in actors)
            {
                List<string> curr = this._actorService.GetActorsPlay(item.ActorID);
                string name  = item.ActorName;
                dic.Add(name, curr);
            }

            ViewBag.Dict = dic;

            return View();
        }

        public ActionResult Plays(int id)
        {
            //ActorModel actor = this._actorService.GetActorByID(id);
            List<String> playNames = this._actorService.GetActorsPlay(id);
            ViewBag.PlayNames = playNames;
            return RedirectToAction("Index");
        }
        

        public ActionResult Create()
        {
            return View("Actor");
        }

        public ActionResult Store(ActorModel actor)
        {
            bool result = this._actorService.InsertActor(actor);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Actor", actor);
            }
        }


        public ActionResult DeleteActor()
        {
            List<ActorModel> actors = this._actorService.GetActors();
            ViewBag.Actors = actors;
            return View();
        }

        public ActionResult Del(ActorModel actor)
        {
            bool result = this._actorService.DeleteActor(actor.ActorID);
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