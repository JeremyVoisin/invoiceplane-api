using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpProducts
    {
        public int ProductId { get; set; }
        public int? FamilyId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string ProviderName { get; set; }
        public int? TaxRateId { get; set; }
        public int? UnitId { get; set; }
        public int? ProductTariff { get; set; }
    }
}
