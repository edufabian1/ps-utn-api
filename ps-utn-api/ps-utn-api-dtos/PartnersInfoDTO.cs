using System;
using System.Diagnostics;

namespace ps_utn_api_dtos
{
    public class PartnersInfoDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string UrlPage { get; set; }
    }

    public class PartnerDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlPage { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double CashMonth { get; set; }
        public string RefPartner { get; set; }
        public string Phone { get; set; }
        public int IdEmployee { get; set; }
    }
}
