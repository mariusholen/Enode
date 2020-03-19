using Brukerfeil.Enode.API.Controllers;
using Xunit;
using Moq;
using Brukerfeil.Enode.Common.Configurations;
using System.Collections.Generic;
using Brukerfeil.Enode.Common.Models;

namespace Brukerfeil.Enode.Test.OrganizationTests
{
    
    public class OrganizationControllerTest
    {/*
        [Fact]
        public async void TestGetOrganizationConfigsNotNullAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrganizationConfigsAsync())
                .Returns(GetOrganizationObject());

            var organizationController = new OrganizationController(mockConfigProvider.Object);

            //Act
            var actual = await organizationController.GetOrganizationConfigsAsync();

            //Assert
            mockConfigProvider.VerifyAll();
            Assert.NotNull(actual);
        }

        [Fact]
        public async void TestGetOrganizationConfigsTypeAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrganizationConfigsAsync())
                .ReturnsAsync(GetOrganizationObject());

            var organizationController = new OrganizationController(mockConfigProvider.Object);

            //Act
            var actual = await organizationController.GetOrganizationConfigsAsync();

            //Assert
            Assert.IsType<List<Organization>>(actual);

        }

        [Fact]
        public async void TestGetOrganizationConfigNamesAsync()
        {
            //Arrange
            var mockConfigProvider = new Mock<IConfigProvider>();
            mockConfigProvider.Setup(configProvider =>
            configProvider.GetOrganizationConfigsAsync())
                .ReturnsAsync(GetOrganizationObject());

            var organizationController = new OrganizationController(mockConfigProvider.Object);
            var expected = new List<Organization>
            {
                new Organization
                {
                    OrganizationName = "Atea",
                    
                }
            };
            var expectedOrgName = "Atea";

            //Act
            var actual = await organizationController.GetOrganizationConfigsAsync();

            //Assert
            
            Assert.Equal(actual, expected);
        }

        private Organization GetOrganizationObject()
        {

            var organization = new Organization
            {
                OrganizationName = "Atea",
            };

            return organization;
        }*/
    }
}