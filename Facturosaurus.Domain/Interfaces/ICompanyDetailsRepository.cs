using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface ICompanyDetailsRepository
    {
        Task<IEnumerable<CompanyDetails?>> GetAll();
        Task<CompanyDetails?> GetLast();
        Task<CompanyDetails?> GetCompanyDetailsForTheDate(DateTime date);
        Task Update (CompanyDetails companyDetails);
        Task Create (CompanyDetails companyDetails);
        Task Commit();
    }
}
