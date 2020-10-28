using System;
using System.Collections.Generic;

namespace ps_utn_api_database.Models
{
    public partial class Roles
    {
        public int IntRole { get; set; }
        public string Description { get; set; }

        public virtual Users Users { get; set; }
    }
}
