using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public double Price { get; set; }
        public ICollection<EmployeeService> EmployeesServices { get; set; }
    }
}
