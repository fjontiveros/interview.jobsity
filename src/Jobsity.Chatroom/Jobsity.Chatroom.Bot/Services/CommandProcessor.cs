using CsvHelper;
using Jobsity.Chatroom.Common;
using System.Globalization;

namespace Jobsity.Chatroom.Bot.Services
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IChatroomClient chatroomClient;
        private readonly IStooqClient stooqClient;

        public CommandProcessor(IChatroomClient chatroomClient,
            IStooqClient stooqClient)
        {
            this.chatroomClient = chatroomClient;
            this.stooqClient = stooqClient;
        }

        public async Task Process(Command command)
        {
            var stooqRecord = await stooqClient.GetFirstRecord(command.Text);
            await this.chatroomClient.PostMessageAsync($"{stooqRecord.Symbol} quote is {stooqRecord.High} per share", command.ChatroomId);
        }
    }
}