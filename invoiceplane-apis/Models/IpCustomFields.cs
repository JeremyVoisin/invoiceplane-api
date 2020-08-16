using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpCustomFields
    {
        public int CustomFieldId { get; set; }
        public string CustomFieldTable { get; set; }
        public string CustomFieldLabel { get; set; }
        public string CustomFieldType { get; set; }
        public int? CustomFieldLocation { get; set; }
        public int? CustomFieldOrder { get; set; }
    }
}
