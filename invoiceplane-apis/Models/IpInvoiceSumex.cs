using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpInvoiceSumex
    {
        public int SumexId { get; set; }
        public int SumexInvoice { get; set; }
        public int SumexReason { get; set; }
        public string SumexDiagnosis { get; set; }
        public string SumexObservations { get; set; }
        public DateTime SumexTreatmentstart { get; set; }
        public DateTime SumexTreatmentend { get; set; }
        public DateTime SumexCasedate { get; set; }
        public string SumexCasenumber { get; set; }
    }
}
