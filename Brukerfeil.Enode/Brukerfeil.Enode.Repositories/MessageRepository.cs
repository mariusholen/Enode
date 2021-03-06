﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Exceptions;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;

namespace Brukerfeil.Enode.Repositories
{

    public class MessageRepository : IMessageRepository
    {
        private const string _URL = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100";
        public HttpClient Client;

        public MessageRepository(HttpClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<DifiMessage>> GetAllIncomingMessagesAsync()
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&direction=INCOMING");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetOrgIncomingMessagesAsync(string organizationId)
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&direction=INCOMING&receiverIdentifier={organizationId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;

            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetAllOutgoingMessagesAsync()
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&direction=OUTGOING");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetOrgOutgoingMessagesAsync(string organizationId)
        {
            Client.BaseAddress = new Uri(_URL);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&direction=OUTGOING&senderIdentifier={organizationId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetAllMessagesBySenderIdAsync(string senderId)
        {
            Client.BaseAddress = new Uri(_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&senderIdentifier={senderId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetOrgMessagesBySenderIdAsync(string senderId, string organizationId)
        {
            Client.BaseAddress = new Uri(_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&senderIdentifier={senderId}&receiverIdentifier={organizationId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }

        public async Task<IEnumerable<DifiMessage>> GetAllMessagesByReceiverIdAsync(string receiverId)
        {
            Client.BaseAddress = new Uri(_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&receiverIdentifier={receiverId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }
        public async Task<IEnumerable<DifiMessage>> GetOrgMessagesByReceiverIdAsync(string receiverId, string organizationId)
        {
            Client.BaseAddress = new Uri(_URL);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_URL}&receiverIdentifier={receiverId}&senderIdentifier={organizationId}");
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var message = await JsonSerializer.DeserializeAsync<DifiMessageContent>(responseStream);
                return message.content;
            }
            else
            {
                var exx = response.StatusCode.ToString();
                throw new ArgumentException(exx);
            }
        }
    }
}