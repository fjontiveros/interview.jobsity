using System.ComponentModel.DataAnnotations;

namespace Jobsity.Chatroom.WebApi.Model
{
    public class Message
    {
        public Guid Id { get; set; }
        [Required]
        public virtual Chatroom Chatroom { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
