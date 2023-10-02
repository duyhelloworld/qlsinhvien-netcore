using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string? Name { get; set; }

    [Column(TypeName = "tinyint")]
    public short SoTinChi { get; set; }

    public bool Require { get; set; }

    [MaxLength]
    public string? MoTa { get; set; }

    public int? MaMonTienQuyet { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey("MaMonTienQuyet")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Course? MonTienQuyet { get; set; }

    [ForeignKey("DepartmentId")]
    public Department Department { get; set; } = null!;

    public ICollection<CourseClass> CourseClassses { get; set; } = new HashSet<CourseClass>();
}
