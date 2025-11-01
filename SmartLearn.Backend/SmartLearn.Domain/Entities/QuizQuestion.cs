using SmartLearn.Domain.Shared;

namespace SmartLearn.Domain.Entities;

public abstract class QuizQuestion : BaseModel<Guid>
{
    public required string Content { get; set; }  
    public int Points  { get; set; }
    public Guid QuizId { get; set; }
    public Quiz? Quiz { get;set; }
    
}