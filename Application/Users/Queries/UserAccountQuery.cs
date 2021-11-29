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
    public class UserAccountQuery : IRequest<AccountDto>
    {
        public string Email { get; set; }
    }

    public class UserAccountQueryHandler : IRequestHandler<UserAccountQuery, AccountDto>
    {

        private readonly IElevatDbContext _context;

        public UserAccountQueryHandler(IElevatDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDto> Handle(UserAccountQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _context.Accounts.FirstAsync(user => user.Email == request.Email);
            return new AccountDto()
            {
                Id = userAccount.Id,
                FirstName = userAccount.FirstName
            };
        }
    }
}
