using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Infrastructure.Persistence.Configurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.DaysToAddToDatePayment)
                .IsRequired();
        }
    }
}
