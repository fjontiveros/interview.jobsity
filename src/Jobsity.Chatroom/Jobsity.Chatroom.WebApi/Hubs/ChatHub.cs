using Jobsity.Chatroom.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;
using System.Text;

namespace Jobsity.Chatroom.WebApi.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatroomService chatroomService;

        public ChatHub(IChatroomService chatroomService)
        {
            this.chatroomService = chatroomService;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(Guid chatroomId, string message)
        {
            await chatroomService.PostMessage(message, chatroomId);
        }
    }

}
