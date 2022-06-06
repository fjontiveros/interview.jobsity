namespace Jobsity.Chatroom.Bot.Services
{
    public interface IStooqClient
    {
        public Task<StooqRecord> GetFirstRecord(string symbol);
    }
}