using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int ProgramCode { get; set; }

        public long Sallary { get; set; }

        public int ProgramId { get; set; }

        public ICollection<EmployeeService> EmployeeServices { get; set; }

        public Program Program { get; set; }
    }
}
