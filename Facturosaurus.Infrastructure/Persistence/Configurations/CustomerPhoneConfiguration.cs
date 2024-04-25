using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
    {
        public void Configure(EntityTypeBuilder<CustomerPhone> builder)
        {
            builder.Property(n => n.PhoneNumber)
                .HasMaxLength(15);
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
