using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Jobsity.Chatroom.Bot.Services
{
    public class ChatroomClient : IChatroomClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public ChatroomClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        private async Task<string> Login()
        {
            var httpClient = httpClientFactory.CreateClient();
            var userContent = new StringContent(
                JsonSerializer.Serialize(new
                {
                    userName = configuration["ChatroomClientSettings:UserName"],
                    password = configuration["ChatroomClientSettings:Password"]
                }),
                Encoding.UTF8,
                Application.Json);

            var httpResponseMessage = await httpClient.PostAsync($"{configuration["ChatroomClientSettings:BaseUrl"]}/User", userContent);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<Guid> PostMessageAsync(string message, Guid chatroomId)
        {
            var token = await this.Login();

            var httpClient = httpClientFactory.CreateClient();
            var messageContent = new StringContent(
                JsonSerializer.Serialize(message),
                Encoding.UTF8,
                Application.Json);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var httpResponseMessage = await httpClient.PostAsync($"{configuration["ChatroomClientSettings:BaseUrl"]}/Message/{chatroomId}", messageContent);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();

                return Guid.Parse(JsonSerializer.Deserialize<string>(contentStream));
            }
            return Guid.Empty;
        }
    }
}