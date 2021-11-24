using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.CreateService
{
    public class UpdateServiceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public double Price { get; set; }
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, int>
    {
        private readonly IElevatDbContext _context;
        public UpdateServiceCommandHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(request.Id);

            service.Name = request.Name;
            service.Minutes = request.Minutes;
            service.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);

            return service.Id;
        }
    }
}
