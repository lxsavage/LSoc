namespace Lsoc.Core.Models;

public class Post
{
    public int PostId { get; set; }
    public string Message { get; set; } = "";
    public DateTime DatePosted { get; set; }
    public DateTime DateModified { get; set; }
}