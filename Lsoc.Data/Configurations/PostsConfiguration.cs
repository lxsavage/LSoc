using Lsoc.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lsoc.Data.Configurations;

public class PostsConfiguration :IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(m => m.PostId);

        builder
            .Property(m => m.PostId)
            .ValueGeneratedOnAdd();

        builder
            .Property(m => m.Message)
            .IsRequired()
            .HasMaxLength(144);

        builder
            .Property(m => m.DatePosted)
            .IsRequired();

        builder
            .ToTable("Posts");
    }
}