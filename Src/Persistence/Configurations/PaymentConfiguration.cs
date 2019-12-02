using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure payment entity meta data for database
    /// </summary>
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(e => e.PaymentId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PaymentAmount).IsRequired();

            builder.Property(e => e.OtherDetails).HasMaxLength(1024);
        }
    }
}