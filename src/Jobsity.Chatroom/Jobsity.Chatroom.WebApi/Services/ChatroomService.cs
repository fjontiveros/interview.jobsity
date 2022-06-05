using Jobsity.Chatroom.WebApi.Exceptions;
using Jobsity.Chatroom.WebApi.Model;
using System.Text.RegularExpressions;

namespace Jobsity.Chatroom.WebApi.Services
{

    public class ChatroomService : IChatroomService
    {
        private readonly IChatroomRepository chatroomRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ISessionService sessionService;
        private readonly Regex commandRegex = new Regex("[/stock](\\w)+");

        public ChatroomService(IChatroomRepository chatroomRepository, 
            IMessageRepository messageRepository,
            ISessionService sessionService)
        {
            this.chatroomRepository = chatroomRepository;
            this.messageRepository = messageRepository;
            this.sessionService = sessionService;
        }

        public IEnumerable<Model.Chatroom> GetAllChatRooms()
        {
            return chatroomRepository.GetAllChatRooms();
        }

        public Model.Chatroom GetChatroom(Guid chatroomId)
        {
            return chatroomRepository.GetChatroom(chatroomId);
        }

        public IEnumerable<Message> GetLatestMessages(Guid chatroomId)
        {
            return messageRepository.GetLatestMessages(chatroomId);
        }

        public Guid PostMessage(string text, Guid chatroomId)
        {
            var messageId = Guid.NewGuid();

            var chatroom = this.GetChatroom(chatroomId);
            if(chatroom == null)
            {
                throw new BusinessRulesException($"Chatroom id {chatroomId} is not a valid id");
            }

            var user = sessionService.GetCurrentUser();
            if(user == null)
            {
                throw new BusinessRulesException($"User must be logged in to send messages");
            }

            if (IsACommand(text))
            {
                return EnqueueCommand(text);
            }
            else
            {
                return SaveMessage(text, chatroomId, messageId, user);
            }
        }

        private Guid EnqueueCommand(string text)
        {
            var command = new Regex("[^=]*(\\w)*$").Match(text).Value;
            return Guid.Empty;
        }

        private bool IsACommand(string text)
        {
            return new Regex("/stock=(\\w)+").IsMatch(text);
        }

        private Guid SaveMessage(string text, Guid chatroomId, Guid messageId, User user)
        {
            var message = new Message
            {
                Id = messageId,
                TimeStamp = DateTime.Now,
                Text = text,
                Chatroom = this.GetChatroom(chatroomId),
                User = user
            };
            return messageRepository.PostMessage(message);
        }
    }
}
