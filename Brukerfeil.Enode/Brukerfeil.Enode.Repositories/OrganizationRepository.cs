using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;


namespace Brukerfeil.Enode.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public const string _URL = "https://jsonplaceholder.typicode.com/users";
        public HttpClient Client;

        public OrganizationRepository(HttpClient client)
        {
            Client = client;
        }


        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, _URL);
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Organization>>(responseStream);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return null;
            }
        }


        public async Task<Organization> GetOrganization(int id)
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}/{id}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Organization>(responseStream);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                return null;
            }
        }
    }
}