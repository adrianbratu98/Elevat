using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }
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
            var identityId = await _identity.Register(request.Email, request.Password, request.Username);
            var account = new Account() 
            { 
                Id = identityId,
                Username = request.Username,
                Email = request.Email, 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };
            await _context.Accounts.AddAsync(account, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return account.Id;
        }
    }

}
