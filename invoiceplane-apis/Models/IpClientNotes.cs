using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpClientNotes
    {
        public int ClientNoteId { get; set; }
        public int ClientId { get; set; }
        public DateTime ClientNoteDate { get; set; }
        public string ClientNote { get; set; }
    }
}
