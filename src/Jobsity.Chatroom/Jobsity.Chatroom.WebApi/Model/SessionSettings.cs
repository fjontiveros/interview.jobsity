using System.ComponentModel.DataAnnotations.Schema;

namespace Jobsity.Chatroom.WebApi.Model
{
    [NotMapped]
    public class SessionSettings
    {
        public string Audience { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
    }
}
