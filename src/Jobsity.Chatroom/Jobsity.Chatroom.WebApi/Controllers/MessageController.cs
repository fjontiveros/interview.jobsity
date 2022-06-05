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
        public IEnumerable<Message> Get(Guid chatroomId)
        {
            return chatroomService.GetLatestMessages(chatroomId);
        }

        [HttpPost("{chatroomId}")]
        public ActionResult PostMessage(Guid chatroomId, [FromBody] string text)
        {
            return Ok(chatroomService.PostMessage(text, chatroomId));
        }
    }
}