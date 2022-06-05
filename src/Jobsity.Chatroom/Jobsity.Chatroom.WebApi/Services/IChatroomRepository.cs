namespace Jobsity.Chatroom.WebApi.Services
{
    public interface IChatroomRepository
    {
        public Model.Chatroom GetChatroom(Guid chatroomId);
        public IEnumerable<Model.Chatroom> GetAllChatRooms();
    }
}
