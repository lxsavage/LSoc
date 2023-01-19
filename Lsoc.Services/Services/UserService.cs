using System.Security.Claims;
using AutoMapper;
using Lsoc.Core;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Lsoc.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IHttpContextAccessor _httpContext;

    public UserService(
        IMapper mapper,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IHttpContextAccessor httpContext)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContext = httpContext;
    }
    
    public async Task Register(SignInViewModel credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password)) return;

        var user = new IdentityUser
        {
            UserName = credentials.Username
        };

        IdentityResult creationOutcome;
        try
        {
            creationOutcome = await _userManager.CreateAsync(user, credentials.Password);
        }
        catch (SqliteException)
        {
            await Console.Error.WriteLineAsync($"Error: Unable to create user {credentials.Username} in DB");
            return;
        }

        if (!creationOutcome.Succeeded)
        {
            await Console.Error.WriteLineAsync($"Error: Failure in user {credentials.Username} creation");
            return;
        }

        Console.WriteLine($"User {credentials.Username} has been successfully created!");
    }

    public async Task<UserViewModel?> Login(SignInViewModel credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password)) return null;

        var userIdentity = await _userManager.FindByNameAsync(credentials.Username);
        if (userIdentity == null) return null;

        var passwordSignInOutcome =
            await _signInManager.PasswordSignInAsync(userIdentity, credentials.Password, true, false);

        if (!passwordSignInOutcome.Succeeded) return null;
        
        return _mapper.Map<UserViewModel>(userIdentity);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserViewModel?> Me()
    {
        var userClaims = _httpContext?.HttpContext?.User;
        if (userClaims == null) return null;
        
        var userIdentity = await _userManager.GetUserAsync(userClaims);
        return userIdentity == null ? null : _mapper.Map<UserViewModel>(userIdentity);
    }
}