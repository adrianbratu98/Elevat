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

namespace Application.Employees.Queries
{
    public class GetEmployeesListQuery : IRequest<List<Employee>>
    {
    }

    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, List<Employee>>
    {

        private readonly IElevatDbContext _context;

        public GetEmployeesListQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
