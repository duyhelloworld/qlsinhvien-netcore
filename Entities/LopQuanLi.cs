using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("LopQuanLi")]
    public class LopQuanLi
    {
        [Key]
        [ForeignKey("GiangVien")]
        // 1 lớp quản lí ko thể lưu nếu thiếu trường giảng viên (mã)
        public int MaLopQuanLi { get; set; }

        [Required]
        [StringLength(20)]
        public string TenLopQuanLi { get; set; }

        [Required]
        // [ForeignKey("MaGiangVien")]
        public GiangVien GiangVien { get; set; }

        [Required]
        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }
    }
}
