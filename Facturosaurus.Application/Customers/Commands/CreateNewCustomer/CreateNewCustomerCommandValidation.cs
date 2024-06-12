using Facturosaurus.Domain.Interfaces;
using FluentValidation;

namespace Facturosaurus.Application.Customers.Commands.CreateNewCustomer
{
    public class CreateNewCustomerCommandValidation : AbstractValidator<CreateNewCustomerCommand>
    {
        public CreateNewCustomerCommandValidation(ICustomerRepository repository)
        {
            RuleFor(c => c.CustomerName)
               .NotEmpty()
               .WithMessage("Nazwa kontrahenta jest wymagana.");
            RuleFor(c => c.ShortCustomerName)
                    .NotEmpty()
                    .WithMessage("Skrócona nazwa kontrahenta jest wymagana.");
            RuleFor(c => c.NipNumber)
                    .Custom((value, context) =>
                    {
                        var customerExist = repository.GetByNip(value).Result;

                        if (customerExist != null)
                        {
                            context.AddFailure($"Kontrahent z numerem NIP {value} istnieje.");
                        }
                    });
                    
            RuleFor(c => c.NipNumber)
                    .NotEmpty().WithMessage("NIP jest wymagany.")
                    .Length(10)
                    .WithMessage("Minimalna długość to 10 cyfr");
            RuleFor(c => c.StreetName)
                    .NotEmpty()
                    .WithMessage("Nazwa ulicy jest wymagana.");
            RuleFor(c => c.City)
                    .NotEmpty()
                    .WithMessage("Nazwa miasta jest wymagana.");
            RuleFor(c => c.ZipCode)
                    .NotEmpty()
                    .MinimumLength(5)
                    .WithMessage("Kod pocztowy jest wymagany.");
            RuleFor(c => c.BildingNumber)
                    .NotEmpty()
                    .WithMessage("Numer budynku jest wymagany.");
            RuleFor(c => c.AccountNumber)
                    .Length(26)
                    .WithMessage("Numer konta musi mieć 26 cyfr.");
            RuleFor(c => c.PhoneNumber)
                    .MinimumLength(9);
            RuleFor(c => c.AddressEmail)
                    .EmailAddress()
                    .WithMessage("Niepoprawny adres email.");
        }
    }
}
