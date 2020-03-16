using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<DifiMessage>> GetAllIncomingMessagesAsync();
        Task<IEnumerable<DifiMessage>> GetOrgIncomingMessagesAsync(string organizationId);
        Task<IEnumerable<DifiMessage>> GetAllOutgoingMessagesAsync();
        Task<IEnumerable<DifiMessage>> GetOrgOutgoingMessagesAsync(string organizationId);
        Task<IEnumerable<DifiMessage>> GetAllMessagesBySenderIdAsync(string senderId);
        Task<IEnumerable<DifiMessage>> GetOrgMessagesBySenderIdAsync(string senderId, string organizationId);
        Task<IEnumerable<DifiMessage>> GetAllMessagesByReceiverIdAsync(string receiverId);
        Task<IEnumerable<DifiMessage>> GetOrgMessagesByReceiverIdAsync(string receiverId, string organizationId);

    }
}
