using Xunit;
using Moq;
using Brukerfeil.Enode.API.Controllers;
using Brukerfeil.Enode.Common.Repositories;
using Brukerfeil.Enode.Common.Models;
using System.Collections.Generic;
using Brukerfeil.Enode.Common.Services;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Brukerfeil.Enode.Tests
{
    public class MessageControllerTest
    {
        [Fact]
        public async void TestAllIncomingMessagesNotNullAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();
            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestOrgIncomingMessagesNotNullAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestAllOutgoingMessagesNotNullAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllOutgoingMessagesAsync())
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestOrgOutgoingMessagesNotNullAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.NotNull(actual);

        }
        [Fact]
        public async void TestAllIncomingMessagesTypeAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.IsType<ActionResult<IEnumerable<DifiMessage>>>(actual);
        }

        [Fact]
        public async void TestOrgIncomingMessagesTypeAsync()
        {
            //Arrange
            var receiverIdentifier = "987464291";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgIncomingMessagesAsync(receiverIdentifier))
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.IsType<ActionResult<IEnumerable<DifiMessage>>>(actual);

        }

        [Fact]
        public async void TestAllOutgoingMessagesTypeAsync()
        {
            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllOutgoingMessagesAsync())
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.IsType<ActionResult<IEnumerable<DifiMessage>>>(actual);

        }

        [Fact]
        public async void TestOrgOutgoingMessagesTypeAsync()
        {
            //Arrange
            var senderIdentifier = "989778471";
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetOrgOutgoingMessagesAsync(senderIdentifier))
            .ReturnsAsync(GetOutgoingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);
            
            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            Assert.IsType<ActionResult<IEnumerable<DifiMessage>>>(actual);

        }

        [Fact]
        public async void TestAllIncomingMessagesDirectionAsync()
        {

            //Arrange
            var mockMessageRepository = new Mock<IMessageRepository>();

            mockMessageRepository.Setup(repository =>
            repository.GetAllIncomingMessagesAsync())
            .ReturnsAsync(GetIncomingMessageObject());

            var mockSortingService = new Mock<ISortingService>();
            mockSortingService.Setup(service =>
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "INCOMING";

            //Act
            var actual = await messageController.GetAllIncomingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetAllIncomingMessagesAsync(), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "INCOMING";

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "OUTGOING";

            //Act
            var actual = await messageController.GetAllOutgoingMessagesAsync(mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert

            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetAllOutgoingMessagesAsync(), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();
            var expectedDirection = "OUTGOING";

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert

            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgIncomingMessagesAsync(receiverIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(e => e.GetOrgIncomingMessagesAsync(receiverIdentifier), Times.Once());
            mockSortingService.Verify(e => e.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgOutgoingMessagesAsync(senderIdentifier, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.VerifyAll();
            mockSortingService.VerifyAll();
            mockMessageRepository.Verify(c => c.GetOrgOutgoingMessagesAsync(senderIdentifier), Times.Once());
            mockSortingService.Verify(service => service.SortMessages(It.IsAny<List<DifiMessage>>()), Times.Once());

            foreach (var message in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesBySenderIdAsync(senderId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesBySenderIdAsync(senderId), Times.Once());
            mockMessageRepository.VerifyAll();

            foreach (var message in actual.Value)
            {
                Assert.IsType<DifiMessage>(message);
            }

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesBySenderIdAsync(senderId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesBySenderIdAsync(senderId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesByReceiverIdAsync(receiverId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesByReceiverIdAsync(receiverId), Times.Once());
            mockMessageRepository.VerifyAll();

            foreach (var message in actual.Value)
            {
                Assert.IsType<DifiMessage>(message);
            }

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetAllMessagesByReceiverIdAsync(receiverId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetAllMessagesByReceiverIdAsync(receiverId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();

            foreach (var message in actual.Value)
            {
                Assert.IsType<DifiMessage>(message);
            }
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesBySenderIdAsync(senderId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesBySenderIdAsync(senderId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            Assert.IsType<ActionResult<IEnumerable<DifiMessage>>>(actual);
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
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
            service.SortMessages(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var mockMessageService = new Mock<IMessageService>();
            mockMessageService.Setup(service =>
            service.LatestStatus(It.IsAny<List<DifiMessage>>()))
                .Returns<List<DifiMessage>>(m => m);

            var messageController = new MessageController();

            //Act
            var actual = await messageController.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId, mockMessageRepository.Object, mockSortingService.Object, mockMessageService.Object);

            //Assert
            mockMessageRepository.Verify(e => e.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId), Times.Once());
            mockMessageRepository.VerifyAll();
            foreach (var content in actual.Value)
            {
                Assert.Equal(organizationId, content.senderIdentifier);
            }
        }

        //    [Fact]
        //    public async void TestGetAllIncmoingElementsMessagesNotNullAsync()
        //    {
        //        //Arrange
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllIncomingElementsMessagesAsync())
        //        .ReturnsAsync(GetIncomingElementsMessagesObject());

        //        var mockElementsValidationService = new Mock<IElementsValidationService>();
        //        mockElementsValidationService.Setup(service =>
        //        service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();
        //        //Act
        //        var actual = await messageController.GetAllIncmoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsValidationService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsValidationService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllIncomingElementsMessagesAsync(), Times.Once());
        //        mockElementsValidationService.Verify(service => service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()), Times.Once());

        //        Assert.NotNull(actual);

        //    }

        //    [Fact]
        //    public async void TestAllIncmoingElementsMessagesTypesAsync()
        //    {
        //        //Arrange
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllIncomingElementsMessagesAsync())
        //        .ReturnsAsync(GetIncomingElementsMessagesObject());

        //        var mockElementsValidationService = new Mock<IElementsValidationService>();
        //        mockElementsValidationService.Setup(service =>
        //        service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();
        //        //Act
        //        var actual = await messageController.GetAllIncmoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsValidationService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsValidationService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllIncomingElementsMessagesAsync(), Times.Once());
        //        mockElementsValidationService.Verify(service => service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()), Times.Once());


        //        foreach (var message in actual.Value)
        //        {
        //            Assert.IsType<SenderRecipient>(message);
        //        }
        //    }

        //    [Fact]
        //    public async void TestGetAllIncomingElementsMessagesDirectionAsync()
        //    {
        //        //Arrange
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllIncomingElementsMessagesAsync())
        //        .ReturnsAsync(GetIncomingElementsMessagesObject());

        //        var mockElementsValidationService = new Mock<IElementsValidationService>();
        //        mockElementsValidationService.Setup(service =>
        //        service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();

        //        //Act
        //        var actual = await messageController.GetAllIncmoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsValidationService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsValidationService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllIncomingElementsMessagesAsync(), Times.Once());
        //        mockElementsValidationService.Verify(service => service.ValidateElementsIncomingMessages(It.IsAny<List<SenderRecipient>>()), Times.Once());

        //        foreach (var elementsMessage in actual.Value)
        //        {
        //            Assert.True(elementsMessage.IsRecipient);
        //        }
        //    }

        //    [Fact]
        //    public async void TestGetAllOutgoingElementsMessagesNotNullAsync()
        //    {
        //        //Arrange   
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllOutgoingElementsMessagesAsync())
        //        .ReturnsAsync(GetOutgoingElementsMessagesObject());

        //        var mockElementsValidationService = new Mock<IElementsValidationService>();
        //        mockElementsValidationService.Setup(service =>
        //        service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();
        //        //Act
        //        var actual = await messageController.GetAllOutgoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsValidationService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsValidationService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllOutgoingElementsMessagesAsync(), Times.Once());
        //        mockElementsValidationService.Verify(service => service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>())); Times.Once();

        //        Assert.NotNull(actual);

        //    }

        //    [Fact]
        //    public async void TestAllOutgoingElementsMessagesTypeAsync()
        //    {
        //        //Arrange
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllOutgoingElementsMessagesAsync())
        //        .ReturnsAsync(GetOutgoingElementsMessagesObject());

        //        var mockElementsValidationService = new Mock<IElementsValidationService>();
        //        mockElementsValidationService.Setup(service =>
        //        service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();
        //        //Act
        //        var actual = await messageController.GetAllOutgoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsValidationService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsValidationService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllOutgoingElementsMessagesAsync(), Times.Once());
        //        mockElementsValidationService.Verify(service => service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>()));

        //        foreach (var message in actual.Value)
        //        {
        //            Assert.IsType<SenderRecipient>(message);
        //        }
        //    }

        //    [Fact]
        //    public async void TestGetAllOutgoingElementsMessagesDirectionAsync()
        //    {
        //        //Arrange
        //        var mockElementsRepository = new Mock<IElementsMessageRepository>();

        //        mockElementsRepository.Setup(repository =>
        //        repository.GetAllOutgoingElementsMessagesAsync())
        //        .ReturnsAsync(GetOutgoingElementsMessagesObject());

        //        var mockElementsSortingService = new Mock<IElementsValidationService>();
        //        mockElementsSortingService.Setup(service =>
        //        service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>()))
        //              .Returns<List<SenderRecipient>>(m => m);

        //        var messageController = new MessageController();
        //        //Act
        //        var actual = await messageController.GetAllOutgoingElementsMessagesAsync(mockElementsRepository.Object, mockElementsSortingService.Object);

        //        //Assert
        //        mockElementsRepository.VerifyAll();
        //        mockElementsSortingService.VerifyAll();
        //        mockElementsRepository.Verify(c => c.GetAllOutgoingElementsMessagesAsync(), Times.Once());
        //        mockElementsSortingService.Verify(service => service.ValidateElementsOutgoingMessages(It.IsAny<List<SenderRecipient>>()), Times.Once());


        //        foreach (var elementsMessage in actual.Value)
        //        {
        //            Assert.False(elementsMessage.IsRecipient);
        //        }
        //    }

        private IEnumerable<DifiMessage> GetIncomingMessageObject()
        {
            var incomingMessage = new List<DifiMessage>
            {
                new DifiMessage
                {
                    lastUpdate = DateTime.Now,
                    receiverIdentifier = "987464291",
                    direction = "INCOMING",
                }
            };

            return incomingMessage;
        }

        private IEnumerable<DifiMessage> GetOutgoingMessageObject()
        {

            var outgoingMessage = new List<DifiMessage>
            {
                new DifiMessage
                {
                    lastUpdate = DateTime.Now,
                    senderIdentifier = "989778471",
                    direction = "OUTGOING",
                }
            };
            return outgoingMessage;
        }

        private List<DifiMessage> GetMessageObject()
        {

            var messageObject = new List<DifiMessage>
            {
                new DifiMessage
                {
                    id = 11,
                    conversationId = "40c8ccb8-aed8-4e1f-b87e-e27c0895813d",
                    senderIdentifier = "987464291",
                    receiverIdentifier = "989778471",
                },
                new DifiMessage
                {
                    id = 22,
                    conversationId = "40c8ccb8-aed8-4e1f-b87e-e27c0895813d",
                    senderIdentifier = "987464291",
                    receiverIdentifier = "989778471",
                }
            };
            return messageObject;
        }

        //    private IEnumerable<SenderRecipient> GetIncomingElementsMessagesObject()
        //    {
        //        var incomingElementsMessage = new List<SenderRecipient>
        //        {
        //            new SenderRecipient
        //            {
        //                Id = 100,
        //                IsRecipient = true,
        //                ConversationId = "4c0e6147-8971-4c8a-8936-3daec08d82d6",
        //                CreatedDate = DateTime.Now,
        //            }
        //        };

        //        return incomingElementsMessage;
        //    }
        //    private IEnumerable<SenderRecipient> GetOutgoingElementsMessagesObject()
        //    {
        //        var outgoingElementsMessage = new List<SenderRecipient>
        //        {
        //            new SenderRecipient
        //            {
        //                Id = 200,
        //                IsRecipient = false,
        //                ConversationId = "e1708df4-fdcf-42ac-b401-2bf92d1ed8bc",
        //                CreatedDate = DateTime.Now,
        //            }
        //        };

        //        return outgoingElementsMessage;
        //    }
    }
}
