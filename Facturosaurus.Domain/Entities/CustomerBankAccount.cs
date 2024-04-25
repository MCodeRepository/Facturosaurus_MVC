namespace Facturosaurus.Domain.Entities
{
    public class CustomerBankAccount
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string BankName { get; set; }
        public int AccountCurrency { get; set; }
        public string AccountNumber { get; set; }
        public bool Default { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
