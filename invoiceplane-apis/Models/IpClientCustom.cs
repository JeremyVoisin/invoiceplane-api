using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpClientCustom
    {
        public int ClientCustomId { get; set; }
        public int ClientId { get; set; }
        public int ClientCustomFieldid { get; set; }
        public string ClientCustomFieldvalue { get; set; }
    }
}
