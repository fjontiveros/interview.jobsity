using Jobsity.Chatroom.Common;

namespace Jobsity.Chatroom.Bot.Services
{
    public interface ICommandProcessor
    {
        Task Process(Command command);
    }
}