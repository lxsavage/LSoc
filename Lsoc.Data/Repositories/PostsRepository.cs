using System.Linq.Expressions;
using Lsoc.Core.Models;
using Lsoc.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lsoc.Data.Repositories;

public class PostsRepository : Repository<Post>, IPostsRepository
{
    public PostsRepository(DbContext Context)
        : base(Context)
    {
    }

    public async Task<Post> GetPostByIdAsync(int PostId)
    {
        return await LsocDbContext.Posts.FindAsync(PostId);
    }

    private LsocDbContext? LsocDbContext => Context as LsocDbContext;
}