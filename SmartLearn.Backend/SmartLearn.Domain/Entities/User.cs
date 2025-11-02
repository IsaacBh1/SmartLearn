using Microsoft.AspNetCore.Identity;
using SmartLearn.Domain.Shared;

namespace SmartLearn.Domain.Entities;

public class User : IdentityUser<Guid>
{   
    public string FirstName { get; set; } = null!; 
    public string? LastName { get; set; }
    public bool IsActive { get; set; } = true; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
    public enRole Role { get; set; }
    public ICollection<Course>? Courses { get; set; }
}