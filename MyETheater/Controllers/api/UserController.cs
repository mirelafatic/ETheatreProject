using MyETheater.Services.Interfaces;
using MyETheatre.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyETheater.Controllers.api
{
    public class UserController : ApiController
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("api/user/login")]
        public IHttpActionResult Login([FromBody] UserModel userData)
        {
            UserModel result = this._userService.Login(userData);
            return Ok(result);
        }
    }
}
