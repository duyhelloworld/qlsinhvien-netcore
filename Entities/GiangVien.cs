using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace qlsinhvien.Entities;

[Table("GiangVien")]
public class GiangVien : ConNguoi
{
    [Key]
    public int MaGiangVien { get; set; }
    
    [Required]
    public int MaKhoa { get; set; }
    [ForeignKey("MaKhoa")]
    [JsonIgnore]
    public Khoa? Khoa { get; set; }
}