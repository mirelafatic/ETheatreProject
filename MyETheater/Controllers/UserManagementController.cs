﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyETheater.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Login()
        {
            return View();
        }
    }
}