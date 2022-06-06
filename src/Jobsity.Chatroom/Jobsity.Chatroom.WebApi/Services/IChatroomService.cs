using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services
{
    public interface IChatroomService
    {
        public Model.Chatroom GetChatroom(Guid chatroomId);
        public IEnumerable<Model.Chatroom> GetAllChatRooms();
        public Task<Guid> PostMessage(string text, Guid chatroomId);
        IEnumerable<Message> GetLatestMessages(Guid chatroomId);
    }
}
