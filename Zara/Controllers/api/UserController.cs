using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Controllers.api
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
        public IHttpActionResult Login([FromBody]UserModel userData)
        {
            UserModel result = this._userService.Login(userData);
            return Ok(result);
        }

    }
}
