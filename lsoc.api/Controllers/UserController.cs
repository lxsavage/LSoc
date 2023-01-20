using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        await _userService.RegisterAsync(credentials);
    }

    [HttpPost("login")]
    public async Task<UserViewModel?> Login([FromBody] SignInViewModel credentials)
    {
        UserViewModel? user = null;
        if (!string.IsNullOrWhiteSpace(credentials.Username) && !string.IsNullOrWhiteSpace(credentials.Password))
        {
            user = await _userService.LoginAsync(credentials);
            if (user == null) Response.StatusCode = 403;
        }
        else
        {
            Response.StatusCode = 400;
        }
        return user;

    }

    [HttpPost("logout")]
    public async Task Logout()
    {
        await _userService.LogoutAsync();
    }

    [HttpGet("me"), Authorize]
    public async Task<UserViewModel?> Me()
    {
        return await _userService.GetMeAsync();
    }
}