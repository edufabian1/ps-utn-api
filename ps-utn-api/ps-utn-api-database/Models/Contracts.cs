using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Contracts
    {
        public Contracts()
        {
            Partners = new HashSet<Partners>();
        }

        public int IdContract { get; set; }
        public DateTime? InitDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? CashMonth { get; set; }
        public decimal? CashTotal { get; set; }
        public string RefPartner { get; set; }
        public string Phone { get; set; }
        public string Cuit { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employees IdEmployeeNavigation { get; set; }
        public virtual ICollection<Partners> Partners { get; set; }
    }
}
