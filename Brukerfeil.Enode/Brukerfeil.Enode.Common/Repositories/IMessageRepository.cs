using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllIncomingMessagesAsync();
        Task<IEnumerable<Message>> GetOrgIncomingMessagesAsync(string organizationId);
        Task<IEnumerable<Message>> GetAllOutgoingMessagesAsync();
        Task<IEnumerable<Message>> GetOrgOutgoingMessagesAsync(string organizationId);
        Task<IEnumerable<Message>> GetAllMessagesBySenderIdAsync(string senderId);
        Task<IEnumerable<Message>> GetOrgMessagesBySenderIdAsync(string senderId, string organizationId);
        Task<IEnumerable<Message>> GetAllMessagesByReceiverIdAsync(string receiverId);
        Task<IEnumerable<Message>> GetOrgMessagesByReceiverIdAsync(string receiverId, string organizationId);

    }
}
