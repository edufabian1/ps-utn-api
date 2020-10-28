using System;

namespace ManagementEsports.Models
{
    public class Contract
    {
        public int IdContract { get; set; }
        public DateTime? InitDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CashMonth { get; set; }
        public decimal? CashTotal { get; set; }
        public string RefPartner { get; set; }
        public string Phone { get; set; }
        public int? IdEmployee { get; set; }
    }
}
