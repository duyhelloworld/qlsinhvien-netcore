using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(NumberPhone), IsUnique = true)]
public class AbstractHuman
{
    [Required]
    [StringLength(40)]
    public string Name { get; set; } = null!;

    public bool Sex { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(80)]
    public string? DiaChiThuongTru { get; set; }

    [StringLength(80)]
    public string? QueQuan { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [StringLength(10)]
    [Phone]
    public string NumberPhone { get; set; } = null!;
}