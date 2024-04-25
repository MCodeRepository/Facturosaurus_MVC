using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails;
using Facturosaurus.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Facturosaurus.Application.Extensions
{
    public static class ServiceCollectionExtencion
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllCompanyDetailsQuery));
            services.AddMediatR(typeof(CreateNewCompanyDetailsCommand));
            services.AddAutoMapper(typeof(FacturosaurusMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateNewCompanyDetailsCommandValidation>()
                .AddFluentValidationAutoValidation()        //domyślna walidacja zostanie zastąpina walidacją z Fluent Validation
                .AddFluentValidationClientsideAdapters();   //po stronie fronendu zostanie dodana logika validacji
        }
    }
}
