using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CompanyDetailsConfiguration : IEntityTypeConfiguration<CompanyDetails>
    {
        public void Configure(EntityTypeBuilder<CompanyDetails> builder)
        {
            builder.Property(n => n.ShortCompanyName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(n => n.CompanyName)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(n => n.NipNumber)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(n => n.StreetName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(n => n.BildingNumber)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(n => n.ApartmentNumber)
                .HasMaxLength(10);
            builder.Property(n => n.ZipCode)
                .IsRequired()
                .HasMaxLength(8);
            builder.Property(n => n.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(n => n.Currency)
                .IsRequired()
                .HasMaxLength(3);
            builder.Property(n => n.BankName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(n => n.BankAccountNumber)
                .IsRequired()
                .HasMaxLength(26);
            builder.Property(n => n.PhoneNumber)
                .HasMaxLength(15);
            builder.Property(n => n.AddressEmail)
                .HasMaxLength(100);
            builder.Property(n => n.UpdateDate)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
