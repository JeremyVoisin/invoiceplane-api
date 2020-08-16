using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceCustom
    {
        public int InvoiceCustomId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceCustomFieldid { get; set; }
        public string InvoiceCustomFieldvalue { get; set; }
    }
}
