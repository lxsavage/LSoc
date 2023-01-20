using Lsoc.Core.Models;
using Lsoc.Core.ViewModels;

namespace Lsoc.Core.Services;

public interface IPostsService
{
    /// <summary>
    /// Get the details of an individual post by ID
    /// </summary>
    /// <param name="id">The ID of the post to retrieve</param>
    /// <returns>A model representing the post if found, otherwise null</returns>
    Task<PostViewModel?> GetPostAsync(int id);
    
    /// <summary>
    /// Attempts to create a new post as the currently-logged-in user
    /// </summary>
    /// <param name="post">The data to create the post with</param>
    /// <returns>The ID of the post that was just created</returns>
    Task<int> CreatePostAsync(CreatePostViewModel post);
    
    /// <summary>
    /// Edits an already-existing post
    /// </summary>
    /// <param name="id">The ID of the post to edit</param>
    /// <param name="post">The new content of the post</param>
    Task EditPostAsync(int id, CreatePostViewModel post);
    
    /// <summary>
    /// Deletes the specified post
    /// </summary>
    /// <param name="id">The ID of the post to delete</param>
    Task DeletePostAsync(int id);

    /// <summary>
    /// Retrieves all posts
    /// </summary>
    /// <returns>
    /// A list of models representing each of the <b>count</b> most recent posts
    /// </returns>
    Task<List<PostViewModel?>> GetPostsAsync();
}