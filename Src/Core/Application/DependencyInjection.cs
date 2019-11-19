using Microsoft.Extensions.DependencyInjection;

namespace Neptune.Core.Application
{
    /// <summary>
    /// Extension for service collection to inject current class lib required dependencies
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
