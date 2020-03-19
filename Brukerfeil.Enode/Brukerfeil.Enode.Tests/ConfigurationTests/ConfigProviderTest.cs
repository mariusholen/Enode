using Xunit;
using Moq;
using Brukerfeil.Enode.Common.Configurations;
using Brukerfeil.Enode.API.Configurations;
using System.Threading.Tasks;
using System.Collections.Generic;
using Brukerfeil.Enode.Common.Models;
using System.Linq;

namespace Brukerfeil.Enode.Tests.ConfigurationTests
{
    public class ConfigProviderTest
    {

        private IConfigProvider _configProvider;
        public ConfigProviderTest(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        [Fact]
        public async void TestGetOrganizationConfigsNotNullAsync()
        {
            //Arranged in constructor

            //Act
            var actual = await _configProvider.GetOrganizationConfigsAsync();

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetOrganizationConfigsTypeAsync()
        {
            //Arranged in constructor

            //Act
            var actual = await _configProvider.GetOrganizationConfigsAsync();

            //Assert
            Assert.IsType<List<Organization>>(actual);

        }

        [Fact]
        public async void TestGetOrganizationConfigName()
        {
            //Arrange
            //var expectedOrgName = "Atea";

            //Act
            var actual = await _configProvider.GetOrganizationConfigsAsync();

            //Assert
            //Assert.Equal(actual.First().OrgName, expectedOrgName);
        }
    }
}
