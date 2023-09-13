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
    public BoMon BoMon { get; set; } = null!;

    public LopQuanLi? LopQuanLi { get; set; }

    public ICollection<LopMonHoc> LopMonHocs { get; set; } = new HashSet<LopMonHoc>();
}