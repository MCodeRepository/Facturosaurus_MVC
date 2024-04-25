namespace Facturosaurus.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string ShortCustomerName { get; set; }
        public string CustomerName { get; set; }
        public string NipNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Active { get; set; }

        public virtual List<CustomerAddress> Adresses { get; set; } = new List<CustomerAddress>();
        public virtual List<CustomerEmailAddress> EmailAdresses { get; set; } = new List<CustomerEmailAddress>();
        public virtual List<CustomerBankAccount> BankAccounts { get; set; } = new List<CustomerBankAccount>();
        public virtual List<CustomerPhone> Phones { get; set; } = new List<CustomerPhone>();
    }
}
