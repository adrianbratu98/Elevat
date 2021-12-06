using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; }

        public int ServiceId { get; set; }


        public Appointment Appointment { get; set; }

        public Service Service { get; set; }
    }
}
