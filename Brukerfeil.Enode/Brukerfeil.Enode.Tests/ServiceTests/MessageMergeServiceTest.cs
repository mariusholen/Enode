using System;
using System.Collections.Generic;
using Xunit;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Services;
using System.Linq;

namespace Brukerfeil.Enode.Tests.ServiceTests
{
    public class MessageMergeServiceTest
    {
        private DifiMessage _difiMessage1 { get; set; }
        private DifiMessage _difiMessage2 { get; set; }
        private ElementsMessage _eleMessage1 { get; set; }
        private ElementsMessage _eleMessage2 { get; set; }

        ////////////////////////
        ///    CONSTRUCTOR   ///   
        ////////////////////////
        public MessageMergeServiceTest()
        {
            _difiMessage1 = new DifiMessage
            {
                messageId = "test1",
                senderIdentifier = "sender1"
            };
            _difiMessage2 = new DifiMessage
            {
                messageId = "test2",
                senderIdentifier = "sender2"
            };
            _eleMessage1 = new ElementsMessage
            {
                ConversationId = "test1",
                IsRead = "true"
            };
            _eleMessage2 = new ElementsMessage
            {
                ConversationId = "test2",
                IsRead = "false"
            };
        }

        ////////////////////////////////////////////////
        ///   METHODS TO GET OBJECTS TO TEST WITH   ///   
        ///////////////////////////////////////////////
        private IEnumerable<DifiMessage> GetDifiMessageObjectList()
        {
            var difiMessageArray = new List<DifiMessage>()
            {
                _difiMessage1, _difiMessage2
            };
            return difiMessageArray;
        }
        private IEnumerable<ElementsMessage> GetElementsMessageObjectList()
        {
            var eleMessageArray = new List<ElementsMessage>()
            {
                _eleMessage1, _eleMessage2
            };
            return eleMessageArray;
        }
        private Message GetMessageMergeService()
        {
            //Arrange
            var mergeService = new MessageMergeService();
            //Act
            var actual = mergeService.MergeMessages(_difiMessage1, _eleMessage1);
            return actual;
        }
        private List<Message> GetMessageMergeListService()
        {
            //Arrange
            var mergeService = new MessageMergeService();

            //Act
            var difiMessageList = GetDifiMessageObjectList();
            var elementsMessageList = GetElementsMessageObjectList();
            var actual = mergeService.MergeMessagesLists(difiMessageList, elementsMessageList).ToList();
            return actual;
        }
        


        //////////////////////
        ///   UNIT TESTS   ///   
        //////////////////////
        
        //Method MergeMessages()
        [Fact]
        public void TestMergeMessagesNotNull()
        {
            var actual = GetMessageMergeService();
            Assert.NotNull(actual);
        }
        [Fact]
        public void TestMergeMessagesType()
        {
            var actual = GetMessageMergeService();
            Assert.IsType<Message>(actual);
        }
        [Fact]
        public void TestMergeMessagesCorrectMatch()
        {
            var actual = GetMessageMergeService();
            Assert.Equal(actual.DifiMessage.messageId, actual.ElementsMessage.ConversationId);
        }
        [Fact]
        public void TestMergeMessagesMergingFieldSenderIdentifier()
        {
            var actual = GetMessageMergeService();
            Assert.Equal(actual.DifiMessage.senderIdentifier, _difiMessage1.senderIdentifier);
        }
        [Fact]
        public void TestMergeMessagesMergingFieldIsRead()
        {
            var actual = GetMessageMergeService();
            Assert.Equal(actual.ElementsMessage.IsRead, _eleMessage1.IsRead);
        }




        //Method MergeMessagesLists()
        [Fact]
        public void TestMergeMessagesListNotNull()
        {
            var actual = GetMessageMergeListService();
            Assert.NotNull(actual);
        }
        [Fact]
        public void TestMergeMessagesListHasEntries()
        {
            var actual = GetMessageMergeListService();
            Assert.NotNull(actual[0]);
        }
        [Fact]
        public void TestMergeMessagesListType()
        {
            var actual = GetMessageMergeListService();
            Assert.IsType<List<Message>>(actual);
        }
        [Fact]
        public void TestMergeMessagesListEntriesType1()
        {
            var actual = GetMessageMergeListService();
            Assert.IsType<Message>(actual[0]);
        }
        [Fact]
        public void TestMergeMessagesListEntriesType2()
        {
            var actual = GetMessageMergeListService();
            Assert.IsType<DifiMessage>(actual[0].DifiMessage);
        }
        [Fact]
        public void TestMergeMessagesListEntriesType3()
        {
            var actual = GetMessageMergeListService();
            Assert.IsType<ElementsMessage>(actual[0].ElementsMessage);
        }
        [Fact]
        public void TestMergeMessagesListCorrectMatch1()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[0].DifiMessage.messageId, actual[0].ElementsMessage.ConversationId);
        }
        [Fact]
        public void TestMergeMessagesListCorrectMatch2()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[1].DifiMessage.messageId, actual[1].ElementsMessage.ConversationId);
        }
        [Fact]
        public void TestMergeMessagesListMergingFieldSenderIdentifier1()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[0].DifiMessage.senderIdentifier, _difiMessage1.senderIdentifier);
        }
        [Fact]
        public void TestMergeMessagesListMergingFieldSenderIdentifier2()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[1].DifiMessage.senderIdentifier, _difiMessage2.senderIdentifier);
        }
        [Fact]
        public void TestMergeMessagesListMergingFieldIsRead1()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[0].ElementsMessage.IsRead, _eleMessage1.IsRead);
        }
        [Fact]
        public void TestMergeMessagesListMergingFieldIsRead2()
        {
            var actual = GetMessageMergeListService();
            Assert.Equal(actual[1].ElementsMessage.IsRead, _eleMessage2.IsRead);
        }
    }
}
