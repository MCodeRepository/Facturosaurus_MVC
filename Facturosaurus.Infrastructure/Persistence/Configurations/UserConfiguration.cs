using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
