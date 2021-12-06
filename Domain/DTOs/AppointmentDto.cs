using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        
        public List<int> ServiceIds  { get; set; }

        public int StatusCode { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }
    }
}
