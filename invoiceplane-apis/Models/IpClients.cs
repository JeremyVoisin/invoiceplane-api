using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpClients
    {
        public int ClientId { get; set; }
        public DateTime ClientDateCreated { get; set; }
        public DateTime ClientDateModified { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string ClientCity { get; set; }
        public string ClientState { get; set; }
        public string ClientZip { get; set; }
        public string ClientCountry { get; set; }
        public string ClientPhone { get; set; }
        public string ClientFax { get; set; }
        public string ClientMobile { get; set; }
        public string ClientEmail { get; set; }
        public string ClientWeb { get; set; }
        public string ClientVatId { get; set; }
        public string ClientTaxCode { get; set; }
        public string ClientLanguage { get; set; }
        public int ClientActive { get; set; }
        public string ClientSurname { get; set; }
        public string ClientAvs { get; set; }
        public string ClientInsurednumber { get; set; }
        public string ClientVeka { get; set; }
        public DateTime? ClientBirthdate { get; set; }
        public int? ClientGender { get; set; }
    }
}
