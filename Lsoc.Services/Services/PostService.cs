using AutoMapper;
using Lsoc.Core;
using Lsoc.Core.Models;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Lsoc.Services.Services;

public class PostService : IPostsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public PostService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<int> CreatePostAsync(CreatePostViewModel post)
    {
        var res = _mapper.Map<Post>(post);
        res.DatePosted = res.DateModified = DateTime.Now;
        res.Author = await _userService.GetCurrentUserAsync();
        return await _unitOfWork.Posts.CreatePostAsync(res);
    }

    public async Task EditPostAsync(int id, CreatePostViewModel post)
    {
        var res = _mapper.Map<Post>(post);
        await _unitOfWork.Posts.EditPostByIdAsync(id, res);
    }

    public async Task DeletePostAsync(int id)
    {
        var user = await _userService.GetCurrentUserAsync();
        await _unitOfWork.Posts.DeletePostByIdAsync(id, user);
    }

    public async Task<PostViewModel?> GetPostAsync(int id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        var mappedPost = _mapper.Map<PostViewModel>(post);

        await _attachAuthorNameAsync(mappedPost);
        return mappedPost;
    }
    
    public async Task<List<PostViewModel?>> GetPostsAsync()
    {
        var posts = await _unitOfWork.Posts.GetAllAsync();
        var mappedPosts = _mapper.Map<List<PostViewModel>>(posts);
        foreach (var mappedPost in mappedPosts)
        {
            await _attachAuthorNameAsync(mappedPost);
        }

        return mappedPosts;
    }

    private async Task _attachAuthorNameAsync(PostViewModel? post)
    {
        if (post?.AuthorId == null) return;

        var user = await _userService.GetUserByIdAsync(post.AuthorId);
        if (user?.UserName != null) post.AuthorName = user.UserName;
    }
}