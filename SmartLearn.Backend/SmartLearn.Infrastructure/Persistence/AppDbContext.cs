using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartLearn.Domain.Entities;
using SmartLearn.Infrastructure.Persistence.Configs;

namespace SmartLearn.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityUserContext<User , Guid>(options)
{
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonCompleted> LessonsCompleted { get; set; }
    public DbSet<McqQuizQuestion> McqQuizQuestions { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<MCQQuizOption> McqQuizOptions { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
    public DbSet<TFQuizQuestion> TfQuizQuestions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ChangeEntitiesNaming();
        builder.ConfigureEntityRelations();
    }
};