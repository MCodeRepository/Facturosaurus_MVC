using Facturosaurus.Domain.Interfaces;
using FluentValidation;

namespace Facturosaurus.Application.Invoices.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommandValidation : AbstractValidator<CreateNewInvoiceCommand>
    {
        public CreateNewInvoiceCommandValidation(ICustomerRepository repository)
        {
            RuleFor(c => c.DocumentTypeId)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Brak typu dokumentu.");
            RuleFor(c => c.ExecutionDate)
               .NotEmpty()
               .WithMessage("Data wykonania jest wymagana.");
            RuleFor(c => c.PaymentTypeId)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Brak wybranego rodzaju płatności.");
            RuleFor(c => c.PaymentDate)
                .NotEmpty()
                .WithMessage("Brak daty płatności.");
            RuleFor(c => c.CustomerNipNumber)
                .NotEmpty()
                .WithMessage("Nie wybrano kontrahenta.");
                
            RuleFor(c => c.Author)
                .NotEmpty()
                .WithMessage("Brak autora faktury.");
            RuleFor(c => c.CustomerId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Nie wybrano kontrahenta.")
                .Custom((value, context) =>
                {
                    var existingCustomer = repository.GetCustomerById(value).Result;
                    if (value!=0 && existingCustomer == null)
                    {
                        context.AddFailure("W bazie nie występuje kontrahent o podanych danych.");
                    }
                });

            RuleFor(c => c.CompanyDetailsId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Brak danych firmy.");
            RuleFor(c => c.Items.Count)
                .GreaterThan(0)
                .WithMessage("Brak pozycji faktury.");
            RuleForEach(c => c.Items).SetValidator(new InvoiceItemDtoValidation());
        }
    }

    public class InvoiceItemDtoValidation : AbstractValidator<InvoiceItemDto>
    {
        public InvoiceItemDtoValidation()
        {
            RuleFor(c => c.OrderNumber)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Brak liczby porządkowej pozycji.");
            RuleFor(c => c.ItemName)
               .NotEmpty()
               .WithMessage("Brak nazwy usługi/produktu.");
            RuleFor(c => c.Quantity)
               .GreaterThan(0)
               .WithMessage("Ilość nie może być zerem.");
            RuleFor(c => c.UnitPrice)
               .GreaterThan(0)
               .WithMessage("Brak ceny netto za jednostkę.");
            RuleFor(c => c.UnitTypeId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Nie wybrano jednostki miary.");
            RuleFor(c => c.TaxTypeId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Nie wybrano stawki podatku.");
        }
    }
}