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
    public class GetEmployeeServicesQuery : IRequest<List<Service>>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeServicesQueryHandler : IRequestHandler<GetEmployeeServicesQuery, List<Service>>
    {
        private readonly IElevatDbContext _context;

        public GetEmployeeServicesQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> Handle(GetEmployeeServicesQuery request, CancellationToken cancellationToken)
        {
            var service = _context.EmployeesServices.Where(x => x.EmployeeId == request.Id).Select(x => x.Service);
            return await service.ToListAsync();
        }
    }
}
