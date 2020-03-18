using System.ComponentModel;
using System.Runtime.Serialization;

namespace Brukerfeil.Enode.Schemas
{
    [Description("Configuration for organizations")]
    public class OrganizationSchema
    {
        public const string Schema = "organization";

        [DataMember(Name = "OrganizationId")]
        [DefaultValue("")]
        [Description("The id of an organization")]
        public int OrganizationId { get; set; }

        [DataMember(Name = "OrganizationName")]
        [DefaultValue("")]
        [Description("The name of a specific organization")]
        public string OrganizationName { get; set; }

        [DataMember(Name = "Username")]
        [DefaultValue("")]
        [Description("Username for an organization")]
        public string Username { get; set; }

        [DataMember(Name = "Password")]
        [DefaultValue("")]
        [Description("Password for an organization")]
        public string Password { get; set; }

        [DataMember(Name = "IntegrationPoint")]
        [DefaultValue("")]
        [Description("URL to an organization's Difi integrationpoint")]
        public string IntegrationPoint { get; set; }

        [DataMember(Name = "ElementsNcore")]
        [DefaultValue("")]
        [Description("URL to ELements NCore integrationpoint")]
        public string ElementsNcore { get; set; }

        [DataMember(Name = "Tenant")]
        [DefaultValue("")]
        [Description("Tenant of an organization")]
        public string Tenant { get; set; }

        [DataMember(Name = "Enabled")]
        [DefaultValue(false)]
        [Description("Enable reading")]
        public bool Enabled { get; set; }
    }
}