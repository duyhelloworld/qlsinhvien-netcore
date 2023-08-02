using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("LopQuanLi")]
    [Index(nameof(MaGiangVien), IsUnique = true)] // 1-1 giảng viên - lớp quản lí
    public class LopQuanLi
    {
        [Key]
        public int MaLopQuanLi { get; set; }

        [Required]
        [StringLength(20)]
        public string TenLopQuanLi { get; set; }

        [Required]
        public int MaGiangVien;
        [ForeignKey("MaGiangVien")]
        public GiangVien GiangVien { get; set; }

        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }
    }
}
