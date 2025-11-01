namespace SmartLearn.Domain.Entities;

public class LessonCompleted
{
    public DateTime CompletedAt { get; set; }
    public Guid LessonId { get; set; }
    public Guid StudentId { get; set; }
    public User User { get; set; } = null!;
    public Lesson Lesson { get; set; } = null!; 
    
}