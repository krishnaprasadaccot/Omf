using Omf.Common.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Identity.Domain.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string name);
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}
