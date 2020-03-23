using Brukerfeil.Enode.API.Controllers;
using Xunit;
using Moq;
using Brukerfeil.Enode.Common.Configurations;
using System.Collections.Generic;
using Brukerfeil.Enode.Schemas;
using System.Linq;

namespace Brukerfeil.Enode.Test.OrganizationTests
{
    
    public class ConfigControllerTest
    {
        [Fact]
        public async void TestGetOrgConfigNotNullAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrgConfigAsync("MASTER_ORA"))
                .ReturnsAsync(GetOrganizationObject());

            var configController = new ConfigController(mockConfigProvider.Object);

            //Act
            var actual = await configController.GetOrgConfigAsync("MASTER_ORA");

            //Assert
            mockConfigProvider.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetOrgConfigTypeAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrgConfigAsync("MASTER_ORA"))
                .ReturnsAsync(GetOrganizationObject());

            var configController = new ConfigController(mockConfigProvider.Object);

            //Act
            var actual = await configController.GetOrgConfigAsync("MASTER_ORA");

            //Assert
            Assert.IsType<List<OrganizationSchema>>(actual);

        }

        [Fact]
        public async void TestOrgNameAndOrgIdAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrgConfigAsync("MASTER_ORA"))
                .ReturnsAsync(GetOrganizationObject());

            var configController = new ConfigController(mockConfigProvider.Object);
            var expected = new List<OrganizationSchema>
            {
                new OrganizationSchema
                {
                    OrganizationName = "Gecko Eiendom AS",
                    OrganizationId = 1,
                }
            };

            //Act
            var actual = await configController.GetOrgConfigAsync("MASTER_ORA");
            //Assert
            Assert.True(actual.ToList()[0].OrganizationName == expected[0].OrganizationName &&
                actual.ToList()[0].OrganizationId == expected[0].OrganizationId);
            
        }

        private OrganizationSchema GetOrganizationObject()
        {

            var organization = new OrganizationSchema
            {
                OrganizationName = "Gecko Eiendom AS",
                OrganizationId = 1,
            };

            return organization;
        }
    }
}