using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(n => n.StreetName)
                .HasMaxLength(100);
            builder.Property(n => n.BildingNumber)
                .HasMaxLength(10);
            builder.Property(n => n.ApartmentNumber)
                .HasMaxLength(10);
            builder.Property(n => n.ZipCode)
                .HasMaxLength(20);
            builder.Property(n => n.City)
                .HasMaxLength(100);
            builder.Property(n => n.Default)
                .HasDefaultValue(true);
            builder.Property(n => n.OrderNumber)
                .HasDefaultValue(1);
            //builder.HasOne(c => c.Customer)
            //    .WithMany()
            //    .HasForeignKey(a => a.CustomerId);
        }
    }
}
