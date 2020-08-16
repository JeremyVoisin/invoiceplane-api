using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceGroups
    {
        public int InvoiceGroupId { get; set; }
        public string InvoiceGroupName { get; set; }
        public string InvoiceGroupIdentifierFormat { get; set; }
        public int InvoiceGroupNextId { get; set; }
        public int InvoiceGroupLeftPad { get; set; }
    }
}
