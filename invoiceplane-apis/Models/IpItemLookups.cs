using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpItemLookups
    {
        public int ItemLookupId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
