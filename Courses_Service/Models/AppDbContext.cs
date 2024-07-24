using Microsoft.EntityFrameworkCore;

namespace Courses_Service.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Courses> courses { get; set; }

        public DbSet<Videos> videos { get; set; }

        public DbSet<Comments> comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Courses>().HasMany(x => x.video)
                .WithOne(x => x.Courses).HasForeignKey(x=>x.CourseId);

            modelBuilder.Entity<Videos>().HasMany(x => x.comment)
                .WithOne(x => x.Video).HasForeignKey(x => x.VideoId);

        }
    }
}
