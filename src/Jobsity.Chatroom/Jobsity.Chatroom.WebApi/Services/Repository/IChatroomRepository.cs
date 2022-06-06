namespace Jobsity.Chatroom.WebApi.Services.Repository
{
    public interface IChatroomRepository
    {
        public Model.Chatroom GetChatroom(Guid chatroomId);
        public IEnumerable<Model.Chatroom> GetAllChatRooms();
    }
}
