using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IElementsMessageRepository
    {
        Task<IEnumerable<ElementsMessage>> GetAllIncomingElementsMessagesAsync();

        Task<IEnumerable<ElementsMessage>> GetAllOutgoingElementsMessagesAsync();

    }
}
