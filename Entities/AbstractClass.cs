using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public abstract class AbstractClass
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string ClassName { get; set; } = null!;
}