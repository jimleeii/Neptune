using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neptune.Core.Application.Common.Interfaces;

namespace Neptune.Persistence
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
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Adds database context, configuration with name 'PosDatabase' is provided in appsettings.json
            services.AddDbContext<PosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PosDatabase")));

            // Add scoped
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0
            services.AddScoped<IPosDbContext>(provider => provider.GetService<PosDbContext>());

            return services;
        }
    }
}
