using Lsoc.Core.Models;
using Lsoc.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Lsoc.Data;

public class LsocDbContext : DbContext
{
    public DbSet<Post?> Posts { get; set; }
    
    public LsocDbContext(DbContextOptions<LsocDbContext> options)
        :base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new PostsConfiguration());
    }
}