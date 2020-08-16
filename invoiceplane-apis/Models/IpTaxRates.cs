using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpTaxRates
    {
        public int TaxRateId { get; set; }
        public string TaxRateName { get; set; }
        public decimal TaxRatePercent { get; set; }
    }
}
