using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftServeTestTask_DAL.Entities;

namespace SoftServeTestTask_DAL.Database
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        //protected override async void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Seed roles
        //    var admin = new IdentityRole("admin");
        //    admin.NormalizedName = "admin";

        //    var student = new IdentityRole("Student");
        //    student.NormalizedName = "Student";

        //    var teacher = new IdentityRole("Teacher");
        //    teacher.NormalizedName = "Teacher";

        //    builder.Entity<IdentityRole>().HasData(admin, student, teacher);
        //}
    }
}
