using Facturosaurus.Application.Customers.Commands.ModifyCustomer;

namespace Facturosaurus.Application.Customers;

public class CustomerDto
{
    public int Id { get; set; }
    public string ShortCustomerName { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string NipNumber { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string BildingNumber { get; set; } = string.Empty;
    public string ApartmentNumber { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string AccountCurrency { get; set; } = "";
    public string AccountNumber { get; set; } = string.Empty;
    public string AddressEmail { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Active { get; set; }= false;

    public string GetFullAddress()
    {
        var numbers = ApartmentNumber == "" ? "" : "/" + ApartmentNumber;

        return $"ul. {StreetName} {BildingNumber}{numbers}, {ZipCode} {City}";
    }

    public ModifyCustomerCommand getModifyCustomerCommand()
    {
        return new ModifyCustomerCommand()
        {
            Id = Id,
            ShortCustomerName = ShortCustomerName,
            CustomerName = CustomerName,
            AccountCurrency = AccountCurrency,
            AddressEmail = AddressEmail,
            PhoneNumber = PhoneNumber,
            AccountNumber = AccountNumber,
            Active = Active,
            ApartmentNumber = ApartmentNumber,
            ZipCode = ZipCode,
            City = City,
            BankName = BankName,
            BildingNumber = BildingNumber,
            CreateDate = CreateDate,
            NipNumber = NipNumber,
            StreetName = StreetName,
        };
    } 
}
