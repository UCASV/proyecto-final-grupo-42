using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class SymptomCitizen
    {
        public int Id  { get; set; }
        public int? IdAppointmen { get; set; }
        public string Symptom { get; set; }
        public int? Symptomminutes { get; set; }
    }
}
