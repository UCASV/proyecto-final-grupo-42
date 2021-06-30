using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Obserbation
    {
        public int IdAppointment { get; set; }
        public int IdSymptom { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual Symptom IdSymptomNavigation { get; set; }
    }
}
