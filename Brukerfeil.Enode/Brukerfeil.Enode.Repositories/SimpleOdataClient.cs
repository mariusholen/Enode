using System;
using Simple.OData.Client;
using Brukerfeil.Enode.Common.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brukerfeil.Enode.Repositories
{
    public class SimpleOdataClient
    {
        public async Task<IEnumerable<OrganizationIdentifier>> GetOrganizationsElements()
        {
            //TODO : Change URI, when access is given to real API. 
            var settings = new ODataClientSettings(new Uri("https://services.odata.org/Experimental/Northwind/Northwind.svc/"));
            //settings.BeforeRequest += delegate (HttpRequestMessage message)
            //{
            //------TODO: Give TOKEN when awailable. 
            //    message.Headers.Add("Authorization", "Bearer " + token.AccessToken);
            //};
                
            //TODO : Change ---?--- when REAL API!!!
            var client = new ODataClient(settings);
            var organizations = await client.For<OrganizationIdentifier>()
                .Filter(o => o.OrganizationNumber != null)
                .FindEntriesAsync();

            organizations.ToList().ForEach(o => Console.WriteLine(o.OrganizationNumber));

            //Method for mapping data. TODO: change to real data when access to Elements is given. 
            //"ID = {0} First Name = {1} Last Name = {2}", e.EmployeeID, e.FirstName, e.LastName
             return organizations;

        }
    }
}