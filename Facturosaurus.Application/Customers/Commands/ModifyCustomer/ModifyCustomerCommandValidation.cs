using FluentValidation;

namespace Facturosaurus.Application.Customers.Commands.ModifyCustomer
{
    public class ModifyCustomerCommandValidation : AbstractValidator<ModifyCustomerCommand>
    {
        public ModifyCustomerCommandValidation()
        {
            RuleFor(c => c.CustomerName)
               .NotEmpty()
               .WithMessage("Nazwa kontrahenta jest wymagana.");
            RuleFor(c => c.ShortCustomerName)
                    .NotEmpty()
                    .WithMessage("Skrócona nazwa kontrahenta jest wymagana.");
            RuleFor(c => c.NipNumber)
                    .NotEmpty()
                    .Length(10)
                    .WithMessage("NIP jest wymagany.");
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
