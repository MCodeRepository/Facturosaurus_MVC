using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturosaurus.Api.Entities.Configurations
{
    public class CustomerBankAccountConfiguration : IEntityTypeConfiguration<CustomerBankAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerBankAccount> builder)
        {
            builder.Property(n => n.BankName)
                .HasMaxLength(100);
            builder.Property(n => n.AccountCurrency)
                .HasMaxLength(3);
            builder.Property(n => n.AccountNumber)
                .HasMaxLength(26);
            builder.Property(n => n.Default)
                .HasDefaultValue(true);
            builder.Property(n => n.OrderNumber)
                .HasDefaultValue(1);
        }
    }
}
