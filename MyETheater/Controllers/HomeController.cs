using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class HomeController : Controller
    {

        private IInfosService _infosService;
        public HomeController(IInfosService infosService) 
        {
            this._infosService = infosService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact() 
        {

            InfoModel infos = this._infosService.GetInfos();
            ViewBag.Infos = infos;
            return View("CustomView");
        }

    }
}