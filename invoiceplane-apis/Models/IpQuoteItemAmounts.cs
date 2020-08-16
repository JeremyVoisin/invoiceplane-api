using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpQuoteItemAmounts
    {
        public int ItemAmountId { get; set; }
        public int ItemId { get; set; }
        public decimal? ItemSubtotal { get; set; }
        public decimal? ItemTaxTotal { get; set; }
        public decimal? ItemDiscount { get; set; }
        public decimal? ItemTotal { get; set; }
    }
}
