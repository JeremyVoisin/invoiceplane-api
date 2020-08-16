using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpQuoteTaxRates
    {
        public int QuoteTaxRateId { get; set; }
        public int QuoteId { get; set; }
        public int TaxRateId { get; set; }
        public int IncludeItemTax { get; set; }
        public decimal? QuoteTaxRateAmount { get; set; }
    }
}
