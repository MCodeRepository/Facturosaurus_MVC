using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task DeleteCustomer(int customerId);
        Task<Customer> GetByNip(string nip);
    }
}
