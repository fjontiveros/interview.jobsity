namespace Jobsity.Chatroom.WebApi.Services
{
    public interface IBotService
    {
        public Guid SendCommand(string command, Guid chatroomId);

    }
}
