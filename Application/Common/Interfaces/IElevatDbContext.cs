using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IElevatDbContext 
    {
        DbContext Instance { get; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeService> EmployeesServices { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
