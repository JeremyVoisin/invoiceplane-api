using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoices
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int InvoiceGroupId { get; set; }
        public byte InvoiceStatusId { get; set; }
        public byte? IsReadOnly { get; set; }
        public string InvoicePassword { get; set; }
        public DateTime InvoiceDateCreated { get; set; }
        public TimeSpan InvoiceTimeCreated { get; set; }
        public DateTime InvoiceDateModified { get; set; }
        public DateTime InvoiceDateDue { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal? InvoiceDiscountAmount { get; set; }
        public decimal? InvoiceDiscountPercent { get; set; }
        public string InvoiceTerms { get; set; }
        public string InvoiceUrlKey { get; set; }
        public int PaymentMethod { get; set; }
        public int? CreditinvoiceParentId { get; set; }
    }
}
