using System;
using Brukerfeil.Enode.Common.Configurations;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Brukerfeil.Enode.Schemas;
using Elements.ConfigServer.Client;
using Elements.ConfigServer.Client.ConfigurationManager;
using Elements.ConfigServer.Client.Entities;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Caching.Memory;

namespace Brukerfeil.Enode.API.Configurations
{
    public class ConfigProvider : IConfigProvider
    {
        private static IConfigurationRoot _localConfigRoot;
        private static IConfigManager<ConfigWrapper> _configManager;
        private static IMemoryCache _memoryCache;
        private static readonly Lazy<IConfigProvider> InstanceLazy = new Lazy<IConfigProvider>(() => new ConfigProvider());

        public static IConfigProvider Instance => InstanceLazy.Value;

        private ConfigProvider()
        {

            _memoryCache = new MemoryCache(new MemoryCacheOptions());

            _localConfigRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                   .Build();
            
            var ConfigManager = ConfigManagerFactory<ConfigWrapper>.CreateConfigManager(
                GetGlobalConfiguration,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"),
                new List<SchemaEntry>
                {
                    SchemaEntry.Create<OrganizationSchema>()
                });

            _configManager = new CachingConfigManagerDecorator<ConfigWrapper>(ConfigManager);

        }

        public async Task<OrganizationSchema> GetOrgConfigAsync(string tenant)
        {
            //Get 
            return await GetCachedOrganizationsAsync(tenant);
        }

        public string GetGlobalConfiguration(string key)
        {
            return _localConfigRoot[($"appsettings:{key}")];

        }

        private async Task<OrganizationSchema> GetCachedOrganizationsAsync(string tenant)
        {
            return await _memoryCache.GetOrCreateAsync("Tenants", async cacheEntry =>
            {
                var tenantConfig = await _configManager.GetTenantConfigAsync(tenant);
                return tenantConfig.OrganizationSchema;
            });
        }
            
        public class ConfigWrapper : TenantConfig
        {
            [JsonProperty(OrganizationSchema.Schema)]
            public OrganizationSchema OrganizationSchema { get; set; }
        }
    }
}