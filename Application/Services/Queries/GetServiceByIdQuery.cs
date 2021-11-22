using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
    public class GetServiceByIdQuery : IRequest<Service>
    {
        public int Id { get; set; }
    }

    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Service>
    {
        private readonly IElevatDbContext _context;

        public GetServiceByIdQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
