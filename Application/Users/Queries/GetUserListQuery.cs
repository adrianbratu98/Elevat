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

namespace Application.Users.Queries
{
    public class GetUserListQuery : IRequest<List<AccountListDto>>
    {

    }

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<AccountListDto>>
    {

        private readonly IElevatDbContext _context;

        public GetUserListQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountListDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Accounts
                .Select(account => new
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Age = account.Age.ToString(),
                    Email = account.Email,
                    Employee = new
                    {
                        Program = account.Employee.Program.Name,
                        Sallary = account.Employee.Sallary.ToString(),
                        ServiceNames = account.Employee.EmployeeServices
                            .Select(employeeService => employeeService.Service.Name)
                    }
                })
                .ToListAsync();
            return query
                .Select(item => new AccountListDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age?.ToString(),
                    Email = item.Email,
                    Employee = item.Employee == null ? 
                        null :
                        new EmployeeListDto()
                        {
                            Program = item.Employee.Program,
                            Sallary = item.Employee.Sallary?.ToString(),
                            Services = String.Join(", ", item.Employee.ServiceNames)
                        }
                })
                .ToList();
        }
    }
}
