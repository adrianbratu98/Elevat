using Application.Common.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
    public class GetServiceListQuery : IRequest<List<ServiceDTO>>
    {
        public string SortColumn { get; set; }
        
        public bool SortAscending { get; set; }

        public string NameFilter { get; set; }
    }

    public class GetServiceListQueryHandler : IRequestHandler<GetServiceListQuery, List<ServiceDTO>>
    {

        private readonly IElevatDbContext _context;

        public GetServiceListQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceDTO>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
        {

            var query = _context.Services
                .Select(service => new ServiceDTO 
                { 
                    Id = service.Id, 
                    Name = service.Name, 
                    Minutes = service.Minutes, 
                    Price = service.Price 
                });

            if(request.SortColumn != null)
            {
                switch (request.SortColumn)
                {
                    case "Name":
                        if (request.SortAscending)
                            query = query.OrderBy(service => service.Name);
                        else
                            query = query.OrderByDescending(service => service.Name);
                        break;
                    case "Price":
                        if (request.SortAscending)
                            query = query.OrderBy(service => service.Price);
                        else
                            query = query.OrderByDescending(service => service.Price);
                        break;
                    case "Minutes":
                        if (request.SortAscending)
                            query = query.OrderBy(service => service.Minutes);
                        else
                            query = query.OrderByDescending(service => service.Minutes);
                        break;
                };
            }
            if (request.NameFilter != null)
                query = query.Where(service => service.Name.ToLower().Contains(request.NameFilter.ToLower()));
            return await query.ToListAsync();
        }
    }
}
