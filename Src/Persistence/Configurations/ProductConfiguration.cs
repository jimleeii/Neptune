using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure product entity meta data for database
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
        }
    }
}