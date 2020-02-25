using System;
using System.Collections.Generic;
using Brukerfeil.Enode.API.Controllers;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;
using Moq;
using Xunit;

namespace Brukerfeil.Enode.Tests.MessageStatusTests
{
    public class MessageStatusControllerTest
    {
        private readonly string messageId = "8433e766-abe2-4702-a414-ce7a16672538";
        
        [Fact]
        public async void TestGetMessageStatusNotNullAsync()
        {
            //Arrange
            var mockRepository = new Mock<IMessageStatusRepository>();
            mockRepository.Setup(repository => repository.GetMessageStatusAsync(messageId)).ReturnsAsync(GetMessageStatusObject());
            var messageStatusController = new MessageStatusController();
            
            //Act 
            var actual = await messageStatusController.GetMessageStatusAsync(messageId, mockRepository.Object);
           
            //Assert
            mockRepository.Verify(e => e.GetMessageStatusAsync(messageId), Times.Once());
            mockRepository.VerifyAll();
            Assert.NotNull(actual);
        }
        
        [Fact]
        public async void TestGetMessageStatusTypeAsync()
        {
            //Arrange
            var mockRepository = new Mock<IMessageStatusRepository>();
            mockRepository.Setup(repository => repository.GetMessageStatusAsync(messageId)).ReturnsAsync(GetMessageStatusObject());
            var messageStatusController = new MessageStatusController();
            
            //Act
            var actual = await messageStatusController.GetMessageStatusAsync(messageId, mockRepository.Object);
            
            //Assert
            mockRepository.Verify(e => e.GetMessageStatusAsync(messageId), Times.Once());
            mockRepository.VerifyAll();
            Assert.IsType<List<MessageStatus>>(actual);
        }

        [Fact]
        public async void TestGetMessageStatusEqualMessageId()
        {
            //Arrange
            var mockRepository = new Mock<IMessageStatusRepository>();
            mockRepository.Setup(repository => repository.GetMessageStatusAsync(messageId)).ReturnsAsync(GetMessageStatusObject());
            var messageStatusController = new MessageStatusController();
            
            //Act
            var actual = await messageStatusController.GetMessageStatusAsync(messageId, mockRepository.Object);
            
            //Assert
            mockRepository.Verify(e => e.GetMessageStatusAsync(messageId), Times.Once());
            mockRepository.VerifyAll();

            foreach (var content in actual)
            {
                Assert.Equal(content.messageId, messageId);
            }

        }
        private IEnumerable<MessageStatus> GetMessageStatusObject()
        {
            var messageStatus = new List<MessageStatus>
            {
                new MessageStatus
                {
                    id = 3,
                lastUpdate = Convert.ToDateTime("2019-11-04T16:53:02.362+01:00"),
                status = "OPPRETTET",
                conversationId = "e3c73867-9eef-4199-9498-b27c417418f6",
                messageId = "8433e766-abe2-4702-a414-ce7a16672538",
                convId = 2
                }
                
            };
            return messageStatus;
        }
    }
}