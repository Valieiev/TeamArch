using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}