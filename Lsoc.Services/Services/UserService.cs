using AutoMapper;
using Lsoc.Core;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Lsoc.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserService(
        IMapper mapper,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
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

        var user = await _userManager.FindByNameAsync(credentials.Username);
        if (user == null) return null;

        var passwordSignInOutcome =
            await _signInManager.PasswordSignInAsync(user, credentials.Password, true, false);

        if (!passwordSignInOutcome.Succeeded) return null;
        
        var mappedUser = _mapper.Map<UserViewModel>(user);
        return mappedUser;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}