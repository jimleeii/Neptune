using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure customer entity meta data for database
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.CustomerId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CustomerDetails)
                .IsRequired()
                .HasMaxLength(1024);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(e => e.Created)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(45);
        }
    }
}