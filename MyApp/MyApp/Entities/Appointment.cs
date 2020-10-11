using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Entities
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
