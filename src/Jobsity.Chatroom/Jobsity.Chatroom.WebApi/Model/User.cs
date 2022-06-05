using System.ComponentModel.DataAnnotations;

namespace Jobsity.Chatroom.WebApi.Model
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
