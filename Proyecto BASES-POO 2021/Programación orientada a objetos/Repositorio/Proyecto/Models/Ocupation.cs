using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Ocupation
    {
        public Ocupation()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string CommonName { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
