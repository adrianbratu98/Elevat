using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<int> Register(string email, string password, string username);
        Task<string> Login(string email, string password);
    }
}
