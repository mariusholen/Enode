using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;

namespace Brukerfeil.Enode.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {

        // GET: api/Organization
        [HttpGet]
        public async Task<IEnumerable<Organization>> GetOrganization([FromServices] IOrganizationRepository organizationRepository)
        {
            return await organizationRepository.GetOrganizations();
        }

        // GET: api/Organization/5
        [HttpGet("{id}", Name = "GetOrganization")]
        public async Task<Organization> GetOrganization(int id, [FromServices] IOrganizationRepository organizationRepository)
        {

            return await organizationRepository.GetOrganization(id);
        }
    }
}