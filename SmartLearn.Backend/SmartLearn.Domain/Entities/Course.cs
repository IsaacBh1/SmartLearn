using System.ComponentModel.DataAnnotations;
using SmartLearn.Domain.Shared;

namespace SmartLearn.Domain.Entities;

public class Course : BaseModel<Guid>
{
    [MinLength(2)]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? CourseImage { get; set; }
    public enLevel Level { get; set; } = enLevel.Beginner; 
    public int? CategoryId { get; set; }
    public Category? Category { get; set; } 
    public Guid CreatorId { get; set; }
    public virtual User? Creator { get; set; }
    public ICollection<Module>? Modules {get; set;}
    public ICollection<Quiz>? Quizzes {get; set;}
    public ICollection<Lesson>? Lessons { get; set; }
}