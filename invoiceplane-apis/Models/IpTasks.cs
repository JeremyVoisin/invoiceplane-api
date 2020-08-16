using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpTasks
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public decimal? TaskPrice { get; set; }
        public DateTime TaskFinishDate { get; set; }
        public byte TaskStatus { get; set; }
        public int TaxRateId { get; set; }
    }
}
