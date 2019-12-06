using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure product in transaction entity meta data for database
    /// </summary>
    public class ProductInTransactionConfiguration : IEntityTypeConfiguration<ProductInTransaction>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<ProductInTransaction> builder)
        {
            // Creates composite key
            builder.HasKey(e => new { e.ProductId, e.TransactionId });

            builder.Property(e => e.Quantity)
                .IsRequired();
        }
    }
}