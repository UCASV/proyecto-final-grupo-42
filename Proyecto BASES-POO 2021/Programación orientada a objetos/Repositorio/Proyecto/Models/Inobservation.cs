using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Inobservation
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Vaccine1 { get; set; }
        public string Symptom { get; set; }
        public int? Minutesymptom { get; set; }
    }
}
