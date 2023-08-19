using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;
[Table("Khoa")]
[Index(nameof(TenKhoa), IsUnique = true)]
public class Khoa
{
    [Key]
    public int MaKhoa { get; set; }

    [Required]
    [StringLength(80)]
    public required string TenKhoa { get; set; }

    public ICollection<LopQuanLi> LopQuanLis { get; set; } = new HashSet<LopQuanLi>();

    public ICollection<BoMon> BoMons { get; set; } = new HashSet<BoMon>();
}