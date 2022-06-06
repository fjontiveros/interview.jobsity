namespace Jobsity.Chatroom.WebApi.Services
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
