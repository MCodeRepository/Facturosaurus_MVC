using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Infrastructure.Persistence.Configurations
{
    public class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder.Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
