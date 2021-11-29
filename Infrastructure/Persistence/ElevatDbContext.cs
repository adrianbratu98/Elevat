using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ElevatDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>, IElevatDbContext 
    {
        public ElevatDbContext(DbContextOptions<ElevatDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<EmployeeService> EmployeesServices { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeService>().HasKey(sc => new { sc.EmployeeId, sc.ServiceId });

            modelBuilder.Entity<EmployeeService>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(es => es.EmployeesServices)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeService>()
                .HasOne<Service>(s => s.Service)
                .WithMany(es => es.EmployeesServices)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
