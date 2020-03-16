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
using System.Collections.Generic;

namespace Brukerfeil.Enode.Tests
{
    public class MessageRepositoryTest
    {
        private readonly string ALL_INCOMING_MESSAGES_URI = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100&direction=INCOMING";
        private readonly string ORG_INCOMING_MESSAGES_URI = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100&direction=INCOMING&receiverIdentifier=987464291";
        private readonly string ALL_OUTGOING_MESSAGES_URI = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100&direction=OUTGOING";
        private readonly string ORG_OUTGOING_MESSAGES_URI = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100&direction=OUTGOING&senderIdentifier=989778471";

        private static string _baseUri = "https://ip-leik-meldingsutveksling.difi.no/api/conversations?size=100";
        private static string _senderId = "987464291";
        private static string _receiverId = "989778471";
        private static string _senderPath = $"{_baseUri}&senderIdentifier={_senderId}";
        private static string _senderAndOrgPath = $"{_baseUri}&senderIdentifier={_senderId}&receiverIdentifier={_receiverId}";
        private static string _receiverPath = $"{_baseUri}&receiverIdentifier={_receiverId}";
        private static string _receiverAndOrgPath = $"{_baseUri}&receiverIdentifier={_receiverId}&senderIdentifier={_senderId}";


        [Fact]
        public async void TestAllIncomingMessageNotNullAsync()
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
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllIncomingMessagesAsync();

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
           
        }

        [Fact]
        public async void TestOrgIncomingMessageNotNullAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\",\"receiverIdentifier\": \"987464291\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_INCOMING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgIncomingMessagesAsync(receiverIdentifier);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }
        
