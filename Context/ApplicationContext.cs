using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Entities;

namespace qlsinhvien.Context;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
    public DbSet<StudentMark> StudentMarks { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<CourseClass> CourseClassses { get; set; }
    public DbSet<ManagementClass> ManagementClassses { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var type in builder.Model.GetEntityTypes())
        {
            var tableName = type.GetTableName()!;
            if (tableName.StartsWith("AspNet"))
            {
                type.SetTableName(tableName.Replace("AspNet", ""));
            }
        }
    }
}