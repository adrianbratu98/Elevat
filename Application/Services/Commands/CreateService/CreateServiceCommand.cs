using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public double Price { get; set; }
    }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IElevatDbContext _context;
        public CreateServiceCommandHandler(IElevatDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Service
            {
                Id = request.Id,
                Name = request.Name,
                Minutes = request.Minutes,
                Price = request.Price
            };

            _context.Services.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
