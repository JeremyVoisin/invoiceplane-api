using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpEmailTemplates
    {
        public int EmailTemplateId { get; set; }
        public string EmailTemplateTitle { get; set; }
        public string EmailTemplateType { get; set; }
        public string EmailTemplateBody { get; set; }
        public string EmailTemplateSubject { get; set; }
        public string EmailTemplateFromName { get; set; }
        public string EmailTemplateFromEmail { get; set; }
        public string EmailTemplateCc { get; set; }
        public string EmailTemplateBcc { get; set; }
        public string EmailTemplatePdfTemplate { get; set; }
    }
}
