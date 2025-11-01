namespace SmartLearn.Domain.Entities;

public class UserQuizAnswer
{
    public Guid UserId { get; set; }
    public Guid QuizQuestionId { get; set; }
    public bool IsCorrect { get; set; } = false;
    public User User { get; set; } = null!;
    public QuizQuestion QuizQuestion { get; set; } = null!; 
}