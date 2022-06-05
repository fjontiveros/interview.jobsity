using Jobsity.Chatroom.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobsity.Chatroom.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [LogFilter]
    [ExceptionFilter]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {

    }
}