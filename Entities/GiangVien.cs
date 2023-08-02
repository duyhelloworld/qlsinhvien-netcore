using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("GiangVien")] 
public class GiangVien : ConNguoi
{
    [Key]
    public int MaGiangVien { get; set; }
}