using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceTaxRates
    {
        public int InvoiceTaxRateId { get; set; }
        public int InvoiceId { get; set; }
        public int TaxRateId { get; set; }
        public int IncludeItemTax { get; set; }
        public decimal InvoiceTaxRateAmount { get; set; }
    }
}
