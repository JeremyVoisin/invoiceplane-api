using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoicesRecurring
    {
        public int InvoiceRecurringId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime RecurStartDate { get; set; }
        public DateTime RecurEndDate { get; set; }
        public string RecurFrequency { get; set; }
        public DateTime RecurNextDate { get; set; }
    }
}
