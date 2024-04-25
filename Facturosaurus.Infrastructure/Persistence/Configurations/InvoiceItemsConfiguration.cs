using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class InvoiceItemsConfiguration : IEntityTypeConfiguration<InvoiceItems>
    {
        public void Configure(EntityTypeBuilder<InvoiceItems> builder)
        {
            builder.Property(n => n.ItemName)
                .HasMaxLength(400);
            builder.Property(n => n.Unit)
                .HasMaxLength(4);
            builder.Property(n => n.VatValue)
                .HasMaxLength(300);
            builder.Property(n => n.GrossValue)
                .HasMaxLength(10);
            builder.OwnsOne(n => n.Vat);
        }
    }
}
