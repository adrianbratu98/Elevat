using Application.Common.Interfaces;
using Domain.Dtos;
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
    public class GetEmployeeListQuery : IRequest<List<Account>>
    {

    }

    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<Account>>
    {
        private readonly IElevatDbContext _context;

        public GetEmployeeListQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Accounts.Where(account => account.EmployeeId != null);
            return await query.ToListAsync();
        }
    }
}
