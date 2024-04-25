using Facturosaurus.Application.CompanyDetails.Quires;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails
{
    public class CreateNewCompanyDetailsCommandValidation : AbstractValidator<CreateNewCompanyDetailsCommand>
    {
        public CreateNewCompanyDetailsCommandValidation()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty()
                .WithMessage("Nazwa firmy jest wymagana.");
            RuleFor(c => c.ShortCompanyName)
                .NotEmpty()
                .WithMessage("Skrócona nazwa firmy jest wymagana.");
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
            RuleFor(c => c.BankName)
                .NotEmpty()
                .WithMessage("Nazwa banku jest wymagana.");
            RuleFor(c => c.BankAccountNumber)
                .NotEmpty()
                .Length(26)
                .WithMessage("Numer konta musi mieć 26 cyfr.");
            RuleFor(c => c.Currency)
                .NotEmpty()
                .MaximumLength(3)
                .WithMessage("Waluta może mieć maksymalnie 3 znaki"); 
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(9);
            RuleFor(c => c.AddressEmail)
                .EmailAddress()
                .WithMessage("Niepoprawny adres email.");
        }
    }
}
