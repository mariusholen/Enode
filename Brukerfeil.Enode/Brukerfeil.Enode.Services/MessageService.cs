using Brukerfeil.Enode.Common.Models;
using System.Linq;
using Brukerfeil.Enode.Common.Services;
using System.Collections.Generic;


namespace Brukerfeil.Enode.Services
{
    public class MessageService : IMessageService
    {
        public IEnumerable<Message> LatestStatus(IEnumerable<Message> messages)
        {
            foreach (var message in messages)
            {
                var lastStatus = message.messageStatuses.Last().status.ToString();
                message.latestMessageStatus = lastStatus;
                message.messageStatuses = null;
            }
            return messages;
        }
    }
}
