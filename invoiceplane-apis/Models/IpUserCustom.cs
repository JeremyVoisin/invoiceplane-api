using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpUserCustom
    {
        public int UserCustomId { get; set; }
        public int UserId { get; set; }
        public int UserCustomFieldid { get; set; }
        public string UserCustomFieldvalue { get; set; }
    }
}
