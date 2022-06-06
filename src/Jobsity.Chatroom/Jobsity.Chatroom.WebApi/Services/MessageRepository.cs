using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext context;

        public MessageRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Message> GetLatestMessages(Guid chatroomId)
        {
            return context.Messages
                            .Where(x => x.Chatroom.Id == chatroomId)
                            .OrderByDescending(x => x.TimeStamp)
                            .Take(50)
                            .ToList();
        }

        public Guid PostMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return message.Id;
        }
    }
}
