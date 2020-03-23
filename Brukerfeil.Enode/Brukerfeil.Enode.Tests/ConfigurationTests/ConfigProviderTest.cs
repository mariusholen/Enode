using Xunit;
using Brukerfeil.Enode.Schemas;
using Elements.ConfigServer.Client.Entities;
using Newtonsoft.Json;
using Brukerfeil.Enode.Common.Configurations;
using Brukerfeil.Enode.API.Configurations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Brukerfeil.Enode.Tests.ConfigurationTests
{
    public class ConfigProviderTest
    {
        [Fact]
        public async void TestGetOrganizationConfigsNotNullAsync()
        {

            //Act
            var actual = await ConfigProvider.Instance.GetOrgConfigAsync("MASTER_ORA");

            //Assert
            Assert.NotNull(actual);

        }

        [Fact]
        public async void TestGetOrganizationConfigsTypeAsync()
        {
            //Act
            var actual = await ConfigProvider.Instance.GetOrgConfigAsync("MASTER_SQL");

            //Assert
            Assert.IsType<OrganizationSchema>(actual);

        }

        [Fact]
        public async void TestGetOrganizationConfigName()
        {
            //Arrange
            var expected = new OrganizationSchema
            {
                OrganizationId = 2,
                OrganizationName = "Sikri AS",
            };

            //Act
            var actual = await ConfigProvider.Instance.GetOrgConfigAsync("MASTER_SQL");

            //Assert
            Assert.True(actual.OrganizationName == expected.OrganizationName &&
                actual.OrganizationId == expected.OrganizationId);
        }
    }
}
