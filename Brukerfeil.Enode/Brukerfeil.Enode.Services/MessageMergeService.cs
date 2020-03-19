using Brukerfeil.Enode.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Brukerfeil.Enode.Common.Services;
using System.Collections;
using System.Linq;

namespace Brukerfeil.Enode.Services
{
    public class MessageMergeService : IMessageMergeService
    {
        //Takes a single difi and elements message object and returns them in a single message object 
        public Message MergeMessages(DifiMessage difiMessages, ElementsMessage elementsMessages)
        {
            return new Message
            {
                DifiMessage = difiMessages,
                ElementsMessage = elementsMessages
            };
         //Same code typed more explicitly, kept for learning purposes
            //var finalMsg = new Message();
            //finalMsg.DifiMessage = difiMessage;
            //finalMsg.ElementsMessage = elementsMessage;
            //return finalMsg;
        }

        //Takes two lists (list of difi messages and a list of elements messages) 
        //matches each difi message with the corresponding elements message
        //based on DifiMessage.messageId and ElementsMessage.ConversationId
        //Returns a list of merged messages into Message-object
        public IEnumerable<Message> MergeMessagesLists(IEnumerable<DifiMessage> difiMessages, IEnumerable<ElementsMessage> elementsMessages)
        {
            //The final list of Message objects that the method returns
            List<Message> listOfMessages = new List<Message>();

            //The foreach loop iterates the list of difiMessages
            foreach (DifiMessage dmsg in difiMessages) { 
                try
                {
                //elementsMatch = a single elementsMessages entry where its ConversationId matches the iterated difiMessages.messageId
                var elementsMatch = elementsMessages.Single(eleMessage => eleMessage.ConversationId.Equals(dmsg.messageId));
                var message = MergeMessages(dmsg, elementsMatch);
                //Append the merged message to the list of merged messages to be returned
                listOfMessages.Add(message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex + " Error caught and thrown in Class(MessageMergeService), method(MergeMessagesList)");
                    Console.WriteLine("Detailed info: ");
                    Console.WriteLine("Difimessage " + dmsg.messageId + " does not have a match in the provided Elements message list");
                    throw;
                } 
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex + " Error caught and thrown in Class(MessageMergeService), method(MergeMessagesList)");
                    throw;
                }
            }
            return listOfMessages;
        }
    }
}
