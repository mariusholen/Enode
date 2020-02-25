/*using Brukerfeil.Enode.Repositories;
using Brukerfeil.Enode.API.Controllers;
using Xunit;
using Moq;

namespace Brukerfeil.Enode.Test.OrganizationTests
{
    
    public class OrganizationControllerTest
    {
        private OrganizationRepository _organizationRepository;
        private OrganizationController _organizationController;

        public OrganizationControllerTest(OrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationController = new OrganizationController();
        }

        [Fact]
        public void TestGetOrganization()
        {
            var mock = new Mock<OrganizationController>();
            mock.SetupGet(controller => controller.GetOrganization("1", _organizationRepository));

        }
    }
}
*/