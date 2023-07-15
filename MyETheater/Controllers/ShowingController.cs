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
    public class ShowingController : Controller
    {
        private IShowingService _showingService;
        private IHallService _hallService;
        private IPlayService _playService;
        private IWatcherService _watcherService;
        private ITicketService _ticketService;
        private ITicketStatusService _ticketStatusService;
        public ShowingController(IHallService hallService, IShowingService showingService, IPlayService playService, IWatcherService watcherService, ITicketService ticketService, ITicketStatusService ticketStatusService)
        {
            this._showingService = showingService;
            this._hallService = hallService;
            this._playService = playService;
            this._watcherService = watcherService;
            this._ticketService = ticketService;
            this._ticketStatusService = ticketStatusService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            List<HallModel> halls = this._hallService.GetHalls();
            ViewBag.H = new SelectList(halls, "HallID", "HallSeats");

            List<PlayModel> plays = this._playService.GetPlays();
            ViewBag.Plays = plays;

            return View("Showing");
        }

        public ActionResult Store(ShowingModel showing)
        {
            bool result = false;
            result = this._showingService.InsertShowing(showing);


            if (result)
            {

                return RedirectToAction("Index", "Play");
            }
            else
            {
                return View("Showing", showing);
            }

        }

        public ActionResult CreateReservation(int id)
        {
            ViewBag.ShowingID = id;
            List<TicketStatusModel> statuses = this._ticketStatusService.GetTicketStatuses();
            ViewBag.Statuses = statuses;
            List<WatcherModel> watchers = this._watcherService.GetWatchers();
            ViewBag.Watchers = watchers;

            return View("Reservation");
        }

        public ActionResult StoreRes(TicketModel ticket)
        {
            bool result = false;
            result = this._ticketService.InsertTicket(ticket);
            bool result2 = false;
            result2 = this._showingService.UpdateShowing(ticket.ShowingID);

            if (result == true && result2 == true)
            {

                return RedirectToAction("Index", "Play");
            }
            else
            {
                return View("Reservation", ticket);
            }

        }

        public ActionResult Watcher()
        {
            List<PlayModel> plays = this._playService.GetPlays();
            ViewBag.Plays = plays;
            return View();
        }


        public ActionResult TicketReservations()
        {
            List<PlayModel> plays = this._playService.GetPlays();
            ViewBag.Plays = plays;
            return View();
        }


        public ActionResult PlaysShowings(int id)
        {
            List<ShowingModel> showings = this._showingService.GetShowings(id);
            ViewBag.Showings = showings;
            return View();
        }

        public ActionResult ShowingsTickets(int id)
        {
            List<WatcherModel> watchers = this._watcherService.GetWatchersNames(id);
            ViewBag.Watchers = watchers;
            return View();
        }

        public ActionResult CreateWatcher()
        {
            return View();
        }

        public ActionResult StoreWatcher(WatcherModel watcher)
        {
            bool result = this._watcherService.InsertWatcher(watcher);
            if (result == true)
            {
                return RedirectToAction("Index", "Play");
            }
            else
            {
                return View("CreateWatcher", watcher);
            }
        }

        public ActionResult RefreshWatchers()
        {
            bool result = this._watcherService.ClearWatchers();
            if (result == true)
            {
                return RedirectToAction("Index", "Play");
            }
            else
            {
                return View("Index");
            }
        }

    }
}