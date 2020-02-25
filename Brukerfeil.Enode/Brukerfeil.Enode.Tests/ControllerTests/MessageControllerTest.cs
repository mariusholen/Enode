using Xunit;
using Moq;
using Brukerfeil.Enode.API.Controllers;
using Brukerfeil.Enode.Common.Repositories;
using Brukerfeil.Enode.Common.Models;
using System.Collections.Generic;
using Brukerfeil.Enode.Common.Services;
using System;

namespace Brukerfeil.Enode.Tests
{
    public class MessageControllerTest
    {
        [Fact]
        public async void TestAllIncomingMessageNotNullAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();
            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestOrgIncomingMessageNotNullAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            Assert.NotNull(actual);

        }
        
        [Fact]
        public async void TestAllOutgoingMessageNotNullAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllOutgoingMessagesAsync())
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestOrgOutgoingMessageNotNullAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            Assert.NotNull(actual);

        }
        
        [Fact]
        public async void TestAllIncomingMessageTypeAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.IsType<Message>(message);
            }
        }

        [Fact]
        public async void TestOrgIncomingMessageTypeAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.IsType<Message>(message);
            }
        }
        
        [Fact]
        public async void TestAllOutgoingMessageTypeAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllOutgoingMessagesAsync())
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.IsType<Message>(message);
            }
        }

        [Fact]
        public async void TestOrgOutgoingMessageTypeAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.IsType<Message>(message);
            }
        }
        
        [Fact]
        public async void TestAllIncomingMessageDirectionAsync()
        {

            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "INCOMING";

            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(message.direction, expectedDirection);
            }    
        }

        [Fact]
        public async void TestOrgIncomingMessageDirectionAsync()
        {

            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "INCOMING";

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(message.direction, expectedDirection);
            }
        }
        
        [Fact]
        public async void TestAllOutgoingMessageDirectionAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllOutgoingMessagesAsync())
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "OUTGOING";

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert

            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(message.direction, expectedDirection);
            } 
        }

        [Fact]
        public async void TestOrgOutgoingMessageDirectionAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "OUTGOING";

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert

            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(message.direction, expectedDirection);
            }
        }

        [Fact]
        public async void TestOrgIncomingMessageReceiverIdentifierAsync()
        {

            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(receiverIdentifier, message.receiverIdentifier);
            }
        }

        [Fact]
        public async void TestOrgOutgoingMessageSenderIdentifierAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<Message>>()), Times.Once());

            foreach (var message in actual)
            {
                Assert.Equal(senderIdentifier, message.senderIdentifier);
            }
        }

        [Fact]
        public async void TestAllMessagesBySenderIdNotNullAsync()
        {
            //Arrange
            var senderId = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesBySenderIdAsync(senderId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesBySenderIdAsync(senderId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesBySenderIdAsync(senderId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestAllMessagesBySenderIdTypeAsync()
        {
            //Arrange
            var senderId = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesBySenderIdAsync(senderId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesBySenderIdAsync(senderId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesBySenderIdAsync(senderId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.IsType<List<Message>>(actual);
        }

        [Fact]
        public async void TestAllMessagesBySenderIdCorrectResultAsync()
        {
            //Arrange
            var senderId = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesBySenderIdAsync(senderId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesBySenderIdAsync(senderId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesBySenderIdAsync(senderId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(senderId, content.senderIdentifier);
            }
        }

        [Fact]
        public async void TestAllMessagesByReceiverIdNotNullAsync()
        {
            //Arrange
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesByReceiverIdAsync(receiverId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesByReceiverIdAsync(receiverId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesByReceiverIdAsync(receiverId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestAllMessagesByReceiverIdTypeAsync()
        {
            //Arrange
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesByReceiverIdAsync(receiverId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesByReceiverIdAsync(receiverId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesByReceiverIdAsync(receiverId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.IsType<List<Message>>(actual);
        }
    

        [Fact]
        public async void TestAllMessagesByReceiverIdCorrectResultAsync()
        {
            //Arrange
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllMessagesByReceiverIdAsync(receiverId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesByReceiverIdAsync(receiverId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesByReceiverIdAsync(receiverId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(receiverId, content.receiverIdentifier);
            }
        }

        [Fact]
        public async void TestOrgMessagesBySenderNotNullAsync()
        {
            //Arrange
            var senderId = "987464291";
            var organizationId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesBySenderIdAsync(senderId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestOrgMessagesBySenderIdWithOrgTypeAsync()
        {
            //Arrange
            var senderId = "987464291";
            var organizationId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesBySenderIdAsync(senderId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.IsType<List<Message>>(actual);
        }

        [Fact]
        public async void TestOrgMessagesBySenderIdWithOrgExpectedSenderAsync()
        {
            //Arrange
            var senderId = "987464291";
            var organizationId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesBySenderIdAsync(senderId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(senderId, content.senderIdentifier);
            }
        }
        
        [Fact]
        public async void TestOrgMessagesBySenderIdWithOrgExpectedReceiverAsync()
        {
            //Arrange
            var senderId = "987464291";
            var organizationId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesBySenderIdAsync(senderId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(organizationId, content.receiverIdentifier);
            }
        }

        [Fact]
        public async void TestOrgMessagesByReceiverIdNotNullAsync()
        {
            //Arrange
            var organizationId = "987464291";
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestOrgMessagesByReceiverIdTypeAsync()
        {
            //Arrange
            var organizationId = "987464291";
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.IsType<List<Message>>(actual);
        }


        [Fact]
        public async void TestOrgMessagesByReceiverIdExpectedReceiverAsync()
        {
            //Arrange
            var organizationId = "987464291";
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(receiverId, content.receiverIdentifier);
            }
        }

        [Fact]
        public async void TestOrgMessagesByReceiverIdExpectedSenderAsync()
        {
            //Arrange
            var organizationId = "987464291";
            var receiverId = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId))
            .ReturnsAsync(GetMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<Message>>()))
                .Returns<List<Message>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual)
            {
                Assert.Equal(organizationId, content.senderIdentifier);
            }
        }
        private IEnumerable<Message> GetIncomingMessageObject()
        {
            var incomingMessage = new List<Message>
            {
                new Message
                {
                    lastUpdate = DateTime.Now,
                    receiverIdentifier = "987464291",
                    direction = "INCOMING",
                }
            };

            return incomingMessage;
        }

        private IEnumerable<Message> GetOutgoingMessageObject()
        {

            var outgoingMessage = new List<Message>
            {
                new Message
                {
                    lastUpdate = DateTime.Now,
                    senderIdentifier = "989778471",
                    direction = "OUTGOING",
                }
            };
            return outgoingMessage;
        }

        private List<Message> GetMessageObject()
        {

            var messageObject = new List<Message>
            {
                new Message
                {
                    id = 11,
                    conversationId = "40c8ccb8-aed8-4e1f-b87e-e27c0895813d",
                    senderIdentifier = "987464291",
                    receiverIdentifier = "989778471",
                },
                new Message
                {
                    id = 22,
                    conversationId = "40c8ccb8-aed8-4e1f-b87e-e27c0895813d",
                    senderIdentifier = "987464291",
                    receiverIdentifier = "989778471",
                }
            };
            return messageObject;
        }
    }
}
 