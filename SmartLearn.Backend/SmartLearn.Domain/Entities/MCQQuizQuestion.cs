using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLearn.Domain.Entities;

public class McqQuizQuestion : QuizQuestion
{
    
    public Guid SolutionId { get; set; }
    
    public ICollection<MCQQuizOption>? QuizOptions { get; set; }
    
}