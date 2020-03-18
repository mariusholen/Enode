﻿using System;
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

namespace Brukerfeil.Enode.API.Configurations
{
    public class ConfigProvider : IConfigProvider
    {
        private static IConfigurationRoot _localConfigRoot;
        private static IConfigManager<ConfigWrapper> _configManager;

        private static readonly Lazy<IConfigProvider> InstanceLazy = new Lazy<IConfigProvider>(() => new ConfigProvider());

        public static IConfigProvider Instance => InstanceLazy.Value;

        private ConfigProvider()
        {
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

        public async Task<OrganizationSchema> GetOrganizationConfigsAsync()
        {
            //Get 
            var scopeConfig = await _configManager.GetScopeConfigAsync();
            return scopeConfig.OrganizationSchema;

        }

        public string GetGlobalConfiguration(string key)
        {
            return _localConfigRoot[($"appsettings:{key}")];

        }

        public class ConfigWrapper : TenantConfig
        {
            [JsonProperty(OrganizationSchema.Schema)]
            public OrganizationSchema OrganizationSchema { get; set; }
        }
    }
}