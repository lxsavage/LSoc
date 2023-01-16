using Lsoc.Core.Models;

namespace Lsoc.Core.Repositories;

public interface IPostsRepository : IRepository<Post>
{
    Task<int> CreatePostAsync(Post post);
    Task EditPostByIdAsync(int id, Post modified);
    Task DeletePostByIdAsync(int id);
}