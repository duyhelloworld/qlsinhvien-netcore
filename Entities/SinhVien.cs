using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities
{
    // [Index(nameof(MaLopQuanLi), IsUnique = true)]
    [Table("SinhVien")]
    public class SinhVien : ConNguoi
    {
        [Key]
        [Column(Order = 1)]
        public int MaSinhVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVaoTruong { get; set; }

        [Required]
        [ForeignKey("MaLopQuanLi")]
        public LopQuanLi LopQuanLi { get; set; }

        public ICollection<DiemSinhVien>? DiemSinhViens { get; set; } = new HashSet<DiemSinhVien>();
    }
}