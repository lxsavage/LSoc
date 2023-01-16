using Lsoc.Core.Models;

namespace Lsoc.Core.Services;

public interface IPostsService
{
    Task<Post> GetPost(int id);
}