using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(NumberPhone), IsUnique = true)]
public abstract class AbstractHuman
{
    [Required]
    [StringLength(40)]
    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(80)]
    public AbstractClass? CurrentAddress { get; set; }

    [StringLength(80)]
    public AbstractClass? HomeTown { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [StringLength(10)]
    [Phone]
    public string NumberPhone { get; set; } = null!;
}