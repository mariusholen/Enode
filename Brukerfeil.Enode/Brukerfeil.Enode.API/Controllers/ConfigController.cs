using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brukerfeil.Enode.Common.Configurations;
using Brukerfeil.Enode.Schemas;

namespace Brukerfeil.Enode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigProvider _configProvider;
        public ConfigController(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        
        [HttpGet("organizations")]
        public async Task<IEnumerable<OrganizationSchema>> GetOrgConfigAsync(string tenant1, string tenant2 = null)
        {
            var orgConfigs = new List<OrganizationSchema>();
            orgConfigs.Add(await _configProvider.GetOrgConfigAsync(tenant1));
            orgConfigs.Add(await _configProvider.GetOrgConfigAsync(tenant2));
            return orgConfigs;
        }
    }
}