// <copyright file="Extensions.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Extensions
{
    using Credentials;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        private const string ConfigurationSection = "Client";

        public static IServiceCollection AddCredentialClientConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddCredentialClientConfiguration<ClientService>(configuration);
        }

        public static IServiceCollection AddCredentialClientConfiguration<T>(this IServiceCollection services, IConfiguration configuration)
            where T : class, IClientService
        {
            services.AddTransient<IClientService, T>();
            services.Configure<IssuingClient>(configuration.GetSection(ConfigurationSection));

            return services;
        }

        public static IServiceCollection AddCredentialProvider<T>(this IServiceCollection services)
            where T : class, ICredentialProvider
        {
            services.AddTransient<ICredentialProvider, T>();

            return services;
        }
    }
}