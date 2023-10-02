using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

public class CourseClass : AbstractClass
{
    public int InstructorId { get; set; }

    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Course Course { get; set; } = null!;

    [ForeignKey("InstructorId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Instructor Instructor { get; set; } = null!;

    public ICollection<StudentMark>? StudentMarks { get; set; } = new HashSet<StudentMark>();
}