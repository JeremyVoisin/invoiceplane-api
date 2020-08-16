using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceAmounts
    {
        public int InvoiceAmountId { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceSign { get; set; }
        public decimal? InvoiceItemSubtotal { get; set; }
        public decimal? InvoiceItemTaxTotal { get; set; }
        public decimal? InvoiceTaxTotal { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public decimal? InvoicePaid { get; set; }
        public decimal? InvoiceBalance { get; set; }
    }
}
