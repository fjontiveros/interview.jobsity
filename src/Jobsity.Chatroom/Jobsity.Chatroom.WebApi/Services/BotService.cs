using Jobsity.Chatroom.Common;

namespace Jobsity.Chatroom.WebApi.Services
{
    public class BotService : IBotService
    {
        private readonly IMessageProducer messageProducer;

        public BotService(IMessageProducer messageProducer)
        {
            this.messageProducer = messageProducer;
        }
        public Guid SendCommand(string command, Guid chatroomId)
        {
            var guid = Guid.NewGuid();
            messageProducer.SendMessage(
                new Command
                {
                    Id = guid,
                    Text = command,
                    ChatroomId = chatroomId
                }
            );
            return guid;
        }
    }
}
