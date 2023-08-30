using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities
{
    [Table("SinhVien")]
    public class SinhVien : ConNguoi
    {
        [Key]
        public int MaSinhVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVaoTruong { get; set; }

        [Required]
        public int MaLopQuanLi { get; set; }
        [ForeignKey("MaLopQuanLi")]
        public LopQuanLi LopQuanLi { get; set; }
        public ICollection<DiemSinhVien>? DiemSinhViens { get; set; } = new HashSet<DiemSinhVien>();
    }
}