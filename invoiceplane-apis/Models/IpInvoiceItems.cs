using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceItems
    {
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemTaxRateId { get; set; }
        public int? ItemProductId { get; set; }
        public DateTime ItemDateAdded { get; set; }
        public int? ItemTaskId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? ItemDiscountAmount { get; set; }
        public int ItemOrder { get; set; }
        public byte? ItemIsRecurring { get; set; }
        public string ItemProductUnit { get; set; }
        public int? ItemProductUnitId { get; set; }
        public DateTime? ItemDate { get; set; }
    }
}
