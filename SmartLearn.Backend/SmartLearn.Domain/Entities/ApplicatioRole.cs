using Microsoft.AspNetCore.Identity;

namespace SmartLearn.Domain.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}