using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

public class ManagementClass : AbstractClass
{
    public int InstructorId { get; set; }

    public int FacultyId { get; set; }

    [ForeignKey("InstructorId")]
    public Instructor Instructor { get; set; } = null!;

    [ForeignKey("FacultyId")]
    public Faculty Faculty { get; set; } = null!;
}
