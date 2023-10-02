using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Faculty
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = null!;

    public ICollection<ManagementClass> ManagementClassses { get; set; } = new HashSet<ManagementClass>();

    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
}