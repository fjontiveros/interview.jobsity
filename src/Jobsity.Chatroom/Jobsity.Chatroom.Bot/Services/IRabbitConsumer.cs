namespace Jobsity.Chatroom.Bot.Services
{
    public interface IRabbitConsumer
    {
        public void Consume<T>();
    }
}