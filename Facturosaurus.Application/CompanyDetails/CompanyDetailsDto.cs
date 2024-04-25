using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.CompanyDetails
{
    public class CompanyDetailsDto
    {
        public DateTime UpdateDate { get; set; }
        public string ShortCompanyName { get; set; }
        public string CompanyName { get; set; }
        public string NipNumber { get; set; }
        public string StreetName { get; set; }
        public string BildingNumber { get; set; }
        public string ApartmentNumber { get; set; } = "";
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public string BankAccountNumber { get; set; }
        public string PhoneNumber { get; set; } = "";
        public string AddressEmail { get; set; } = "";

        public string GetFullAddress()
        {
            var numbers = ApartmentNumber == "" ? "" : "/" + ApartmentNumber;

            return $"ul. {StreetName} {BildingNumber}{numbers}, {ZipCode} {City}";
        }

        public CreateNewCompanyDetailsCommand GetCreateNewCompanyDetailsCommand()
        {
            return new CreateNewCompanyDetailsCommand()
            {
                ShortCompanyName = ShortCompanyName,
                CompanyName = CompanyName,
                NipNumber = NipNumber,
                StreetName = StreetName,
                BildingNumber = BildingNumber,
                ApartmentNumber = ApartmentNumber,
                ZipCode = ZipCode,
                City = City,
                BankName = BankName,
                Currency = Currency,
                BankAccountNumber = BankAccountNumber,
                PhoneNumber = PhoneNumber,
                AddressEmail = AddressEmail,
            };
        }
    }
}
