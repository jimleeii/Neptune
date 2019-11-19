using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neptune.Infrastructure
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
		/// <param name="configuration">Configuration</param>
		/// <param name="environment">Web host environment</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            // Inject dependencies

            return services;
        }
    }
}