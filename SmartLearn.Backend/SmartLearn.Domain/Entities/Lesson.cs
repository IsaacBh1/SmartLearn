namespace SmartLearn.Domain.Entities;

public class Lesson : BaseModel<Guid>
{
    public required string Name { get; init; }
    public string? VideoUrl { get; set; }
    public string? Content { get; set; } 
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!; 
    public Guid ModuleId { get; set; }
    public virtual Module Module { get; set; } = null!; 
    
    public Guid? QuizId { get; set; }
    public Quiz? Quiz { get; set; }

}