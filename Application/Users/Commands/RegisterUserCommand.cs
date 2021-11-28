using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            try
            {
                var identityId = await _identity.Register(request.Email, request.Password);
                var user = new UserAccount() { IdentityId = identityId, FirstName = request.FirstName };
                var entity = await _context.UserAccounts.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Entity.Id;
            }
            catch(Exception e)
            {
                return 0;
            }
        
        }
    }

}
