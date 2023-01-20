using System.Security.Claims;
using AutoMapper;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;

namespace Lsoc.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(
        IMapper mapper,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task RegisterAsync(SignInViewModel credentials)
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

    public async Task<UserViewModel?> LoginAsync(SignInViewModel credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password)) return null;

        var userIdentity = await _userManager.FindByNameAsync(credentials.Username);
        if (userIdentity == null) return null;

        var passwordSignInOutcome =
            await _signInManager.PasswordSignInAsync(userIdentity, credentials.Password, true, false);

        return passwordSignInOutcome.Succeeded
            ? _mapper.Map<UserViewModel>(userIdentity)
            : null;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    public async Task<UserViewModel?> GetMeAsync() => _httpContextAccessor?.HttpContext?.User != null
        ? _mapper.Map<UserViewModel>(await GetCurrentUserAsync())
        : null;
    
    public async Task<IdentityUser> GetCurrentUserAsync()
    {
        var userClaims = _httpContextAccessor?.HttpContext?.User;
        if (userClaims == null) throw new KeyNotFoundException();;
        
        var userIdentity = await _userManager.GetUserAsync(userClaims);
        if (userIdentity == null) throw new KeyNotFoundException();;

        return userIdentity;
    }
    
    public async Task<IdentityUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}