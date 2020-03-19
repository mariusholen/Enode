using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;
using Newtonsoft.Json;
using Brukerfeil.Enode.Common;


namespace Brukerfeil.Enode.Repositories
{
    public class ElementsMessageRepository : IElementsMessageRepository
    {
        private const string _URL = "https://svc01master.elements-ecm.no/ncore_master/odata/SenderRecipient";
        public HttpClient Client;

        public ElementsMessageRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<ElementsMessage>> GetAllIncomingElementsMessagesAsync()
        {
            //Create an instance of ApiDict, then use APIs.Dictionary with an Org.ID, and URI to the dezired API
            //Elements
            var APIs = new ApiDict().Dictionary["922308055"];
            var sikriDifi = APIs.DifiApi;
            var sikriElements =APIs.ElementsApi;

            //Gecko
            //var APIs = new ApiDict().Dictionary["989778471"];
            //var geckoDifi = APIs.DifiApi;
            //var geckoElements = APIs.ElementsApi;

            var thisDate = DateTime.UtcNow;
            var dateString = thisDate.ToString("O");

            var byteArray = Encoding.ASCII.GetBytes("SVC_KS_SI:gMw4dsd3tJA2S25M");
            Client.BaseAddress = new Uri(_URL);
            Client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=none");
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            
            var request = new HttpRequestMessage(
                HttpMethod.Get, $"{_URL}?$filter= CreatedDate ge {dateString} and ConversationId ne null &$expand=SendingMethod,SendingStatus&$top=200&$orderby=CreatedDate desc&Database={sikriElements}&ExternalSystemName=ephorte5DocDelivery&");

            var response = await Client.SendAsync(request);
            using (HttpContent content = response.Content)


            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var senderRecipient = JsonConvert.DeserializeObject<ElementsMessageContent>(responseStream);
                return senderRecipient.value;

            }
            else
            {
            var exx = response.StatusCode.ToString();
            throw new ArgumentException(exx);
            }

        }

    public async Task<IEnumerable<ElementsMessage>> GetAllOutgoingElementsMessagesAsync()
    {
        var thisDate = DateTime.UtcNow;
        var dateString = thisDate.ToString("O");
        var byteArray = Encoding.ASCII.GetBytes("SVC_KS_SI:gMw4dsd3tJA2S25M");
        Client.BaseAddress = new Uri(_URL);
        Client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=none");
        Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        var request = new HttpRequestMessage(
            HttpMethod.Get, $"{_URL}?$filter= CreatedDate ge {dateString} and ConversationId ne null and IsRecipient eq false &$expand=SendingMethod,SendingStatus&$top=100&$orderby=CreatedDate desc&Database=MASTER_SQL&ExternalSystemName=ephorte5DocDelivery");

        var response = await Client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var responseStream = await response.Content.ReadAsStringAsync();
            dynamic senderRecipient = JsonConvert.DeserializeObject<ElementsMessageContent>(responseStream);
            return senderRecipient.value;
        }
        else
        {
            var exx = response.StatusCode.ToString();
            throw new ArgumentException(exx);
        }

        }
    }
}


