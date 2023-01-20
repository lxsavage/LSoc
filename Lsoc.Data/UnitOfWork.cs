using Lsoc.Core;
using Lsoc.Core.Repositories;
using Lsoc.Data.Repositories;

namespace Lsoc.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly LsocDbContext _context;
    private PostsRepository _postsRepository;

    public UnitOfWork(LsocDbContext context)
    {
        _context = context;
    }

    public IPostsRepository Posts => _postsRepository = _postsRepository ?? new PostsRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
    }
}