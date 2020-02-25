using System;
using System.Collections.Generic;
using Xunit;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Services;

namespace Brukerfeil.Enode.Tests.ServiceTests
{
    public class MessageServiceTest
    {
        [Fact]
        public void TestMessageServiceLatestStatusNotNull()
        {
            //Arrange
            var messageService = new MessageService();

            //Act
            var actual = messageService.LatestStatus(messageServiceTestObject());

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void TestMessageServiceLatestStatusType()
        {
            //Arrange
            var messageService = new MessageService();

            //Act
            var actual = messageService.LatestStatus(messageServiceTestObject());

            //Assert
            Assert.IsType<List<Message>>(actual);
        }

        [Fact]
        public void TestMessageServiceLatestStatusIsUpdated()
        {
            //Arrange
            var messageService = new MessageService();

            //Act
            var actual = messageService.LatestStatus(messageServiceTestObject());

            //Assert

            foreach(var content in actual)
            {
                Assert.Equal("LEVETID_UTLOPT", content.latestMessageStatus);
            }
        }

        [Fact]
        public void TestMessageServiceMessageStatusesIsUpdatedToNull()
        {
            //Arrange
            var messageService = new MessageService();

            //Act
            var actual = messageService.LatestStatus(messageServiceTestObject());

            //Assert
            foreach (var content in actual)
            {
                Assert.Null(content.messageStatuses);
            }
        }

        public IEnumerable<Message> messageServiceTestObject()
        {
            var message = new List<Message>
            {
                new Message
                {
                    latestMessageStatus = null,
                    messageStatuses = new List<MessageStatuses>
                    {
                        new MessageStatuses
                        {
                            id = 57343,
                            lastUpdate = Convert.ToDateTime("2020-02-14T12:17:08.214+01:00"),
                            status = "OPPRETTET"
                        },
                        new MessageStatuses
                        {
                            id = 57344,
                            lastUpdate = Convert.ToDateTime("2020-02-14T12:17:08.216+01:00"),
                            status = "INNKOMMENDE_MOTTATT"
                        },
                        new MessageStatuses
                        {
                            id = 57348,
                            lastUpdate = Convert.ToDateTime("2020-02-14T14:17:25.362+01:00"),
                            status = "LEVETID_UTLOPT"
                        }
                    }
                }
            };
            return message;
        }
    }
}