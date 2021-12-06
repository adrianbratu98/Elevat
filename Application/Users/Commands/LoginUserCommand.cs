using Application.Common.Interfaces;
using Domain.Dtos;
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
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IIdentityService _identity;

        public LoginUserCommandHandler(IIdentityService identity)
        {
            _identity = identity;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _identity.Login(request.Email, request.Password);
        }

    }

}
