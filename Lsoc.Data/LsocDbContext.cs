using Lsoc.Core.Models;
using Lsoc.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lsoc.Data;

public class LsocDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Post> Posts { get; set; }
    
    public LsocDbContext(DbContextOptions<LsocDbContext> options)
        :base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new PostsConfiguration());
    }
}