using Application.Common.Interfaces;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class UserAccountQuery : IRequest<UserAccountDto>
    {
        public int IdentityId { get; set; }
    }

    public class UserAccountQueryHandler : IRequestHandler<UserAccountQuery, UserAccountDto>
    {

        private readonly IElevatDbContext _context;

        public UserAccountQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccountDto> Handle(UserAccountQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _context.UserAccounts.FirstAsync(user => user.Id == request.IdentityId);
            return new UserAccountDto()
            {
                Id = userAccount.Id,
                FirstName = userAccount.FirstName
            };
        }
    }
}
