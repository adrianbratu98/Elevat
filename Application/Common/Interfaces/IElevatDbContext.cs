using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IElevatDbContext 
    {
        DbSet<Service> Services { get; set; }

        DbSet<Account> Accounts { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<EmployeeService> EmployeesServices { get; set; }

        DbSet<Appointment> Appointments { get; set; }

        DbSet<AppointmentService> AppointmentService { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
