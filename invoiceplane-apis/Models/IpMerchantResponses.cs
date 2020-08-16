using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpMerchantResponses
    {
        public int MerchantResponseId { get; set; }
        public int InvoiceId { get; set; }
        public byte? MerchantResponseSuccessful { get; set; }
        public DateTime MerchantResponseDate { get; set; }
        public string MerchantResponseDriver { get; set; }
        public string MerchantResponse { get; set; }
        public string MerchantResponseReference { get; set; }
    }
}
