using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.DAL
{
    public class StudentPortalContext : IdentityDbContext<IdentityUser>
    {
        // properties
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

        // constructor
        public StudentPortalContext(DbContextOptions<StudentPortalContext> options) : base(options) { }

        // OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRIMARY KEYS
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseID);
            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentID); 
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentID);

            // PROPERTY CONSTRAINTS
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Course>()
                .Property(c => c.Duration)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Course>()
                .Property(c => c.Credits)
                .IsRequired();

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentHead)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentEmail)
                .IsRequired()
                .HasMaxLength(100);

            // RELATIONSHIPS
            // department to student : one to many
            modelBuilder.Entity<Student>()
                .HasOne(d => d.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartmentID);

            // department to course: one to many
            modelBuilder.Entity<Course>()
                .HasOne(d => d.Department)
                .WithMany(s => s.Courses)
                .HasForeignKey(d => d.DepartmentID);

            // student to course: many to many
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Courses)
                .WithMany(s => s.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    sc => sc.HasOne<Course>().WithMany().HasForeignKey("CourseID"),
                    sc => sc.HasOne<Student>().WithMany().HasForeignKey("StudentID").OnDelete(DeleteBehavior.NoAction),
                    sc => 
                    {
                        sc.HasKey("StudentID", "CourseID");
                        sc.ToTable("StudentCourse");
                    }
                );
        }
    }
}
