using CsvHelper;
using System.Globalization;

namespace Jobsity.Chatroom.Bot.Services
{
    public class StooqClient : IStooqClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public StooqClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }
        public async Task<StooqRecord> GetFirstRecord(string symbol)
        {
            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync(string.Format(configuration["StooqUrl"], symbol));

            StooqRecord result = null;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                TextReader tr = new StreamReader(contentStream);
                using (var csv = new CsvReader(tr, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StooqRecord>();
                    result = records.First();
                }
            }

            return result;
        }
    }
}