using System.Collections.Generic;

namespace Brukerfeil.Enode.Common.Models
{
    public class OrganizationContent
    {
        public IEnumerable<Organization> Content { get; set; }
    }

    public class Organization
    {
        public int OrgId { get; set; }

        public string OrgName { get; set; }

        public IEnumerable<Tenant> Tenant { get; set; }

    }
    public class Tenant
    {

        public string TenantName { get; set; }
    }
}