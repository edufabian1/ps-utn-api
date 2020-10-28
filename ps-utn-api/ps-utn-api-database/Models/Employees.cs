using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? IdCity { get; set; }
        public int? IdUser { get; set; }

        public virtual Cities IdCityNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
