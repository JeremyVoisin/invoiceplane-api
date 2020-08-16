using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpQuoteAmounts
    {
        public int QuoteAmountId { get; set; }
        public int QuoteId { get; set; }
        public decimal? QuoteItemSubtotal { get; set; }
        public decimal? QuoteItemTaxTotal { get; set; }
        public decimal? QuoteTaxTotal { get; set; }
        public decimal? QuoteTotal { get; set; }
    }
}
