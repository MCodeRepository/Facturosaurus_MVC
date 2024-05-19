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
    public class TaxTypeConfiguration : IEntityTypeConfiguration<TaxType>
    {
        public void Configure(EntityTypeBuilder<TaxType> builder)
        {
            builder.Property(x => x.Rate)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
