using Xunit;
using Moq;
using Moq.Protected;
using Brukerfeil.Enode.Repositories;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System;
using Brukerfeil.Enode.Common.Models;
namespace Brukerfeil.Enode.Tests.RepositoryTests
{
    public class ElementsMessageRepositoryTest
    {
        private readonly string ALL_INCOMING_MESSAGES_URI = "https://app01master.elements-ecm.no/ncore_master/odata/SenderRecipient?$filter= CreatedDate ge 2019-03-05T15:13:52.1064904Z and IsRecipient eq true and ConversationId ne null &$expand=SendingMethod,SendingStatus&$top=100&$orderby=CreatedDate desc&Database=MASTER_SQL&ExternalSystemName=ephorte5DocDelivery&";
        private readonly string ALL_OUTGOING_MESSAGES_URI = "https://app01master.elements-ecm.no/ncore_master/odata/SenderRecipient?$filter= CreatedDate ge 2019-03-05T15:13:52.1064904Z and IsRecipient eq true and ConversationId ne false &$expand=SendingMethod,SendingStatus&$top=100&$orderby=CreatedDate desc&Database=MASTER_SQL&ExternalSystemName=ephorte5DocDelivery&";
        
        [Fact]
        public async void TestAllIncomingElementsMessagesNotNullAsync()
        {
        //Arrange
        var mockElementsMessageHandler = new Mock<HttpMessageHandler>();

        mockElementsMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
                {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"value\": [{\"IsRecipient\": \"true\"}]}"),
            })
            .Verifiable();

        var httpClient = new HttpClient(mockElementsMessageHandler.Object)
        {
            BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),
        };
        var messageRepository = new ElementsMessageRepository(httpClient);

        //Act
        var actual = await messageRepository.GetAllIncomingElementsMessagesAsync();

        //Assert
        mockElementsMessageHandler.Verify();
        Assert.NotNull(actual);

        }

        [Fact]
        public async void TestAllIncomingElementsMessagesTypeAsync()
        {
            //Arrange
            var mockElementsMessageHandler = new Mock<HttpMessageHandler>();

            mockElementsMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"value\": [{\"IsRecipient\": \"true\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockElementsMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),
            };
            var messageRepository = new ElementsMessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllIncomingElementsMessagesAsync();

            //Assert
            mockElementsMessageHandler.VerifyAll();
            foreach (var message in actual)
            {
                Assert.IsType<SenderRecipient>(message);
            }
        }

        [Fact]
        public async void TestAllIncomingElementsMessagesDirectionAsync()
        {
            //Arrange
            var mockElementsMessageHandler = new Mock<HttpMessageHandler>();

            mockElementsMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"value\": [{\"IsRecipient\": \"true\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockElementsMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),
            };
            var messageRepository = new ElementsMessageRepository(httpClient);
            var expectedUri = new Uri(ALL_INCOMING_MESSAGES_URI);

            //Act
            var actual = await messageRepository.GetAllIncomingElementsMessagesAsync();

            //Assert
            mockElementsMessageHandler.VerifyAll();
            mockElementsMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get
                && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );
            foreach (var message in actual)
            {
                Assert.True(message.IsRecipient);
            }
        }

        [Fact]
        public async void TestAllOutgoingElementsMessagesNotNullAsync()
        {
            //Arrange
            var mockElementsMessageHandler = new Mock<HttpMessageHandler>();

            mockElementsMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"value\": [{\"IsRecipient\": \"false\"}]}"),
            })
            .Verifiable();

            var httpClient = new HttpClient(mockElementsMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new ElementsMessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllOutgoingElementsMessagesAsync();

            //Assert
            mockElementsMessageHandler.VerifyAll();
            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestAllOutgingElementsMessagesTypeAsync()
        {
            //Arrange
            var mockElementsMessageHandler = new Mock<HttpMessageHandler>();

            mockElementsMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"value\": [{\"IsRecipient\": \"false\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockElementsMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new ElementsMessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllOutgoingElementsMessagesAsync();

            //Assert
            mockElementsMessageHandler.VerifyAll();
            foreach (var message in actual)
            {
                Assert.IsType<SenderRecipient>(message);
            }
        }

            [Fact]
        public async void TestAllOutgoingElementsMessagesDirectionAsync()
        {
            //Arrange
            var mockElementsMessageHandler = new Mock<HttpMessageHandler>();
            
            mockElementsMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"value\": [{\"IsRecipient\": \"false\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockElementsMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new ElementsMessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllOutgoingElementsMessagesAsync();
            mockElementsMessageHandler.VerifyAll();
            foreach (var message in actual)
            {
                Assert.False(message.IsRecipient);
            }
        }
    }
    
}

