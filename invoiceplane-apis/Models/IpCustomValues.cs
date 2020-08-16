using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpCustomValues
    {
        public int CustomValuesId { get; set; }
        public int CustomValuesField { get; set; }
        public string CustomValuesValue { get; set; }
    }
}
