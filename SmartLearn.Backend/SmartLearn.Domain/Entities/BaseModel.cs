using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLearn.Domain.Entities;

public class BaseModel<TId>
{
    public required TId Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    private DateTime? DeletedAt { get; set; }
    [NotMapped]
    public bool IsDeleted => DeletedAt != null;

    public void MarkDeleted(Guid userId)
    {
        DeletedAt = DateTime.UtcNow; 
        DeletedBy = userId;
    }
    public void MarkNonDeleted()
    {
        DeletedAt = null;
        DeletedBy = null;
    }

}