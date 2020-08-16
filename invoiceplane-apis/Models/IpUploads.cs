using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpUploads
    {
        public int UploadId { get; set; }
        public int ClientId { get; set; }
        public string UrlKey { get; set; }
        public string FileNameOriginal { get; set; }
        public string FileNameNew { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
