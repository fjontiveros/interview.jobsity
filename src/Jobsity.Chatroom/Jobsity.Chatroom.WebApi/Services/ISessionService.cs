using Jobsity.Chatroom.WebApi.Model;

namespace Jobsity.Chatroom.WebApi.Services
{
    public interface ISessionService
    {
        User GetCurrentUser();
        string Authenticate(string userName, string password);
        string HashPassword(string password);
    }
}
