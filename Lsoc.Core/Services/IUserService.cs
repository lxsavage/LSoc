using Lsoc.Core.ViewModels;

namespace Lsoc.Core.Services;

public interface IUserService
{
    Task Register(SignInViewModel credentials);
    Task<UserViewModel?> Login(SignInViewModel credentials);
    Task Logout();
}