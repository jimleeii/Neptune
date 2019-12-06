using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure transaction entity meta data for database
    /// </summary>
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // builder.HasKey can be ignored as following approach
            builder.Property(e => e.TransactionId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TransactionDateTime)
                .IsRequired();

            builder.Property(e => e.TransactionWholesalePrice)
                .IsRequired();

            builder.Property(e => e.TransactionRetailPrice)
                .IsRequired();

            builder.Property(e => e.OtherDetails)
                .HasMaxLength(1024);
        }
    }
}