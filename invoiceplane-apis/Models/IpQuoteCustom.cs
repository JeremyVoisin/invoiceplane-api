using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpQuoteCustom
    {
        public int QuoteCustomId { get; set; }
        public int QuoteId { get; set; }
        public int QuoteCustomFieldid { get; set; }
        public string QuoteCustomFieldvalue { get; set; }
    }
}
