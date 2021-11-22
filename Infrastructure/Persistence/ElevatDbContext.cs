using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ElevatDbContext : DbContext, IElevatDbContext
    {
        public DbContext Instance => this;
        public ElevatDbContext(DbContextOptions<ElevatDbContext> options) : base(options) { }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeService> EmployeesServices { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
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
        }
    }
}
