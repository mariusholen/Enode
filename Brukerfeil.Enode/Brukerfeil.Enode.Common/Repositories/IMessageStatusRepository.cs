using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IMessageStatusRepository
    {
        Task<IEnumerable<MessageStatus>> GetMessageStatusAsync(string messageId);
    }
}