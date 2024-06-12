using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public CustomerRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Customer customer)
        {
            _dbContext.Cutomers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customerToDelete = await _dbContext.Cutomers.FirstOrDefaultAsync(c => c.Id == customerId);


            if (customerToDelete != null)
            {
                

                var addressToDelete = _dbContext.Addresses.Where(c => c.CustomerId == customerId).ToList();

                if (addressToDelete != null)
                {
                    _dbContext.Addresses.RemoveRange(addressToDelete);
                }

                var bankAccountToDelete = _dbContext.BankAccounts.Where(c => c.CustomerId == customerId).ToList();

                if (bankAccountToDelete != null)
                {
                    _dbContext.BankAccounts.RemoveRange(bankAccountToDelete);
                }

                var emailAddressToDelete = _dbContext.EmailAddresses.Where(c => c.CustomerId == customerId).ToList();

                if (emailAddressToDelete != null)
                {
                    _dbContext.EmailAddresses.RemoveRange(emailAddressToDelete);
                }

                var phoneToDelete = _dbContext.Phones.Where(c => c.CustomerId == customerId).ToList();
                if (phoneToDelete != null)
                {
                    _dbContext.Phones.RemoveRange(phoneToDelete);
                }

                _dbContext.Cutomers.Remove(customerToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _dbContext.Cutomers
               .Include(c => c.BankAccounts)
               .Include(c => c.Adresses)
               .Include(c => c.Phones)
               .Include(c => c.EmailAdresses)
               .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetByNip(string nip)
        {
            var customer = await _dbContext
                .Cutomers
                .FirstOrDefaultAsync(c => c.NipNumber == nip);

            return customer!;
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _dbContext
                .Cutomers
                .Include(a => a.Adresses)
                .Include(a => a.BankAccounts)
                .Include(a => a.EmailAdresses)
                .Include(a => a.Phones)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            return customer!;
        }

        public async Task Update(Customer customer)
        {
            var customerToUpdate = await _dbContext.Cutomers.FirstOrDefaultAsync(c => c.NipNumber == customer.NipNumber);


            if (customerToUpdate != null && customerToUpdate.Id>0)
            {
                customerToUpdate.ShortCustomerName = customer.ShortCustomerName;
                customerToUpdate.CustomerName = customer.CustomerName;
                customerToUpdate.UpdatedDate = DateTime.Now;
                customerToUpdate.Active = customer.Active;

                _dbContext.Cutomers.Update(customerToUpdate);
                await _dbContext.SaveChangesAsync();


                CustomerAddress? addressToUpdate = await _dbContext.Addresses.FirstOrDefaultAsync(c => c.CustomerId == customerToUpdate.Id && c.Default == true);

                if (addressToUpdate != null)
                {
                    if (!customer.Adresses.IsNullOrEmpty())
                    {
                        addressToUpdate.CustomerId = customerToUpdate.Id;
                        addressToUpdate.OrderNumber = 1;
                        addressToUpdate.StreetName = customer.Adresses.FirstOrDefault()!.StreetName;
                        addressToUpdate.BildingNumber = customer.Adresses.FirstOrDefault()!.BildingNumber;
                        addressToUpdate.ApartmentNumber = customer.Adresses.FirstOrDefault()!.ApartmentNumber;
                        addressToUpdate.ZipCode = customer.Adresses.FirstOrDefault()!.ZipCode;
                        addressToUpdate.City = customer.Adresses.FirstOrDefault()!.City;
                        addressToUpdate.Default = true;

                        _dbContext.Addresses.Update(addressToUpdate);
                    }
                    else
                    {
                        _dbContext.Addresses.Remove(addressToUpdate);
                    }
                }
                else if (!customer.Adresses.IsNullOrEmpty())
                {
                    var newAddress = new CustomerAddress()
                    {
                        Id = addressToUpdate.Id,
                        CustomerId = customerToUpdate.Id,
                        OrderNumber = 1,
                        StreetName = customer.Adresses.FirstOrDefault()!.StreetName,
                        BildingNumber = customer.Adresses.FirstOrDefault()!.BildingNumber,
                        ApartmentNumber = customer.Adresses.FirstOrDefault()!.ApartmentNumber,
                        ZipCode = customer.Adresses.FirstOrDefault()!.ZipCode,
                        City = customer.Adresses.FirstOrDefault()!.City,
                        Default = true
                    };
                    _dbContext.Addresses.Add(newAddress);
                }

                CustomerBankAccount? bankAccountToUpdate = await _dbContext.BankAccounts.FirstOrDefaultAsync(c => c.CustomerId == customerToUpdate.Id && c.Default == true);

                if (bankAccountToUpdate != null)
                {
                    if (!customer.BankAccounts.IsNullOrEmpty())
                    {
                        bankAccountToUpdate.CustomerId = customerToUpdate.Id;
                        bankAccountToUpdate.OrderNumber = 1;
                        bankAccountToUpdate.BankName = customer.BankAccounts.FirstOrDefault()!.BankName;
                        bankAccountToUpdate.AccountCurrency = customer.BankAccounts.FirstOrDefault()!.AccountCurrency;
                        bankAccountToUpdate.AccountNumber = customer.BankAccounts.FirstOrDefault()!.AccountNumber;
                        bankAccountToUpdate.Default = true;

                        _dbContext.BankAccounts.Update(bankAccountToUpdate);
                    }
                    else
                    {
                        _dbContext.BankAccounts.Remove(bankAccountToUpdate);
                    }
                    
                }
                else if (!customer.BankAccounts.IsNullOrEmpty())
                {
                    var newBankAccount = new CustomerBankAccount()
                    {
                        CustomerId = customerToUpdate.Id,
                        OrderNumber = 1,
                        BankName = customer.BankAccounts.FirstOrDefault()!.BankName,
                        AccountCurrency = customer.BankAccounts.FirstOrDefault()!.AccountCurrency,
                        AccountNumber = customer.BankAccounts.FirstOrDefault()!.AccountNumber,
                        Default = true
                    };
                    _dbContext.BankAccounts.Add(newBankAccount);
                }

                CustomerEmailAddress? emailAddressToUpdate = await _dbContext.EmailAddresses.FirstOrDefaultAsync(c => c.CustomerId == customerToUpdate.Id && c.Default == true);

                if (emailAddressToUpdate != null)
                {
                    if (!customer.EmailAdresses.IsNullOrEmpty())
                    {
                        emailAddressToUpdate.CustomerId = customerToUpdate.Id;
                        emailAddressToUpdate.OrderNumber = 1;
                        emailAddressToUpdate.AddressEmail = customer.EmailAdresses.FirstOrDefault()!.AddressEmail;
                        emailAddressToUpdate.Default = true;

                        _dbContext.EmailAddresses.Update(emailAddressToUpdate);
                    }
                    else
                    {
                        _dbContext.EmailAddresses.Remove(emailAddressToUpdate);
                    }
                }
                else if (!customer.EmailAdresses.IsNullOrEmpty())
                {
                    var newEmailAddress = new CustomerEmailAddress()
                    {
                        CustomerId = customerToUpdate.Id,
                        OrderNumber = 1,
                        AddressEmail = customer.EmailAdresses.FirstOrDefault()!.AddressEmail,
                        Default = true
                    };
                    _dbContext.EmailAddresses.Add(newEmailAddress);
                }

                CustomerPhone? phoneToUpdate = _dbContext.Phones.FirstOrDefault(c => c.CustomerId == customerToUpdate.Id && c.Default == true);
                if (phoneToUpdate != null)
                {
                    if(!customer.Phones.IsNullOrEmpty())
                    {
                        phoneToUpdate.CustomerId = customerToUpdate.Id;
                        phoneToUpdate.OrderNumber = 1;
                        phoneToUpdate.PhoneNumber = customer.Phones.FirstOrDefault()!.PhoneNumber;
                        phoneToUpdate.Default = true;

                        _dbContext.Phones.Update(phoneToUpdate);
                    }
                    else
                    {
                        _dbContext.Remove(phoneToUpdate);
                    }
                }
                else if (!customer.Phones.IsNullOrEmpty())
                {
                    var newPhone = new CustomerPhone()
                    {
                        CustomerId = customerToUpdate.Id,
                        OrderNumber = 1,
                        PhoneNumber = customer.Phones.FirstOrDefault()!.PhoneNumber,
                        Default = true
                    };
                    _dbContext.Phones.Add(newPhone);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
