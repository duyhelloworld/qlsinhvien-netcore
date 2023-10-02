using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = null!;

    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    public ICollection<Faculty> Faculties { get; set; } = new HashSet<Faculty>();
}