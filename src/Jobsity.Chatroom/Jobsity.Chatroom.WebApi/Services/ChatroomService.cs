using Jobsity.Chatroom.WebApi.Exceptions;
using Jobsity.Chatroom.WebApi.Hubs;
using Jobsity.Chatroom.WebApi.Model;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Jobsity.Chatroom.WebApi.Services
{

    public class ChatroomService : IChatroomService
    {
        private readonly IChatroomRepository chatroomRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ISessionService sessionService;
        private readonly IBotService botService;
        private readonly IHubContext<ChatHub> hubcontext;

        public ChatroomService(IChatroomRepository chatroomRepository, 
            IMessageRepository messageRepository,
            ISessionService sessionService,
            IBotService botService,
            IHubContext<ChatHub> hubcontext)
        {
            this.chatroomRepository = chatroomRepository;
            this.messageRepository = messageRepository;
            this.sessionService = sessionService;
            this.botService = botService;
            this.hubcontext = hubcontext;
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

        public async Task<Guid> PostMessage(string text, Guid chatroomId)
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
                return await SaveMessage(text, chatroomId, messageId, user);
            }
        }

        private Guid EnqueueCommand(string text)
        {
            var command = new Regex("[^=]*(\\w)*$").Match(text).Value;
            this.botService.SendCommand(command);
            return Guid.Empty;
        }

        private bool IsACommand(string text)
        {
            return new Regex("/stock=(\\w)+").IsMatch(text);
        }

        private async Task<Guid> SaveMessage(string text, Guid chatroomId, Guid messageId, User user)
        {
            var message = new Message
            {
                Id = messageId,
                TimeStamp = DateTime.Now,
                Text = text,
                Chatroom = this.GetChatroom(chatroomId),
                User = user
            };

            await hubcontext.Clients.All.SendAsync("ReceiveMessage", sessionService.GetCurrentUser().Name, text);

            return messageRepository.PostMessage(message);
        }
    }
}
