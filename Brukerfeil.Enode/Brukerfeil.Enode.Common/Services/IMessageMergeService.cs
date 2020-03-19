using System;
using System.Collections.Generic;
using System.Text;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Services
{
    public interface IMessageMergeService
    {
        public Message MergeMessages(DifiMessage difiMessages, ElementsMessage elementsMessages);
        public IEnumerable<Message> MergeMessagesLists(IEnumerable<DifiMessage> difiMessages, IEnumerable<ElementsMessage> elementsMessages);
    }
}
