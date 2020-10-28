using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Employees = new HashSet<Employees>();
        }

        public int IdCity { get; set; }
        public string Description { get; set; }
        public int? IdCountry { get; set; }

        public virtual Countries IdCountryNavigation { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
