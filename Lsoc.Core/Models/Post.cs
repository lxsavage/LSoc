namespace Lsoc.Core.Models;

public class Post
{
    public int PostId { get; set; }
    public string Message { get; set; } = "";
    public int Likes { get; set; } = 0;
    public int Dislikes { get; set; } = 0;
    public DateTime DatePosted { get; set; }
    public DateTime DateModified { get; set; }
}