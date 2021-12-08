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
            var userAccount = await _context.Accounts.FirstAsync(user => user.Id == request.UserId);
            var employee = new Employee()
            {

            }
            var account = await _context.Employees.Add(employee)
            return 0;
        }
    }
}
