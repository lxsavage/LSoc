using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace Lsoc.Core.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }
    
    [Required]
    public string Message { get; set; }
    
    [Required]
    public DateTime DatePosted { get; set; }
    
    [Required]
    public DateTime DateModified { get; set; }
    
    [Required]
    public string AuthorId { get; set; }
    
    public string? DeletedUserId { get; set; }
    
    // Navigation properties
    [ForeignKey("AuthorId"), Required]
    public virtual IdentityUser Author { get; set; }
    
    public bool IsDeleted { get; set; }
    
    [ForeignKey("DeletedUserId")]
    public IdentityUser DeletedBy { get; set; }
}