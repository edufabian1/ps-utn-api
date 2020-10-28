using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }

        public int IdCountry { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
