using Microsoft.EntityFrameworkCore;
using SmartLearn.Domain.Entities;
using SmartLearn.Domain.Shared;

namespace SmartLearn.Infrastructure.Persistence.Configs;

public static class EntitiesConfiguration
{
    public static void ConfigureEntityRelations(this ModelBuilder builder)
    {
          // configuration relationships between entities 

        builder.Entity<Course>()
            .HasOne(u => u.Creator)
            .WithMany(c => c.Courses)
            .HasForeignKey(f => f.CreatorId);
        
        builder.Entity<Module>()
            .HasOne(c => c.Course)
            .WithMany(m => m.Modules)
            .HasForeignKey(c =>  c.CourseId);
        
        builder.Entity<Quiz>()
            .HasOne(c => c.Course)
            .WithMany(q => q.Quizzes)
            .HasForeignKey(f => f.CourseId);
        
        builder.Entity<Lesson>()
            .HasOne(c => c.Course)
            .WithMany(q => q.Lessons)
            .HasForeignKey(f => f.CourseId);
        
        builder.Entity<Lesson>()
            .HasOne(c => c.Module)
            .WithMany(q => q.Lessons)
            .HasForeignKey(f => f.ModuleId);

        builder.Entity<Lesson>()
            .HasOne(q => q.Quiz)
            .WithOne(l => l.Lesson)
            .HasForeignKey<Quiz>(f => f.Id);

        builder.Entity<QuizQuestion>()
            .HasOne(q => q.Quiz)
            .WithMany(c => c.QuizQuestions)
            .HasForeignKey(f => f.QuizId);
        
        builder.Entity<MCQQuizOption>()
            .HasOne(i => i.QuizQuestion)
            .WithMany(p => p.QuizOptions)
            .HasForeignKey(f => f.QuestionId);
        
        builder.Entity<UserQuizAnswer>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(u => u.UserId);
        
        builder.Entity<UserQuizAnswer>()
            .HasOne(s => s.QuizQuestion)
            .WithMany()
            .HasForeignKey(f => f.QuizQuestionId);
        
        builder.Entity<LessonCompleted>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(u => u.StudentId);
        
        builder.Entity<LessonCompleted>()
            .HasOne(s => s.Lesson)
            .WithMany()
            .HasForeignKey(f => f.LessonId);
        
        builder.Entity<StudentEnrollment>()
            .HasOne(s => s.Student)
            .WithMany()
            .HasForeignKey(u => u.StudentId);
        
        builder.Entity<StudentEnrollment>()
            .HasOne(s => s.Course)
            .WithMany()
            .HasForeignKey(f => f.CourseId);

        // this is for composite primary key
        builder.Entity<UserQuizAnswer>()
            .HasKey(e => new {e.QuizQuestionId , e.UserId});
        
        builder.Entity<StudentEnrollment>()
            .HasKey(e => new {e.StudentId , e.CourseId});
        
        builder.Entity<LessonCompleted>()
            .HasKey(e => new { UserId = e.StudentId , e.LessonId});
        
        // discriminators
        builder.Entity<QuizQuestion>()
            .HasDiscriminator<enQuizType>("QuizType")
                .HasValue<TFQuizQuestion>(enQuizType.TF)
                .HasValue<McqQuizQuestion>(enQuizType.MCQ);

    }
}