using Facturosaurus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
