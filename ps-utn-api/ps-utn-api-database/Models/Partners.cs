using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Partners
    {
        public int IdPartner { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string UrlPage { get; set; }
        public string UrlInstagram { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public int? IdContract { get; set; }

        public virtual Contracts IdContractNavigation { get; set; }
    }
}
