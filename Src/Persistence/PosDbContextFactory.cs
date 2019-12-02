using Microsoft.EntityFrameworkCore;

namespace Neptune.Persistence
{
    /// <summary>
    /// POS dataabase context factory
    /// </summary>
    public class PosDbContextFactory : DesignTimeDbContextFactoryBase<PosDbContext>
    {
        /// <summary>
        /// Creates new POS database context
        /// </summary>
        /// <param name="options">Database context options</param>
        /// <returns>Database context</returns>
        protected override PosDbContext CreateNewInstance(DbContextOptions<PosDbContext> options)
        {
            return new PosDbContext(options);
        }
    }
}