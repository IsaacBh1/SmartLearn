namespace SmartLearn.Domain.Entities;

public class StudentEnrollment
{
    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public User Student { get; set; } = null!;
    public Course Course { get; set; } = null!; 
}