        [Fact]
        public async void TestAllOutgoingMessageNotNullAsync()
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\"}]}"),
            })
            .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllOutgoingMessagesAsync();

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestOutgoingMessageNotNullAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\", \"senderIdentifier\": \"989778471\"}]}"),
            })
            .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_OUTGOING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgOutgoingMessagesAsync(senderIdentifier);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }
        
        [Fact]
        public async void TestAllIncomingMessageTypeAsync()
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
                Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\"}]}"),
            })
            .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllIncomingMessagesAsync();

            //Assert
            mockMessageHandler.VerifyAll();
            foreach (var message in actual)
            {
                Assert.IsType<DifiMessage>(message);
            }
            
        }

        [Fact]
        public async void TestOrgIncomingMessageTypeAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\",\"receiverIdentifier\": \"987464291\"}]}"),
                })
                .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_INCOMING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgIncomingMessagesAsync(receiverIdentifier);

            //Assert
            mockMessageHandler.VerifyAll();
            foreach (var message in actual)
            {
                Assert.IsType<DifiMessage>(message);
            }

        }
        
        [Fact]
        public async void TestAllOutgoingMessageTypeAsync()
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\"}]}"),
                })
                .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllOutgoingMessagesAsync();

            //Assert
            mockMessageHandler.VerifyAll();

            foreach (var message in actual)
            {
                Assert.IsType<DifiMessage>(message);
            }
        }

        [Fact]
        public async void TestOrgOutgoingMessageTypeAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\", \"senderIdentifier\": \"989778471\"}]}"),
                })
                .Verifiable();
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_OUTGOING_MESSAGES_URI),

            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgOutgoingMessagesAsync(senderIdentifier);

            //Assert
            mockMessageHandler.VerifyAll();

            foreach (var message in actual)
            {
                Assert.IsType<DifiMessage>(message);
            }
        }

        [Fact]
        public async void TestAllIncomingMessageDirectionAsync()
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
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_INCOMING_MESSAGES_URI),

            };

            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ALL_INCOMING_MESSAGES_URI);

            //Act
            var actual = await messageRepository.GetAllIncomingMessagesAsync();

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get
                && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var message in actual)
            {
                Assert.Equal("INCOMING", message.direction);
            }
        }

        [Fact]
        public async void TestOrgIncomingMessageDirectionAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\",\"receiverIdentifier\": \"987464291\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_INCOMING_MESSAGES_URI),

            };

            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ORG_INCOMING_MESSAGES_URI);

            //Act
            var actual = await messageRepository.GetOrgIncomingMessagesAsync(receiverIdentifier);

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get
                && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var message in actual)
            {
                Assert.Equal("INCOMING",message.direction);
            }
        }
        

        [Fact]
        public async void TestAllOutgoingMessageDirectionAsync()
        {
        //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\"}]}"),
                })
                .Verifiable();


            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ALL_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ALL_OUTGOING_MESSAGES_URI);
            string expectedDirection = "OUTGOING";

            //Act
            var actual = await messageRepository.GetAllOutgoingMessagesAsync();

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

                foreach (var message in actual)
            {
                Assert.Equal(expectedDirection, message.direction);
            }
        }

        [Fact]
        public async void TestOrgOutgoingMessageDirectionAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\", \"senderIdentifier\": \"989778471\"}]}"),
                })
                .Verifiable();


            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ORG_OUTGOING_MESSAGES_URI);
            string expectedDirection = "OUTGOING";

            //Act
            var actual = await messageRepository.GetOrgOutgoingMessagesAsync(senderIdentifier);

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var message in actual)
            {
                Assert.Equal(expectedDirection, message.direction);
            }
        }

        [Fact]
        public async void TestOrgIncomingMessageReceiverIdentifierAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"INCOMING\",\"receiverIdentifier\": \"987464291\"}]}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_INCOMING_MESSAGES_URI),

            };

            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ORG_INCOMING_MESSAGES_URI);

            //Act
            var actual = await messageRepository.GetOrgIncomingMessagesAsync(receiverIdentifier);

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get
                && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var message in actual)
            {
                Assert.Equal(receiverIdentifier,message.receiverIdentifier);
            }
        }

        [Fact]
        public async void TestOrgOutgoingMessageSenderIdentifierAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"content\": [{\"direction\": \"OUTGOING\", \"senderIdentifier\": \"989778471\"}]}"),
                })
                .Verifiable();


            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(ORG_OUTGOING_MESSAGES_URI),
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(ORG_OUTGOING_MESSAGES_URI);

            //Act
            var actual = await messageRepository.GetOrgOutgoingMessagesAsync(senderIdentifier);

            //Assert

            mockMessageHandler.VerifyAll();
            mockMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(request => request.Method == HttpMethod.Get && request.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>()
                );

            foreach (var message in actual)
            {
                Assert.Equal(senderIdentifier, message.senderIdentifier);
            }
        }

        [Fact]
        public async void TestGetMessagesBySenderIdNotNullAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllMessagesBySenderIdAsync(_senderId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetMessagesBySenderIdTypeAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllMessagesBySenderIdAsync(_senderId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.IsType<List<DifiMessage>>(actual);
        }

        [Fact]
        public async void TestGetMessagesBySenderIdContentAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_senderPath);

            //Act
            var actual = await messageRepository.GetAllMessagesBySenderIdAsync(_senderId);

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
                Assert.Equal(content.senderIdentifier, _senderId);
            }
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdNotNullAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllMessagesByReceiverIdAsync(_receiverId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdTypeAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetAllMessagesByReceiverIdAsync(_receiverId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.IsType<List<DifiMessage>>(actual);
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdContentAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_receiverPath);

            //Act
            var actual = await messageRepository.GetAllMessagesByReceiverIdAsync(_receiverId);

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
                Assert.Equal(content.receiverIdentifier, _receiverId);
            }
        }

        [Fact]
        public async void TestGetMessagesBySenderIdWithOrgIdNotNullAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgMessagesBySenderIdAsync(_senderId, _receiverId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetMessagesBySenderIdWithOrgIdTypeAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgMessagesBySenderIdAsync(_senderId, _receiverId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.IsType<List<DifiMessage>>(actual);
        }

        [Fact]
        public async void TestGetMessagesBySenderIdWithOrgIdExpectedSenderAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_senderAndOrgPath);

            //Act
            var actual = await messageRepository.GetOrgMessagesBySenderIdAsync(_senderId, _receiverId);

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
                Assert.Equal(content.senderIdentifier, _senderId);
            }
        }

        [Fact]
        public async void TestGetMessagesBySenderIdWithOrgIdExpectedReceiverAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_senderPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_senderAndOrgPath);

            //Act
            var actual = await messageRepository.GetOrgMessagesBySenderIdAsync(_senderId, _receiverId);

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
                Assert.Equal(content.receiverIdentifier, _receiverId);
            }
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdWithOrgNotNullAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverAndOrgPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgMessagesByReceiverIdAsync(_receiverId, _senderId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdWithOrgTypeAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverAndOrgPath)
            };
            var messageRepository = new MessageRepository(httpClient);

            //Act
            var actual = await messageRepository.GetOrgMessagesByReceiverIdAsync(_receiverId, _senderId);

            //Assert
            mockMessageHandler.VerifyAll();
            Assert.IsType<List<DifiMessage>>(actual);
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdWithOrgIdExpectedReceiverAsync()
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
                    Content = new StringContent("{\"content\": [{\"receiverIdentifier\": \"" + _receiverId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_receiverAndOrgPath);

            //Act
            var actual = await messageRepository.GetOrgMessagesByReceiverIdAsync(_receiverId, _senderId);

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
                Assert.Equal(content.receiverIdentifier, _receiverId);
            }
        }

        [Fact]
        public async void TestGetMessagesByReceiverIdWithOrgIdExpectedSenderAsync()
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
                    Content = new StringContent("{\"content\": [{\"senderIdentifier\": \"" + _senderId + "\"}]}")
                })
                .Verifiable();

            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri(_receiverPath)
            };
            var messageRepository = new MessageRepository(httpClient);
            var expectedUri = new Uri(_receiverAndOrgPath);

            //Act
            var actual = await messageRepository.GetOrgMessagesByReceiverIdAsync(_receiverId, _senderId);

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
                Assert.Equal(content.senderIdentifier, _senderId);
            }
        }

    }
}