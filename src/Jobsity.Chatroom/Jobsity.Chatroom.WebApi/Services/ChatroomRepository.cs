using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services
{
    public class ChatroomRepository : IChatroomRepository
    {
        private readonly ApplicationContext applicationContext;

        public ChatroomRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public IEnumerable<Model.Chatroom> GetAllChatRooms()
        {
            return this.applicationContext.Chatrooms;
        }

        public Model.Chatroom GetChatroom(Guid chatroomId)
        {
            return this.applicationContext.Chatrooms.FirstOrDefault(x => x.Id == chatroomId);
        }
    }
}
