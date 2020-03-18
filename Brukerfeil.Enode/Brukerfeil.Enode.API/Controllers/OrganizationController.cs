using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Configurations;
using Brukerfeil.Enode.Schemas;

namespace Brukerfeil.Enode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IConfigProvider _configProvider;
        public OrganizationController(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        [HttpGet("org")]
        public async Task<OrganizationSchema> GetOrganizationConfigsAsync()
        {
            return await _configProvider.GetOrganizationConfigsAsync();
        }
    }
}