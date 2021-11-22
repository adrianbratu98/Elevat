using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
    public class GetEmployeeServicesQuery : IRequest<List<Employee>>
    {
        public int Id { get; set; }
    }

    public class GetServiceEmployeesQueryHandler : IRequestHandler<GetEmployeeServicesQuery, List<Employee>>
    {
        private readonly IElevatDbContext _context;

        public GetServiceEmployeesQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(GetEmployeeServicesQuery request, CancellationToken cancellationToken)
        {
            var service = _context.EmployeesServices.Where(x => x.ServiceId == request.Id).Select(x => x.Employee);
            return await service.ToListAsync();
        }
    }
    
}
