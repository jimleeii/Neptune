using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Neptune.Persistence
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-3.0
    /// </summary>
    /// <typeparam name="TContext">Database context</typeparam>
    public abstract class DesignTimeDbContextFactoryBase<TContext>
        : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        #region Variables

        /// <summary>
        /// Connection string name in appsettings.json
        /// </summary>
        private const string ConnectionStringName = "PosDatabase";
        /// <summary>
        /// Environment variable name
        /// </summary>
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        #endregion

        #region Methods

        /// <summary>
        /// Implements from IDesignTimeDbContextFactory
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Database context</returns>
        public TContext CreateDbContext(string[] args)
        {
            // Gets presentation layer path
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}Presentation{0}WebApi", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        /// <summary>
        /// Overwritable method creates new database context
        /// </summary>
        /// <param name="options">Database context options</param>
        /// <returns>Database context</returns>
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        /// <summary>
        /// Creates database context
        /// </summary>
        /// <param name="basePath">Presentation layer path</param>
        /// <param name="environmentName">Environment variable name</param>
        /// <returns>Database context</returns>
        private TContext Create(string basePath, string environmentName)
        {
            // Builds configuration meta data
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        /// <summary>
        /// Creates database context from connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns>Database context</returns>
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }

        #endregion
    }
}