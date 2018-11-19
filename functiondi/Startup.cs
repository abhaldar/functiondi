// <copyright file="Startup.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

using functiondi;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup), "A Web Jobs Extension Sample")]
namespace functiondi
{
    /// <summary>
    /// Startup class for Functions
    /// </summary>
    public class Startup : IWebJobsStartup
    {
        /// <summary>
        /// Confiiguration Method
        /// </summary>
        /// <param name="builder">I Web Job Builder</param>
        public void Configure(IWebJobsBuilder builder)
        {
            // Don't need to create a new service collection just use the built-in one
            builder.Services.AddSingleton<IProcessor, Processor>();

            // Registering an extension
            builder.AddExtension<InjectConfiguration>();
        }
    }
}