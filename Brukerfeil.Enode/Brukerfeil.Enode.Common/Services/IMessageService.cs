using System.Collections.Generic;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Services
{
    public interface IMessageService
    {
        public IEnumerable<Message> LatestStatus(IEnumerable<Message> message);
    }
}