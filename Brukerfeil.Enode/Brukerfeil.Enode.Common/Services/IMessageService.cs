using System.Collections.Generic;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Services
{
    public interface IMessageService
    {
        public IEnumerable<DifiMessage> LatestStatus(IEnumerable<DifiMessage> message);
    }
}