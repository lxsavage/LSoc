using System.Linq.Expressions;
using Lsoc.Core.Models;
using Lsoc.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lsoc.Data.Repositories;

public class PostsRepository : Repository<Post>, IPostsRepository
{
    public PostsRepository(DbContext Context)
        : base(Context)
    {
    }

    public async Task<int> CreatePostAsync(Post post)
    {
        await LsocDbContext.Posts.AddAsync(post);
        await LsocDbContext.SaveChangesAsync();
        return post.PostId;
    }

    public async Task EditPostByIdAsync(int id, Post modified)
    {
        var post = await LsocDbContext.Posts.FindAsync(id);
        post.Message = modified.Message;
        post.DateModified = DateTime.Now;
        await LsocDbContext.SaveChangesAsync();
    }

    public async Task DeletePostByIdAsync(int id, IdentityUser deletedBy)
    {
        var post = await LsocDbContext.Posts.FindAsync(id);
        //LsocDbContext.Posts.Remove(post);
        post.IsDeleted = true;
        post.DeletedBy = deletedBy;
        await LsocDbContext.SaveChangesAsync();
    }

    public async Task<List<Post>> GetActivePostsAsync()
    {
        return await LsocDbContext.Posts
            .Where(m => !m.IsDeleted)
            .OrderByDescending(m => m.DateModified)
            .ToListAsync();
    }

    private LsocDbContext LsocDbContext => Context as LsocDbContext;
}