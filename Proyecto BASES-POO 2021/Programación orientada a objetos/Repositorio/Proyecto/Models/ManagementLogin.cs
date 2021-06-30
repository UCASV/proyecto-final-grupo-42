using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class ManagementLogin
    {
        public ManagementLogin()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public DateTime DateHour { get; set; }
        public int IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
