using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpSessions
    {
        public string Id { get; set; }
        public string IpAddress { get; set; }
        public int Timestamp { get; set; }
        public byte[] Data { get; set; }
    }
}
