using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IElevatDbContext _context;
        private readonly IIdentityService _identity;
        public RegisterUserCommandHandler(IElevatDbContext context, IIdentityService identity)
        {
            _context = context;
            _identity = identity;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _identity.Register(request.Email, request.Password);
            var account = new Account() { Email = request.Email, FirstName = request.FirstName };
            var saved = await _context.Accounts.AddAsync(account, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saved.Entity.Id;
        }
    }

}
