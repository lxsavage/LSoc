using System.Security.Claims;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Lsoc.Core.Services;

public interface IUserService
{
    /// <summary>
    /// Register a User in the DB
    /// </summary>
    /// <param name="credentials">The credentials of the user account to register</param>
    Task RegisterAsync(SignInViewModel credentials);
    
    /// <summary>
    /// Attempts to log in a user with the given credentials
    /// </summary>
    /// <param name="credentials">
    /// The credentials of the user account to attempt to log in to
    /// </param>
    /// <returns>
    /// A model representing the user that was logged in if successful, otherwise null
    /// </returns>
    Task<UserViewModel?> LoginAsync(SignInViewModel credentials);
    
    /// <summary>
    /// If the current session is logged into a user account, log out of it, otherwise do nothing
    /// </summary>
    Task LogoutAsync();
    
    /// <summary>
    /// Get the details of the currently-logged-in user
    /// </summary>
    /// <returns>A model representing the user</returns>
    Task<UserViewModel?> GetMeAsync();

    /// <summary>
    /// Get the currently-logged-in user
    /// </summary>
    /// <returns>An IdentityUser instance for the current user</returns>
    /// <exception cref="KeyNotFoundException">A user is not logged in currently</exception>
    Task<IdentityUser> GetCurrentUserAsync();

    /// <summary>
    /// Get the user specified
    /// </summary>
    /// <param name="userId">The User ID for the user to retrieve</param>
    /// <returns>An IdentityUser instance for the specified user</returns>
    Task<IdentityUser?> GetUserByIdAsync(string userId);
}