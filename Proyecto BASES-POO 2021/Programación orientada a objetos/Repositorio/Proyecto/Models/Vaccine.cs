using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Vaccine
    {
        public Vaccine()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Vaccine1 { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
