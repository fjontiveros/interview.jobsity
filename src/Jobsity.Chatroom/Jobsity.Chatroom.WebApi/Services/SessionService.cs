using Jobsity.Chatroom.WebApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Jobsity.Chatroom.WebApi.Services
{
    public class SessionService : ISessionService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SessionSettings sessionSettings;

        public SessionService(ApplicationContext applicationContext,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            this.applicationContext = applicationContext;
            this.httpContextAccessor = httpContextAccessor;
            var sessionSettingsSection = configuration.GetSection("SessionSettings");
            this.sessionSettings = new SessionSettings
            {
                Audience = sessionSettingsSection.GetValue<string>("Audience"),
                Secret = sessionSettingsSection.GetValue<string>("Secret"),
                Issuer = sessionSettingsSection.GetValue<string>("Issuer"),
            };
        }

        public string Authenticate(string userName, string password)
        {
            var hashedPassword = this.HashPassword(password);
            if (this.applicationContext.Users.Any(x => x.Name == userName && x.Password == hashedPassword))
            {
                var claims = new[]
                {
                    new Claim("userName", userName)
                };

                var secretBytes = Encoding.UTF8.GetBytes(this.sessionSettings.Secret);

                var securityKey = new SymmetricSecurityKey(secretBytes);

                var algorithm = SecurityAlgorithms.HmacSha256;

                var signinCredentials = new SigningCredentials(securityKey, algorithm);

                var token = new JwtSecurityToken(
                        this.sessionSettings.Issuer,
                        this.sessionSettings.Audience,
                        claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signinCredentials
                        );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return string.Empty;
        }

        public User GetCurrentUser()
        {
            if (httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == "userName"))
            {
                var loggedUser = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "userName").Value;
                return applicationContext.Users.First(x => x.Name == loggedUser);
            }
            return null;
        }

        public string HashPassword(string password)
        {
            var salt = Encoding.ASCII.GetBytes("kaiqKAS65112-1kl");

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
