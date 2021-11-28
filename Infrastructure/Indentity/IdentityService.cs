using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Indentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Elevat.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public IdentityService(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;

        }

        public async Task<int> Register(string email, string password)
        {
            try
            {
                var user = new ApplicationUser()
                {
                    Email = email,
                    UserName = email.Split("@")[0],
                };
                var ceva = await _userManager.CreateAsync(user, password);
                var createdUser = await _userManager.FindByEmailAsync(email);
                return createdUser.Id;
            }
            catch(Exception e)
            {
                return 0;
            }
       
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await (_userManager.FindByEmailAsync(email));
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Auth:JWT_Secret"))), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else if (user == null)
            {
                throw new Exception("User doesn't exist.");
            }
            else
            {
                throw new Exception("Password is incorrect.");
            }     
   
        }
              
    }

}
