using Microsoft.AspNetCore.Identity;

namespace Lsoc.Core.ViewModels;

public class PostViewModel
{
    public int PostId { get; set; }
    public string Message { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateModified { get; set; }
    public string AuthorName { get; set; }
    public string AuthorId { get; set; }
    public bool IsDeleted { get; set; }
}