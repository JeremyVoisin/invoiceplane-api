using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpImportDetails
    {
        public int ImportDetailId { get; set; }
        public int ImportId { get; set; }
        public string ImportLangKey { get; set; }
        public string ImportTableName { get; set; }
        public int ImportRecordId { get; set; }
    }
}
