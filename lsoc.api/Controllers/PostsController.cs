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
    
    [HttpGet]
    public async Task<Post?> GetPost([FromQuery] int id)
    {
        return await _postsService.GetPostAsync(id);
    }

    [HttpPatch]
    public async Task EditPost([FromQuery] int id, [FromBody] CreatePostViewModel post)
    {
        await _postsService.EditPostAsync(id, post);
    }

    [HttpDelete]
    public async Task DeletePost([FromQuery] int id)
    {
        await _postsService.DeletePostAsync(id);
    }
}