using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Record
    {
        public int IdEmployee { get; set; }
        public int IdManagementLogin { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ManagementLogin IdManagementLoginNavigation { get; set; }
    }
}
