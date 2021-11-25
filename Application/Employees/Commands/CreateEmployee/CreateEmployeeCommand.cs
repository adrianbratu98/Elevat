using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
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
        public int UserId { get; set; }

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
            var employeeId = (await _context.Employees.AddAsync(new Employee())).Entity.Id;
            var employeeServices = request.ServiceIds
                .Select(serviceId => new EmployeeService()
                {
                    EmployeeId = employeeId,
                    ServiceId = serviceId
                })
                .ToList();
            await _context.EmployeesServices.AddRangeAsync(employeeServices);
            return employeeId;
        }
    }
}
