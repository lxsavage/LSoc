using Lsoc.Core.Repositories;

namespace Lsoc.Core;

public interface IUnitOfWork : IDisposable
{
    IPostsRepository Posts { get; }
    Task<int> CommitAsync();
}