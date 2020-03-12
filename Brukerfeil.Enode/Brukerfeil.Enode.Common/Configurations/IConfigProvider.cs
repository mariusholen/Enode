using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Common.Configurations
{
    public interface IConfigProvider
    {
        Task<IEnumerable<Organization>> GetOrganizationConfigsAsync();
    }
}