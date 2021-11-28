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
        public string FirstName { get; set; }
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
            try
            {
                var applicationUserId = await _identity.Register(request.Email, request.Password);
                var user = new UserAccount() { ApplicationUserId = applicationUserId, FirstName = request.FirstName };
                var userId = (await _context.UserAccounts.AddAsync(user)).Entity.Id;
                await _context.SaveChangesAsync(cancellationToken);
                return userId;
            }
            catch(Exception e)
            {
                return 0;
            }
        
        }
    }

}
