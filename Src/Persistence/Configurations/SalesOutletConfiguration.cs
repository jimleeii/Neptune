using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence.Configurations
{
    /// <summary>
    /// Configure sales outlet entity meta data for database
    /// </summary>
    public class SalesOutletConfiguration : IEntityTypeConfiguration<SalesOutlet>
    {
        /// <summary>
        /// Adds schema to entity
        /// </summary>
        /// <param name="builder">Entity type builder</param>
        public void Configure(EntityTypeBuilder<SalesOutlet> builder)
        {
            // builder.HasKey can be ignored as following approach
            builder.Property(e => e.SalesOutletId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.SalesOutletDetails)
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