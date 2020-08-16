using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpProjects
    {
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public string ProjectName { get; set; }
    }
}
