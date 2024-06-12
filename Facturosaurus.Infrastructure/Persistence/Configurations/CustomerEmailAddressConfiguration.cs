using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CustomerEmailAddressConfiguration : IEntityTypeConfiguration<CustomerEmailAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerEmailAddress> builder)
        {
            builder.Property(n => n.AddressEmail)
                .HasMaxLength(100);
            builder.Property(n => n.Default)
                .HasDefaultValue(true);
            builder.Property(n => n.OrderNumber)
                .HasDefaultValue(1);
        }
    }
}
