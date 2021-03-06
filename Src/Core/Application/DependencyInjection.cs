﻿using Microsoft.Extensions.DependencyInjection;

namespace Neptune.Core.Application
{
    /// <summary>
    /// Extension for service collection to inject current class lib required dependencies
    /// This will provide total isolation between current class lib with others
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Performs denpendency injection at Startup.cs
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Inject dependencies

            return services;
        }
    }
}
