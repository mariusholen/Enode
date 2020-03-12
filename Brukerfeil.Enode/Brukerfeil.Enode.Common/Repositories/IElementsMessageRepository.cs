using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IElementsMessageRepository
    {
        Task<IEnumerable<SenderRecipient>> GetAllIncomingElementsMessagesAsync();

        Task<IEnumerable<SenderRecipient>> GetAllOutgoingElementsMessagesAsync();

    }
}
