using AutoMapper;
using Lsoc.Core;
using Lsoc.Core.Models;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;

namespace Lsoc.Services.Services;

public class PostsService : IPostsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PostsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Post?> GetPostAsync(int id)
    {
        return await _unitOfWork.Posts.GetByIdAsync(id);
    }

    public async Task<int> CreatePostAsync(CreatePostViewModel post)
    {
        var res = _mapper.Map<Post>(post);
        res.DatePosted = res.DateModified = DateTime.Now;
        return await _unitOfWork.Posts.CreatePostAsync(res);
    }

    public async Task EditPostAsync(int id, CreatePostViewModel post)
    {
        var res = _mapper.Map<Post>(post);
        await _unitOfWork.Posts.EditPostByIdAsync(id, res);
    }

    public async Task DeletePostAsync(int id)
    {
        await _unitOfWork.Posts.DeletePostByIdAsync(id);
    }

    public async Task<List<Post?>> GetTopPostsAsync(int count = 1)
    {
        return await _unitOfWork.Posts.GetTopPostsAsync(count);
    }
}