using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public int AccountId { get; set; }

        public int ProgramCode { get; set; }

        public long Sallary { get; set; }

        public List<int> ServiceIds { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IElevatDbContext _context;

        public CreateEmployeeCommandHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstAsync(account => account.Id == request.AccountId);

            var newEmployee = new Employee()
            {
                ProgramCode = request.ProgramCode,
                Sallary = request.Sallary,
            };                      

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync(cancellationToken);
            account.EmployeeId = newEmployee.Id;

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync(cancellationToken);

            await _context.EmployeesServices.AddRangeAsync(request.ServiceIds
                .Select(serviceId => new EmployeeService()
                {
                    EmployeeId = newEmployee.Id,
                    ServiceId = serviceId
                }));

            await _context.SaveChangesAsync(cancellationToken);

            return newEmployee.Id;
        }
    }
}
