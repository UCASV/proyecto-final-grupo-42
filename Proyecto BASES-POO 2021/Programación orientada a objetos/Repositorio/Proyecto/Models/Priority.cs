using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Priority
    {
        public Priority()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Priority1 { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
