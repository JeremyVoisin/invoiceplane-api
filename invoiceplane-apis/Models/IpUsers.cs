using System;
using System.Collections.Generic;

namespace invoiceplane_apis.Models
{
    public partial class IpUsers
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public byte? UserActive { get; set; }
        public DateTime UserDateCreated { get; set; }
        public DateTime UserDateModified { get; set; }
        public string UserLanguage { get; set; }
        public string UserName { get; set; }
        public string UserCompany { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserZip { get; set; }
        public string UserCountry { get; set; }
        public string UserPhone { get; set; }
        public string UserFax { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserWeb { get; set; }
        public string UserVatId { get; set; }
        public string UserTaxCode { get; set; }
        public string UserPsalt { get; set; }
        public int UserAllClients { get; set; }
        public string UserPasswordresetToken { get; set; }
        public string UserSubscribernumber { get; set; }
        public string UserIban { get; set; }
        public long? UserGln { get; set; }
        public string UserRcc { get; set; }
    }
}
