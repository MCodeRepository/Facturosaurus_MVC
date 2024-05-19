using Facturosaurus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Api.Entities
{
    public class FacturosaurusDbContext : DbContext
    {
        public FacturosaurusDbContext(DbContextOptions<FacturosaurusDbContext> options) : base(options) { } 

        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<Customer> Cutomers { get; set; }
        public DbSet<CustomerAddress> Addresses { get; set; }
        public DbSet<CustomerPhone> Phones { get; set; }
        public DbSet<CustomerEmailAddress> EmailAddresses { get; set; }
        public DbSet<CustomerBankAccount> BankAccounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
