using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpPayments
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentNote { get; set; }
    }
}
