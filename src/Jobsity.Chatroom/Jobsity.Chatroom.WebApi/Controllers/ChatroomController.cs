using Jobsity.Chatroom.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobsity.Chatroom.WebApi.Controllers
{
    public class ChatroomController : BaseController
    {

        private readonly ILogger<ChatroomController> logger;
        private readonly IChatroomRepository chatroomRepository;

        public ChatroomController(ILogger<ChatroomController> logger,
            IChatroomRepository chatroomRepository)
        {
            this.logger = logger;
            this.chatroomRepository = chatroomRepository;
        }

        [HttpGet]
        public IEnumerable<Model.Chatroom> Get()
        {
            return chatroomRepository.GetAllChatRooms();
        }

        [HttpGet("{id}")]
        public ActionResult<Model.Chatroom> Get(Guid id)
        {
            var result = chatroomRepository.GetChatroom(id);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}