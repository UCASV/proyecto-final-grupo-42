using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Dui { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Direction { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int? IdChronicDiseases { get; set; }
        public int IdOccupation { get; set; }

        public virtual ChronicDisease IdChronicDiseasesNavigation { get; set; }
        public virtual Ocupation IdOccupationNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
