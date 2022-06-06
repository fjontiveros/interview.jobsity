using Jobsity.Chatroom.WebApi.Model;
using Jobsity.Chatroom.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobsity.Chatroom.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly ISessionService sessionService;

        public UserController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authenticate(UserModel user)
        {
            return Ok(sessionService.Authenticate(user.UserName, user.Password));
        }

        public class UserModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}