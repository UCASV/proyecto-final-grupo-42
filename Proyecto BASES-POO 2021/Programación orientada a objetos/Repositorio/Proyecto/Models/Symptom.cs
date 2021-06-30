using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Symptom
    {
        public Symptom()
        {
            Obserbations = new HashSet<Obserbation>();
            SymptomReactions = new HashSet<SymptomReaction>();
        }

        public int Id { get; set; }
        public string Symptom1 { get; set; }

        public virtual ICollection<Obserbation> Obserbations { get; set; }
        public virtual ICollection<SymptomReaction> SymptomReactions { get; set; }
    }
}
