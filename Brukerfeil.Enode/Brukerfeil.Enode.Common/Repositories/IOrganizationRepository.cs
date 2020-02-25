using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetOrganizations();
        Task<Organization> GetOrganization(int id);
    }
}