using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class ManagementAccount
    {
        public ManagementAccount()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string UserManagement { get; set; }
        public string PasswordManagement { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
