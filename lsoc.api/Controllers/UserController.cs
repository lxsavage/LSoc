using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lsoc.API.Controllers;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task Register([FromBody] SignInViewModel credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
        {
            Response.StatusCode = 400;
            return;
        }

        await _userService.Register(credentials);
    }

    [HttpPost("login")]
    public async Task<UserViewModel?> Login([FromBody] SignInViewModel credentials)
    {
        if (!string.IsNullOrWhiteSpace(credentials.Username) && !string.IsNullOrWhiteSpace(credentials.Password))
            return await _userService.Login(credentials);
        
        Response.StatusCode = 400;
        return null;

    }

    [HttpPost("logout")]
    public async Task Logout()
    {
        await _userService.Logout();
    }
}