using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Job1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
