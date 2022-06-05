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
        public ActionResult Authenticate(string userName, string password)
        {
            return Ok(sessionService.Authenticate(userName, password));
        }
    }
}