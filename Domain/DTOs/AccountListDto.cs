﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AccountListDto
    {
        public int Id {  get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public EmployeeListDto Employee { get; set; }
    }   
}
