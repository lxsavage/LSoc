using Lsoc.Core.Models;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lsoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostsService _postsService;
    public PostController(IPostsService postsService)
    {
        _postsService = postsService;
    }
    
    [HttpPost, Authorize]
    public async Task<int> CreatePost([FromBody] CreatePostViewModel post)
    {
        return await _postsService.CreatePostAsync(post);
    }
    
    [HttpGet("{id:int}"), Authorize]
    public async Task<Post?> GetPost([FromRoute] int id)
    {
        return await _postsService.GetPostAsync(id);
    }

    [HttpGet]
    public async Task<List<Post?>> GetPosts([FromQuery] int count = 1000)
    {
        return await _postsService.GetTopPostsAsync(count);
    }

    [HttpPatch("{id:int}"), Authorize]
    public async Task EditPost([FromRoute] int id, [FromBody] CreatePostViewModel post)
    {
        await _postsService.EditPostAsync(id, post);
    }

    [HttpDelete("{id:int}"), Authorize]
    public async Task DeletePost([FromRoute] int id)
    {
        await _postsService.DeletePostAsync(id);
    }
}