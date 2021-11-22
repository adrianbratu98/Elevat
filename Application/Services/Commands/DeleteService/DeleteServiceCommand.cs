using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IElevatDbContext _context;
        public DeleteServiceCommandHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(x => x.Id == request.Id);
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
