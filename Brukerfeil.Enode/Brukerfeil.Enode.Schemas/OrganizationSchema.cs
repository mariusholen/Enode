using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Brukerfeil.Enode.Schemas
{
    [Description("Collection of organizations")]
    public class OrganizationSchemaContent
    {
        public const string Schema = "organizationContent";

        [DataMember(Name = "Content")]
        [Description("Collection of organizations")]
        [DefaultValue(new object[] { })]
        public IEnumerable<OrganizationSchema> Content { get; set; }
    }

    [Description("Data model for organization")]
    public class OrganizationSchema
    {

        [DataMember(Name = "OrgId")]
        [DefaultValue(null)]
        [Description("Organization Identifier for an organization")]
        public int OrgId { get; set; }

        [DataMember(Name = "OrgName")]
        [DefaultValue("")]
        [Description("The name of an organization")]
        public string OrgName { get; set; }

        [DataMember(Name = "Tenants")]
        [DefaultValue(new object[] { })]
        [Description("A list of Tenants for an organization")]
        public IEnumerable<Tenant> Tenants { get; set; }

    }
    public class Tenant
    {
        [DataMember(Name = "TenantName")]
        [DefaultValue("")]
        [Description("Name of a tenant")]
        public string TenantName { get; set; }
    }
}