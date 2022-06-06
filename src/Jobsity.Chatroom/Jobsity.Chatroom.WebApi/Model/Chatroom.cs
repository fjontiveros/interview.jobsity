using System.ComponentModel.DataAnnotations;

namespace Jobsity.Chatroom.WebApi.Model
{
    public class Chatroom
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
