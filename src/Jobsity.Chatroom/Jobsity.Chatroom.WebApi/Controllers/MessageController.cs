using Jobsity.Chatroom.WebApi.Model;
using Jobsity.Chatroom.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobsity.Chatroom.WebApi.Controllers
{
    public class MessageController : BaseController
    {
        private readonly ILogger<ChatroomController> logger;
        private readonly IChatroomService chatroomService;

        public MessageController(ILogger<ChatroomController> logger,
            IChatroomService chatroomService)
        {
            this.logger = logger;
            this.chatroomService = chatroomService;
        }

        [HttpGet("{chatroomId}")]
        public ActionResult Get(Guid chatroomId)
        {
            return Ok(chatroomService.GetLatestMessages(chatroomId).Select(x => new { x.Text, x.User.Name, x.TimeStamp }));
        }

        [HttpPost("{chatroomId}")]
        public async Task<ActionResult> PostMessage(Guid chatroomId, [FromBody] string text)
        {
            return Ok(await chatroomService.PostMessage(text, chatroomId));
        }
    }
}