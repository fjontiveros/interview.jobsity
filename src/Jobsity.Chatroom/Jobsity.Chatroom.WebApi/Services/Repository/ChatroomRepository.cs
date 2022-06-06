using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services.Repository
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
            return applicationContext.Chatrooms.ToList();
        }

        public Model.Chatroom GetChatroom(Guid chatroomId)
        {
            return applicationContext.Chatrooms.FirstOrDefault(x => x.Id == chatroomId);
        }
    }
}
