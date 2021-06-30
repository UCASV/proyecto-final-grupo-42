using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Obserbations = new HashSet<Obserbation>();
        }

        public int Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int IdPriority { get; set; }
        public int IdCitizen { get; set; }
        public int IdEmployee { get; set; }
        public int? IdVaccination { get; set; }
        public int? IdVaccine { get; set; }
        public DateTime? AssistanceDate { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public bool? Observation { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Priority IdPriorityNavigation { get; set; }
        public virtual Vaccine IdVaccineNavigation { get; set; }
        public virtual ICollection<Obserbation> Obserbations { get; set; }
    }
}
