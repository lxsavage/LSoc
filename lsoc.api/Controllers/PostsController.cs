using Lsoc.Core.Models;
using Lsoc.Core.Services;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lsoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostsService _postsService;
    public PostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }
    
    [HttpPost]
    public async Task<int> CreatePost([FromBody] CreatePostViewModel post)
    {
        return await _postsService.CreatePostAsync(post);
    }
    
    [HttpGet("{id:int}")]
    public async Task<Post?> GetPost([FromRoute] int id)
    {
        return await _postsService.GetPostAsync(id);
    }

    [HttpGet]
    public async Task<List<Post?>> GetPosts([FromQuery] int count = 1000)
    {
        return await _postsService.GetTopPostsAsync(count);
    }

    [HttpPatch("{id:int}")]
    public async Task EditPost([FromRoute] int id, [FromBody] CreatePostViewModel post)
    {
        await _postsService.EditPostAsync(id, post);
    }

    [HttpDelete("{id:int}")]
    public async Task DeletePost([FromRoute] int id)
    {
        await _postsService.DeletePostAsync(id);
    }
}