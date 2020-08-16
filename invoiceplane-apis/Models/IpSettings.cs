using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpSettings
    {
        public int SettingId { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
    }
}
