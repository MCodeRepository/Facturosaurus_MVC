using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public CompanyDetailsRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(CompanyDetails companyDetails)
        {
            _dbContext.CompanyDetails.Add(companyDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyDetails?>> GetAll()
        => await _dbContext.CompanyDetails.ToListAsync();


        public async Task<CompanyDetails?> GetCompanyDetailsForTheDate(DateTime date)
        {
            var companyDetails = await _dbContext.CompanyDetails.ToListAsync();


            var sortedCompanyDetails = (from companyDetal in companyDetails
                                        orderby companyDetal.UpdateDate
                                        select companyDetal).ToList();

            CompanyDetails companyDetailsForDate = new CompanyDetails();

            foreach (var companyDetal in sortedCompanyDetails)
            {
                if (companyDetal.UpdateDate.Date <= date.Date)
                    companyDetailsForDate = companyDetal;
            }
            
            return companyDetailsForDate;
        }

        public async Task<CompanyDetails?> GetLast()
        {
            var companyDetails = await _dbContext.CompanyDetails.ToListAsync();

            var lastCompanyDetails = (from companyDetal in companyDetails
                                      orderby companyDetal.UpdateDate
                                      select companyDetal).LastOrDefault();

            return lastCompanyDetails;
        }

        public async Task Update(CompanyDetails companyDetails)
        {
            _dbContext.CompanyDetails.Add(companyDetails);
            await _dbContext.SaveChangesAsync();
        }
    }
}
