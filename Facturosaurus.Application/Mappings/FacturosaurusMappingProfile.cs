using AutoMapper;
using Facturosaurus.Application.CompanyDetails;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Application.Customers;
using Facturosaurus.Application.Customers.Commands.CreateNewCustomer;
using Facturosaurus.Application.Customers.Commands.ModifyCustomer;
using Facturosaurus.Application.Invoices;
using Facturosaurus.Application.Invoices.Commands.CreateNewCorrectionInvoice;
using Facturosaurus.Application.Invoices.Commands.CreateNewInvoice;
using Facturosaurus.Application.PaymentTypes;
using Facturosaurus.Application.TaxTypes.Queries;
using Facturosaurus.Application.UnitTypes.Queries;
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


            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.DocumentName, x => x.MapFrom(i => i.DocumentType.Name))
                .ForMember(x => x.DocumentShortName, x => x.MapFrom(i => i.DocumentType.ShortName))
                .ForMember(x => x.DocumentName, x => x.MapFrom(i => i.DocumentType.Name))
                .ForMember(x => x.PaymentTypeName, x => x.MapFrom(i => i.PaymentType.Name))
                .ForMember(x => x.DaysToAddToDatePayment, x => x.MapFrom(i => i.PaymentType.DaysToAddToDatePayment))
                .ForMember(x => x.CompanyShortName, x => x.MapFrom(i => i.CompanyDetails.ShortCompanyName))
                .ForMember(x => x.CompanyName, x => x.MapFrom(i => i.CompanyDetails.CompanyName))
                .ForMember(x => x.CompanyNipNumber, x => x.MapFrom(i => i.CompanyDetails.NipNumber))
                .ForMember(x => x.CompanyStreetName, x => x.MapFrom(i => i.CompanyDetails.StreetName))
                .ForMember(x => x.CompanyBildingNumber, x => x.MapFrom(i => i.CompanyDetails.BildingNumber))
                .ForMember(x => x.CompanyApartmentNumber, x => x.MapFrom(i => i.CompanyDetails.ApartmentNumber))
                .ForMember(x => x.CompanyZipCode, x => x.MapFrom(i => i.CompanyDetails.ZipCode))
                .ForMember(x => x.CompanyCity, x => x.MapFrom(i => i.CompanyDetails.City))
                .ForMember(x => x.CompanyBankName, x => x.MapFrom(i => i.CompanyDetails.BankName))
                .ForMember(x => x.CompanyCurrency, x => x.MapFrom(i => i.CompanyDetails.Currency))
                .ForMember(x => x.CompanyBankAccountNumber, x => x.MapFrom(i => i.CompanyDetails.BankAccountNumber))
                .ForMember(x => x.CompanyPhoneNumber, x => x.MapFrom(i => i.CompanyDetails.PhoneNumber))
                .ForMember(x => x.CompanyAddressEmail, x => x.MapFrom(i => i.CompanyDetails.AddressEmail));

            CreateMap<InvoiceItems, InvoiceItemDto>()
                .ForMember(i => i.UnitName, i => i.MapFrom(c => c.UnitType.Name))
                .ForMember(i => i.UnitShortName, i => i.MapFrom(c => c.UnitType.ShortName))
                .ForMember(i => i.TaxTypeName, i => i.MapFrom(c => c.TaxType.Name))
                .ForMember(i => i.TaxTypeRate, i => i.MapFrom(c => c.TaxType.Rate));
            CreateMap<InvoiceItemDto, InvoiceItems>();

            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<UnitType, UnitTypeDto>();
            CreateMap<TaxType, TaxTypeDto>();

            CreateMap<CreateNewInvoiceCommand, Invoice>();
            CreateMap<CreateNewCorrectionInvoiceCommand, Invoice>();
        }
    }
}