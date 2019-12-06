using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure payment method entity meta data for database
    /// </summary>
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Assigns none Id column as PK
            builder.HasKey(e => e.PaymentMethodCode);

            builder.Property(e => e.PaymentMethodName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.PaymentMethodDescription)
                .HasMaxLength(1024);
        }
    }
}