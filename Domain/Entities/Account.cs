using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public int? EmployeeId { get; set; }


        public Employee Employee { get; set; }
    }
}
