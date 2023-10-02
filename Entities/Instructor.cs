using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

public class Instructor : AbstractHuman
{
    [Key]
    public int Id { get; set; }

    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; } = null!;

    public int? ManagementClassId { get; set; }
    [ForeignKey("ManagementClassId")]
    public ManagementClass? ManagementClass { get; set; }

    public ICollection<CourseClass> CourseClasss { get; set; } = new HashSet<CourseClass>();
}