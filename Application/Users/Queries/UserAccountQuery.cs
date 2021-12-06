using Application.Common.Interfaces;
using Domain.Dtos;
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
        public int Id { get; set; }
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
            var userAccount = await _context.Accounts.FirstAsync(user => user.Id == request.Id);
            return new AccountDto()
            {
                Id = userAccount.Id,
                Email = userAccount.Email,
                FirstName = userAccount.FirstName,
                LastName = userAccount.LastName,
                Age = userAccount.Age
            };
        }
    }
}
