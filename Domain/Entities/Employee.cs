using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : IApplicationUser
    {
        public int Id { get; set; }

        public ICollection<EmployeeService> EmployeesServices { get; set; }

        public string Name { get; set; }
    }
}
