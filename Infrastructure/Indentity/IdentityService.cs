using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Indentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Elevat.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUser(string firstName, string lastName, string email, string password)
        {
            var user = new ApplicationUser()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
            };
            await _userManager.CreateAsync(user, password);
            var createdUser = await _userManager.FindByEmailAsync(email);
            return createdUser.Id;
        }
    }
}
