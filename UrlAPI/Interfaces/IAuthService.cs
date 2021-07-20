using System;
using System.Threading.Tasks;
using url.api.ViewModels;

namespace url.api.Interfaces
{
    public interface IAuthService : IDisposable
    {
        Task<LoginResponseViewModel> RegisterUser(RegisterUserViewModel registerUser);

        Task<LoginResponseViewModel> Login(LoginUserViewModel loginUser);

        Task<bool> RecoverPassword(RegisterUserViewModel registerUser);

        Task<bool> ChangePassword(RegisterUserViewModel registerUser);
    }
}