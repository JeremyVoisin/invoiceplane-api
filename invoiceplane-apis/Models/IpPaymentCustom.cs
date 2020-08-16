using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpPaymentCustom
    {
        public int PaymentCustomId { get; set; }
        public int PaymentId { get; set; }
        public int PaymentCustomFieldid { get; set; }
        public string PaymentCustomFieldvalue { get; set; }
    }
}
