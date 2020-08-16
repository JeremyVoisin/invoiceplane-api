using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpVersions
    {
        public int VersionId { get; set; }
        public string VersionDateApplied { get; set; }
        public string VersionFile { get; set; }
        public int VersionSqlErrors { get; set; }
    }
}
