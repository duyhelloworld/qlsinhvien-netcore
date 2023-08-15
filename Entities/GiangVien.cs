using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace qlsinhvien.Entities;

[Table("GiangVien")]
public class GiangVien : ConNguoi
{
    [Key]
    public int MaGiangVien { get; set; }
    
    [ForeignKey("MaBoMon")]
    public BoMon BoMon { get; set; }

    [ForeignKey("MaLopQuanLi")]
    public LopQuanLi LopQuanLi { get; set; }

    public List<LopMonHoc> LopMonHocs { get; set; }
}