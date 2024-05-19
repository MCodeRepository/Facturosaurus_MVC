using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Interfaces;
using Facturosaurus.Infrastructure.Repositories;
using Facturosaurus.Infrastructure.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Facturosaurus.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FacturosaurusDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("Facturosaurus_DEV")));

            services.AddScoped<ICompanyDetailsRepository, CompanyDetailsRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<FacturosaurusSeeder>();
        }
    }
}
