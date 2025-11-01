namespace SmartLearn.Domain.Entities;

public class Quiz : BaseModel<Guid>
{
    public int PassingScore { get; set; }
    public int TimeLimitMinutes { get; set; }
    
    public Guid LessonId { get; set; }
    public Lesson? Lesson { get; set; }
    
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;

    public ICollection<QuizQuestion> QuizQuestions { get; set; } = null!;
}