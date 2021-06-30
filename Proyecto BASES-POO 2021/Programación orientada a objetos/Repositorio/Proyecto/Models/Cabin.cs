using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Cabin
    {
        public Cabin()
        {
            ManagementLogins = new HashSet<ManagementLogin>();
        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string Direction { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<ManagementLogin> ManagementLogins { get; set; }
    }
}
