namespace P01_StudentSystem.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(x => x.Name).HasMaxLength(100).IsUnicode();

            modelBuilder.Entity<Student>().Property(x => x.PhoneNumber).HasColumnType("char(10)").IsUnicode(false);


            modelBuilder.Entity<Course>().Property(x => x.Name).HasMaxLength(80).IsUnicode().IsRequired();

            modelBuilder.Entity<Course>().Property(x => x.Description).IsUnicode();


            modelBuilder.Entity<Resource>().Property(x => x.Name).HasMaxLength(50).IsUnicode().IsRequired();

            modelBuilder.Entity<Resource>().Property(x => x.Url).IsUnicode(false).IsRequired();


            modelBuilder.Entity<Homework>().Property(x => x.Content).IsUnicode(false).IsRequired();


            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.CourseId, x.StudentId });
        }
    }
}
