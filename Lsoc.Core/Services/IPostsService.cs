using Lsoc.Core.Models;
using Lsoc.Core.ViewModels;

namespace Lsoc.Core.Services;

public interface IPostsService
{
    Task<Post?> GetPostAsync(int id);
    Task<int> CreatePostAsync(CreatePostViewModel post);
    Task EditPostAsync(int id, CreatePostViewModel post);
    Task DeletePostAsync(int id);
}