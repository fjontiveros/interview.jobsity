namespace Jobsity.Chatroom.WebApi.Services
{
    public class BotService : IBotService
    {
        public Guid SendCommand(string command)
        {
            var guid = Guid.NewGuid();
            return guid;
        }
    }
}
