// <copyright file="InjectConfiguration.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

namespace functiondi
{
    using System;
    using System.IO;
    using Microsoft.Azure.WebJobs.Host.Config;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Injection Configuration Class
    /// </summary>
    public class InjectConfiguration : IExtensionConfigProvider
    {
        private IServiceCollection serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectConfiguration"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider Injected Object</param>
        public InjectConfiguration(IServiceCollection serviceProvider)
            => this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        /// <summary>
        /// Method to Initialize Extension Configuration
        /// </summary>
        /// <param name="context">Extension Configuration Context</param>
        public void Initialize(
            ExtensionConfigContext context)
        {
            this.serviceProvider.AddSingleton<IProcessor, Processor>();           
            //context
            //    .AddBindingRule<InjectAttribute>()
            //    .BindToInput<dynamic>(i => this.serviceProvider.GetRequiredService(i.Type));
        }

        private void RegisterServices(IServiceProvider services)
        {
            IConfigurationRoot configuration = this.GetConfiguration();
        }

        private IConfigurationRoot GetConfiguration() => new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
    }
}