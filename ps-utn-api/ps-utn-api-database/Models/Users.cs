using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Users
    {
        public Users()
        {
            Employees = new HashSet<Employees>();
        }

        public int IdUser { get; set; }
        public string Mail { get; set; }
        public string SecondMail { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string RestartPasword { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdRole { get; set; }

        public virtual Roles IdUserNavigation { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
