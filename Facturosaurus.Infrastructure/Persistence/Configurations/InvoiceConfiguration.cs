using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(n => n.Month)
            .HasMaxLength(2);
            builder.Property(n => n.Year)
            .HasMaxLength(4);
            builder.Property(n => n.CustomerName)
            .HasMaxLength(300);
            builder.Property(n => n.CustomerNipNumber)
            .HasMaxLength(10);
            builder.Property(n => n.CustomerStreetName)
            .HasMaxLength(100);
            builder.Property(n => n.CustomerBildingNumber)
            .HasMaxLength(10);
            builder.Property(n => n.CustomerApartmentNumber)
            .HasMaxLength(10);
            builder.Property(n => n.CustomerZipCode)
            .HasMaxLength(10);
            builder.Property(n => n.CustomerCity)
            .HasMaxLength(100);
        }
    }
}
