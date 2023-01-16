using Microsoft.AspNetCore.Mvc;

namespace Lsoc.API.Controllers;

public class PostsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}