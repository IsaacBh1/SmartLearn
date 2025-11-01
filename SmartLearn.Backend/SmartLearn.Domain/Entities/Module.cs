namespace SmartLearn.Domain.Entities;

public class Module : BaseModel<Guid>
{
     public required string ModuleDescription { get; set; }
     public Guid CourseId { get; set; }
     public virtual Course Course { get; set; } = null!; 
     public ICollection<Lesson>? Lessons { get; set; }
}