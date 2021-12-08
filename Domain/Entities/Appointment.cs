using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Appointment 
    {
        public int Id { get; set; }

        public int StatusCode { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }        

        public ICollection<AppointmentService> AppointmentServices { get; set; } 

        public Account Account { get; set; }

        public Employee Employee { get; set; }
    }
}
