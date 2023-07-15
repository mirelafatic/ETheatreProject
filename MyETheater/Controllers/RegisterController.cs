using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class RegisterController : Controller
    {

        private IUserService _userService;


        public RegisterController(IUserService userService)
        {
            this._userService = userService;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create() 
        {
            return View("Register");
        }

        public ActionResult Store(UserModel user, string registerText)
        {
            
            bool result = this._userService.Register(user);
            if (result && registerText.Equals("odobrenje23")) {
                return RedirectToAction("Login", "UserManagement");
            }
            else
            {
                return View("Register", user);
            }
        }


    }
}