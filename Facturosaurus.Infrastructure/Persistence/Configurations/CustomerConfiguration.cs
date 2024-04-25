using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.ShortCustomerName)
                .HasMaxLength(150);
            builder.Property(c => c.CustomerName)
                .HasMaxLength(300);
            builder.Property(c => c.NipNumber)
                .HasMaxLength(10);
            builder.Property(c => c.CreateDate)
                .HasDefaultValueSql("getutcdate()");
            //builder.Property(c => c.UpdatedDate) 
            //    .ValueGeneratedOnAddOrUpdate();
        }
    }
}
