using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            Cabins = new HashSet<Cabin>();
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Addresses { get; set; }
        public string Email { get; set; }
        public int? IdJob { get; set; }
        public int? IdManagementAccount { get; set; }

        public virtual Job IdJobNavigation { get; set; }
        public virtual ManagementAccount IdManagementAccountNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
