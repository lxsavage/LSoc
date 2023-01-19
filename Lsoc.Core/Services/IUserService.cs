using Lsoc.Core.ViewModels;

namespace Lsoc.Core.Services;

public interface IUserService
{
    /// <summary>
    /// Register a User in the DB
    /// </summary>
    /// <param name="credentials">The credentials of the user account to register</param>
    Task Register(SignInViewModel credentials);
    
    /// <summary>
    /// Attempts to log in a user with the given credentials
    /// </summary>
    /// <param name="credentials">
    /// The credentials of the user account to attempt to log in to
    /// </param>
    /// <returns>
    /// A model representing the user that was logged in if successful, otherwise null
    /// </returns>
    Task<UserViewModel?> Login(SignInViewModel credentials);
    
    /// <summary>
    /// If the current session is logged into a user account, log out of it, otherwise do nothing
    /// </summary>
    Task Logout();
    
    /// <summary>
    /// Get the details of the currently-logged-in user
    /// </summary>
    /// <returns>A model representing the user</returns>
    Task<UserViewModel?> Me();
}