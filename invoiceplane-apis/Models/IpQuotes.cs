using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpQuotes
    {
        public int QuoteId { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int InvoiceGroupId { get; set; }
        public byte QuoteStatusId { get; set; }
        public DateTime QuoteDateCreated { get; set; }
        public DateTime QuoteDateModified { get; set; }
        public DateTime QuoteDateExpires { get; set; }
        public string QuoteNumber { get; set; }
        public decimal? QuoteDiscountAmount { get; set; }
        public decimal? QuoteDiscountPercent { get; set; }
        public string QuoteUrlKey { get; set; }
        public string QuotePassword { get; set; }
        public string Notes { get; set; }
    }
}
