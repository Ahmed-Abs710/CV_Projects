using Examination_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_Service
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
            
        }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<StudentAnswer> studentAnswers { get; set; }

        public DbSet<ExamResult> examResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exam>().HasMany(x => x.questions).WithOne(x => x.exam).HasForeignKey(x => x.ExamId);

            modelBuilder.Entity<Question>().HasMany(x=>x.answers).WithOne(q => q.question).HasForeignKey(x=>x.QuestionId);

            modelBuilder.Entity<StudentAnswer>().HasOne(x => x.exam).WithMany(x => x.studentAnswers).HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamResult>().HasOne(x => x.exam).WithMany(x => x.examResults).HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentAnswer>().HasOne(x => x.question).WithMany(q => q.studentAnswers).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict);

        }

      

    }
}
