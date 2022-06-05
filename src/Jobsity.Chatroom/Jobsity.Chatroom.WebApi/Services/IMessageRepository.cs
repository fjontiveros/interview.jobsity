﻿using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services
{
    public interface IMessageRepository
    {
        public IEnumerable<Message> GetLatestMessages(Guid chatroomId);
        public Guid PostMessage(Message message);
    }
}
