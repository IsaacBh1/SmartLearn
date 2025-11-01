namespace SmartLearn.Domain.Entities;

public class MCQQuizOption 
{
    public Guid Id { get; set; }
    
    public required string Content { get; set; } 
    public Guid QuestionId { get; set; }
    public McqQuizQuestion? QuizQuestion { get; set; }
    
}