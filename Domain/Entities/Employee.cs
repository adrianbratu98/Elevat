using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeService> EmployeesServices { get; set; }

    }
}
