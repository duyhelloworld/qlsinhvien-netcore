using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("LopQuanLi")]
    public class LopQuanLi
    {
        [Key]
        public int MaLopQuanLi { get; set; }

        [Required]
        [StringLength(20)]
        public required string TenLopQuanLi { get; set; }

        [ForeignKey("MaGiangVien")]
        public GiangVien? GiangVien { get; set; }

        [Required]
        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }
    }
}
