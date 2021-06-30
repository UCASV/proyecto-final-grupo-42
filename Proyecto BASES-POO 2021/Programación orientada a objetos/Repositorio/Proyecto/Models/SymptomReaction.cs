using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class SymptomReaction
    {
        public int Id { get; set; }
        public int? IdSymptom { get; set; }
        public int ReactionTime { get; set; }

        public virtual Symptom IdSymptomNavigation { get; set; }
    }
}
