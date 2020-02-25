using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;

namespace Brukerfeil.Enode.Repositories
{
    public class MessageStatusRepository : IMessageStatusRepository
    {
        private const string _URL = "https://ip-leik-meldingsutveksling.difi.no/api/statuses";
        public HttpClient Client;

        public MessageStatusRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<MessageStatus>> GetMessageStatusAsync(string messageId)
        {
            Client.BaseAddress = new Uri(_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}/{messageId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var messageStatus = await JsonSerializer.DeserializeAsync<MessageStatusContent>(responseStream);
                return messageStatus.content;
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return null;
            }
        }
    }
}