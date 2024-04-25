using AutoMapper;
using Facturosaurus.Application.CompanyDetails;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;


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
        }
    }
}
