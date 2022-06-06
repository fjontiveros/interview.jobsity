namespace Jobsity.Chatroom.Common
{
    public class Command : ICommand
    {
        public Guid Id { get; set; }
        public Guid ChatroomId { get; set; }
        public string Text { get; set; }
    }
}