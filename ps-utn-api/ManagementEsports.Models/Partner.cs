using System.Collections.Generic;
using System.Text;

namespace ManagementEsports.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string UrlPage { get; set; }
        public string UrlInstagram { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public Contract Contract { get; set; }
    }
}
