using Facturosaurus.Domain.Entities;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Facturosaurus.Application.Invoices
{
    public class InvoiceDto
    {
        // Head
        public int Id { get; set; }

        public int DocumentTypeId { get; set; }
        public string DocumentShortName { get; set; } = "";
        public string DocumentName { get; set; } = "";

        public int Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExecutionDate { get; set; }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; } = "";
        public int DaysToAddToDatePayment { get; set; }
        public DateTime PaymentDate { get; set; }

        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }

        public bool Paid { get; set; }
        public DateTime PaidDate { get; set; }

        public string Author { get; set; } = "";


        // Customer
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerNipNumber { get; set; } = "";
        public string CustomerStreetName { get; set; } = "";
        public string CustomerBildingNumber { get; set; } = "";
        public string CustomerApartmentNumber { get; set; } = "";
        public string CustomerZipCode { get; set; } = "";
        public string CustomerCity { get; set; } = "";


        // Company details
        public int CompanyDetailsId { get; set; }
        public string CompanyShortName { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string CompanyNipNumber { get; set; } = "";
        public string CompanyStreetName { get; set; } = "";
        public string CompanyBildingNumber { get; set; } = "";
        public string CompanyApartmentNumber { get; set; } = "";
        public string CompanyZipCode { get; set; } = "";
        public string CompanyCity { get; set; } = "";
        public string CompanyBankName { get; set; } = "";
        public string CompanyCurrency { get; set; } = "";
        public string CompanyBankAccountNumber { get; set; } = "";
        public string CompanyPhoneNumber { get; set; } = "";
        public string CompanyAddressEmail { get; set; } = "";


        // Correction
        public int? CorrectionId { get; set; }
        public string CorrectionReason { get; set; } = "";
        public InvoiceDto? Correction { get; set; }


        //Items
        public List<InvoiceItemDto> Items { get; set; } = [];


        public string GetFullCustomerAddress()
        {
            var numbers = CustomerApartmentNumber == "" ? "" : "/" + CustomerApartmentNumber;

            return $"ul. {CustomerStreetName} {CustomerBildingNumber}{numbers}, {CustomerZipCode} {CustomerCity}";
        }
        public string GetFullCompanyAddress()
        {
            var numbers = CompanyApartmentNumber == "" ? "" : "/" + CompanyApartmentNumber;

            return $"ul. {CompanyStreetName} {CompanyBildingNumber}{numbers}, {CompanyZipCode} {CompanyCity}";
        }

        public string GetStreetFromCustomerAddress()
        {
            var numbers = CustomerApartmentNumber == "" ? "" : "/" + CustomerApartmentNumber;

            return $"ul. {CustomerStreetName} {CustomerBildingNumber}{numbers}";
        }
        public string GetStreetFromCompanyAddress()
        {
            var numbers = CompanyApartmentNumber == "" ? "" : "/" + CompanyApartmentNumber;

            return $"ul. {CompanyStreetName} {CompanyBildingNumber}{numbers}";
        }

        public string GetNumber()
        {
            return $"{Number}/{Month}/{Year}";
        }

        public string getValueInWords()
        {
            decimal gross = GrossAmount;
            decimal integer = Math.Truncate(GrossAmount);
            decimal fractional = (gross - Math.Truncate(gross)) * 100;
            var integerNum = ValueToWords.LiczbaSlownie(Decimal.ToInt32(GrossAmount));

            var integerStr = ValueToWords.LiczbaSlownie(Decimal.ToInt32(integer));
            var fractionalStr = ValueToWords.LiczbaSlownie(Decimal.ToInt32(fractional));

            return $"{integerStr} zł {fractionalStr} gr";
        }

        public Dictionary<string, decimal> GetNetValueByTaxTypes()
        {
            Dictionary<string, decimal> taxTypesValue = new Dictionary<string, decimal>();

            foreach (var item in Items)
            {
                var sum = taxTypesValue[item.TaxTypeName];
                sum += item.NetValue;
                if (!taxTypesValue.ContainsKey(item.TaxTypeName)) 
                {
                    taxTypesValue.Add(item.TaxTypeName, sum);
                }
                else
                {
                    taxTypesValue[item.TaxTypeName] = sum;  
                }
            }
            return taxTypesValue;
        }

        public Dictionary<string, decimal[]> GetSumByTaxTypes()
        {
            Dictionary<string, decimal[]> taxTypesValue = new Dictionary<string, decimal[]>();
            taxTypesValue = CalculateSumByTaxTypes(Items);

            return taxTypesValue;
        }

        public CorrectionSummary GetSumByTaxTypesCorrectionSummary()
        {
            if(Correction != null)
            {
                Dictionary<string, decimal[]> taxTypesValueBeforeCorrection = new Dictionary<string, decimal[]>();
                Dictionary<string, decimal[]> taxTypesValueAfterCorrection = new Dictionary<string, decimal[]>();
                Dictionary<string, decimal[]> taxTypesValueSummary = new Dictionary<string, decimal[]>();

                taxTypesValueBeforeCorrection = CalculateSumByTaxTypes(Correction.Items);
                taxTypesValueAfterCorrection = CalculateSumByTaxTypes(Items);

                decimal sumNet = 0m;
                decimal sumVat = 0m;
                decimal sumGross = 0m;

                decimal subSumNet = 0m;
                decimal subSumVat = 0m;
                decimal subSumGross = 0m;

                foreach ( var taxType  in taxTypesValueBeforeCorrection)
                {
                    if (!taxTypesValueSummary.ContainsKey(taxType.Key))
                    {
                        subSumNet = taxTypesValueAfterCorrection[taxType.Key][0]- taxTypesValueBeforeCorrection[taxType.Key][0];
                        subSumVat = taxTypesValueAfterCorrection[taxType.Key][1] - taxTypesValueBeforeCorrection[taxType.Key][1];
                        subSumGross = taxTypesValueAfterCorrection[taxType.Key][2] - taxTypesValueBeforeCorrection[taxType.Key][2];

                        sumNet += subSumNet;
                        sumVat += subSumVat;
                        sumGross += subSumGross;

                        taxTypesValueSummary.Add(taxType.Key, [subSumNet, subSumVat, subSumGross]);
                    }
                }
                return new CorrectionSummary(taxTypesValueSummary, [sumNet, sumVat, sumGross]);
            }
            return null;
        }

        public class CorrectionSummary
        {
            public Dictionary<string, decimal[]> taxTypesValueSummary = [];
            public decimal[] sumCorrectionSummary = [];

            public CorrectionSummary(Dictionary<string, decimal[]> taxTypesValueSummary, decimal[] sumCorrectionSummary)
            {
                this.taxTypesValueSummary = taxTypesValueSummary;
                this.sumCorrectionSummary = sumCorrectionSummary;
            }

        }

        public Dictionary<string, decimal[]> CalculateSumByTaxTypes(List<InvoiceItemDto> items)
        {
            Dictionary<string, decimal[]> taxTypesValue = new Dictionary<string, decimal[]>();

            foreach (var item in items)
            {
                decimal sumNet = 0m;
                decimal sumVat = 0m;
                decimal sumGross = 0m;

                if (taxTypesValue.ContainsKey(item.TaxTypeName))
                {
                    sumNet = taxTypesValue[item.TaxTypeName][0];
                    sumVat = taxTypesValue[item.TaxTypeName][1];
                    sumGross = taxTypesValue[item.TaxTypeName][2];
                }


                sumNet += item.NetValue;
                sumVat += item.VatValue;
                sumGross += item.GrossValue;

                if (!taxTypesValue.ContainsKey(item.TaxTypeName))
                {
                    taxTypesValue.Add(item.TaxTypeName, [sumNet, sumVat, sumGross]);
                }
                else
                {
                    taxTypesValue[item.TaxTypeName][0] = sumNet;
                    taxTypesValue[item.TaxTypeName][1] = sumVat;
                    taxTypesValue[item.TaxTypeName][2] = sumGross;
                }
            }
            return taxTypesValue;
        }

        public string GetFormatedBankAccound()
        {
            return Regex.Replace(CompanyBankAccountNumber, @"(\d{2})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})", "$1 $2 $3 $4 $5 $6 $7");
        }

    }
}
