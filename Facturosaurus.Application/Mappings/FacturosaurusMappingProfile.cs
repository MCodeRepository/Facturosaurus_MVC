using AutoMapper;
using Facturosaurus.Application.CompanyDetails;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Application.Customers;
using Facturosaurus.Application.Customers.Commands.CreateNewCustomer;
using Facturosaurus.Application.Customers.Commands.ModifyCustomer;
using Facturosaurus.Domain.Entities;


namespace Facturosaurus.Application.Mappings
{
    public class FacturosaurusMappingProfile : Profile
    {
        public FacturosaurusMappingProfile()
        {
            CreateMap<Domain.Entities.CompanyDetails, CompanyDetailsDto>()
                .ReverseMap();
            CreateMap<CreateNewCompanyDetailsCommand, Domain.Entities.CompanyDetails>()
                .ForMember(a => a.AddressEmail, opt => opt.MapFrom(c => c.AddressEmail != null ? c.AddressEmail : ""))
                .ForMember(a => a.PhoneNumber, opt => opt.MapFrom(c => c.PhoneNumber != null ? c.PhoneNumber : ""))
                .ForMember(a => a.ApartmentNumber, opt => opt.MapFrom(c => c.ApartmentNumber != null ? c.ApartmentNumber : ""));

            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.StreetName, c => c.MapFrom(a => a.Adresses.Where(d => d.Default == true).FirstOrDefault()!.StreetName))
                .ForMember(c => c.BildingNumber, c => c.MapFrom(a => a.Adresses.Where(d => d.Default == true).FirstOrDefault()!.BildingNumber))
                .ForMember(c => c.ApartmentNumber, c => c.MapFrom(a => a.Adresses.Where(d => d.Default == true).FirstOrDefault()!.ApartmentNumber))
                .ForMember(c => c.ZipCode, c => c.MapFrom(a => a.Adresses.Where(d => d.Default == true).FirstOrDefault()!.ZipCode))
                .ForMember(c => c.City, c => c.MapFrom(a => a.Adresses.Where(d => d.Default == true).FirstOrDefault()!.City))
                .ForMember(c => c.BankName, c => c.MapFrom(a => a.BankAccounts.Where(d => d.Default == true).FirstOrDefault()!.BankName))
                .ForMember(c => c.AccountCurrency, c => c.MapFrom(a => a.BankAccounts.Where(d => d.Default == true).FirstOrDefault()!.AccountCurrency))
                .ForMember(c => c.AccountNumber, c => c.MapFrom(a => a.BankAccounts.Where(d => d.Default == true).FirstOrDefault()!.AccountNumber))
                .ForMember(c => c.AddressEmail, c => c.MapFrom(a => a.EmailAdresses.Where(d => d.Default == true).FirstOrDefault()!.AddressEmail))
                .ForMember(c => c.PhoneNumber, c => c.MapFrom(a => a.Phones.Where(d => d.Default == true).FirstOrDefault()!.PhoneNumber));

            CreateMap<CustomerDto, Customer>();

            CreateMap<CreateNewCustomerCommand, Customer>();
            CreateMap<ModifyCustomerCommand, Customer>();

            CreateMap<Customer, CustomerShortListDto>();
        }
    }
}
