using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities;

[Table("Khoa_BoMon")]
[PrimaryKey("MaBoMon", "MaKhoa")]
public class KhoaBoMon
{
    public int MaKhoa { get; set; }
    [ForeignKey("MaKhoa")]
    public Khoa Khoa { get; set; } = null!;
    public int MaBoMon { get; set; }
    [ForeignKey("MaBoMon")]
    public BoMon BoMon { get; set; } = null!;
}