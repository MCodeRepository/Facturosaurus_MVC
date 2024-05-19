using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Infrastructure.Seeder
{
    public class FacturosaurusSeeder
    {
        private readonly FacturosaurusDbContext _dbContext;

        public FacturosaurusSeeder(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.DocumentTypes.Any())
                {
                    var documentTypes = new List<DocumentType>()
                    {
                        new() {Name="Faktura VAT", ShortName="FV",Description="Podstawowy dokument faktury"},
                        new() {Name="Korekta faktury", ShortName="FK",Description="Korekta faktury wystawiana w przypadku zman faktury podstawowej."}
                    };

                    _dbContext.DocumentTypes.AddRange(documentTypes);

                    if (!_dbContext.PaymentTypes.Any())
                    {
                        var paymantTypes = new List<PaymentType>()
                        {
                            new() { Name = "gotówka", DaysToAddToDatePayment=0, Active=true},
                            new() { Name = "przelew 7 dni", DaysToAddToDatePayment=7, Active=true},
                            new() { Name = "przelew 14 dni", DaysToAddToDatePayment=14, Active=true },
                        };

                        _dbContext.PaymentTypes.AddRange(paymantTypes);
                    }

                    if (!_dbContext.TaxTypes.Any())
                    {
                        var taxTypes = new List<TaxType>()
                        {
                            new () { Rate = 0.23m, Name = "23%", Active=true},
                            new () { Rate = 0, Name = "0%", Active=true},
                            new () { Rate = 0.08m, Name = "8%", Active=true},
                        };

                        _dbContext.TaxTypes.AddRange(taxTypes);
                    }

                    if (!_dbContext.UnitTypes.Any())
                    {
                        var unitTypes = new List<UnitType>()
                        {
                            new () { ShortName = "szt.", Name = "sztuki", Active=true},
                            new () { ShortName = "godz.", Name = "godzina", Active=true},
                        };

                        _dbContext.UnitTypes.AddRange(unitTypes);
                    }

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
