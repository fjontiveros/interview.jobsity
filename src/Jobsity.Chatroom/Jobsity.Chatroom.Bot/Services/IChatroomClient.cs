namespace Jobsity.Chatroom.Bot.Services
{
    public interface IChatroomClient
    {
        public Task<Guid> PostMessageAsync(string message, Guid chatroomId);
    }
}