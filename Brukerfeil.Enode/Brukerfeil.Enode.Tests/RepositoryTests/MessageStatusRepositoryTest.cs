using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Repositories;
using Moq;
using Moq.Protected;
using Xunit;

namespace Brukerfeil.Enode.Tests.MessageStatusTests
{
    public class MessageStatusRepositoryTest
    {
        private string _baseUri { get; set; }
        private string _messageId { get; set; }
        private string _fullPath { get; set; }

        public MessageStatusRepositoryTest()
        {
            _baseUri = "https://ip-leik-meldingsutveksling.difi.no/api/statuses";
            _messageId = "8433e766-abe2-4702-a414-ce7a16672538";
            _fullPath = $"{_baseUri}/{_messageId}";
        }
        

        [Fact]
        public async void TestGetMessageStatusNotNullAsync()
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"messageId\": \"" + _messageId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_fullPath)
            };
            var messageStatusRepository = new MessageStatusRepository(httpClient);

            //Act
            var actual = await messageStatusRepository.GetMessageStatusAsync(_messageId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetMessageStatusIsTypeAsync()
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"messageId\": \"" + _messageId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_fullPath)
            };
            var messageStatusRepository = new MessageStatusRepository(httpClient);

            //Act
            var actual = await messageStatusRepository.GetMessageStatusAsync(_messageId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.IsType<List<MessageStatus>>(actual);
        }

        [Fact]
        public async void TestGetMessageStatusContentAsync()
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"messageId\": \"" + _messageId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_fullPath)
            };

            var messageStatusRepository = new MessageStatusRepository(httpClient);
            var expectedUri = new Uri(_fullPath);

            //Act
            var actual = await messageStatusRepository.GetMessageStatusAsync(_messageId);

            //Assert
            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get
                && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var content in actual)
            {
                Assert.Equal(content.messageId, _messageId);
            }
        }
    }
}